using System;
using System.Diagnostics;
using Argument.Check.Extensions;

namespace Argument.Check.ThrowHelper
{
    public partial class Throw
    {
        [DebuggerHidden]
        public static void IfOutOfRange<T>(Func<T> argumentFunc, T min, T max) where T : IComparable
        {
            IfNull(() => argumentFunc);

            if (!argumentFunc().IsOutOfRange(min, max))
            {
                return;
            }

            ThrowValueOutOfRangeException(argumentFunc, min, max, arg => arg is T && ((T) arg).IsOutOfRange(min, max));
        }

        [DebuggerHidden]
        private static void ThrowValueOutOfRangeException<T>(
            Func<T> argumentFunc,
            T minimum,
            T maximum,
            Func<object, bool> predicate) where T : IComparable
        {
            throw new ArgumentOutOfRangeException(
                argumentFunc.GetParameterName(predicate),
                $"Value: '{argumentFunc()}' is not in expected range from '{minimum}' to '{maximum}'.");
        }
    }
}
