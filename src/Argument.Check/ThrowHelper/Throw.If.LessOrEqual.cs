using System;
using System.Diagnostics;
using Argument.Check.Extensions;

namespace Argument.Check.ThrowHelper
{
    public partial class Throw
    {
        [DebuggerHidden]
        public static void IfLessOrEqual<T>(Func<T> argumentFunc, T limit) where T : IComparable
        {
            IfNull(() => argumentFunc);

            if (!argumentFunc().IsLessOrEqual(limit))
            {
                return;
            }

            ThrowLessOrEqualException(argumentFunc, limit, arg => arg is T && ((T) arg).IsLessOrEqual(limit));
        }

        [DebuggerHidden]
        private static void ThrowLessOrEqualException<T>(Func<T> argumentFunc, T limit, Func<object, bool> predicate)
            where T : IComparable
        {
            throw new ArgumentOutOfRangeException(argumentFunc.GetParameterName(predicate), $"Value: '{argumentFunc()}' must not be less than or equal to: '{limit}'.");
        }
    }
}
