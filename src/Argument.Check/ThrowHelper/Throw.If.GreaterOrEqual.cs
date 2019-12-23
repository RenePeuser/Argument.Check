using System;
using System.Diagnostics;
using Argument.Check.Extensions;

namespace Argument.Check.ThrowHelper
{
    public partial class Throw
    {
        [DebuggerHidden]
        public static void IfGreaterOrEqual<T>(Func<T> argumentFunc, T limit) where T : IComparable
        {
            IfNull(() => argumentFunc);

            if (!argumentFunc().IsGreaterOrEqual(limit))
            {
                return;
            }

            ThrowGreaterOrEqualException(argumentFunc, limit, arg => arg is T && ((T) arg).IsGreaterOrEqual(limit));
        }

        [DebuggerHidden]
        private static void ThrowGreaterOrEqualException<T>(Func<T> argumentFunc, T limit, Func<object, bool> predicate)
            where T : IComparable
        {
            throw new ArgumentOutOfRangeException(argumentFunc.GetParameterName(predicate), $"Value: '{argumentFunc()}' must not be greater than or equal to: '{limit}'.");
        }
    }
}
