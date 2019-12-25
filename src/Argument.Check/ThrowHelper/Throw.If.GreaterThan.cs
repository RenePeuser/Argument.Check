using System;
using System.Diagnostics;
using Argument.Check.Extensions;

namespace Argument.Check
{
    public partial class Throw
    {
        [DebuggerHidden]
        public static void IfGreaterThan<T>(Func<T> argumentFunc, T limit) where T : IComparable
        {
            IfNull(() => argumentFunc);

            if (!argumentFunc().IsGreaterThan(limit))
            {
                return;
            }

            ThrowGreaterThanException(argumentFunc, limit, arg => arg is T && ((T) arg).IsGreaterThan(limit));
        }

        [DebuggerHidden]
        private static void ThrowGreaterThanException<T>(Func<T> argumentFunc, T limit, Func<object, bool> predicate)
            where T : IComparable
        {
            throw new ArgumentOutOfRangeException(argumentFunc.GetParameterName(predicate), $"Value: '{argumentFunc()}' must not be greater than: '{limit}'.");
        }
    }
}
