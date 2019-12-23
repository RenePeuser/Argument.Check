using System;
using System.Diagnostics;
using Argument.Check.Extensions;

namespace Argument.Check.ThrowHelper
{
    public partial class Throw
    {
        [DebuggerHidden]
        public static void IfLessThan<T>(Func<T> argumentFunc, T limit) where T : IComparable
        {
            IfNull(() => argumentFunc);

            if (!argumentFunc().IsLessThan(limit))
            {
                return;
            }

            ThrowLessThanException(argumentFunc, limit, arg => arg is T && ((T) arg).IsLessThan(limit));
        }

        [DebuggerHidden]
        private static void ThrowLessThanException<T>(Func<T> argumentFunc, T limit, Func<object, bool> predicate)
            where T : IComparable
        {
            throw new ArgumentOutOfRangeException(argumentFunc.GetParameterName(predicate), $"Value: '{argumentFunc()}' must not be less than: '{limit}'.");
        }
    }
}
