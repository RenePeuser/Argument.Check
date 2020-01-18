using System;
using System.Diagnostics;

namespace Argument.Check.Extensions
{
    internal static class ComparableExtensions
    {
        // [DebuggerHidden]
        internal static bool IsEqualTo<T>(this T source, T target) where T : IComparable
        {
            Throw.IfNull<object>(() => source);
            Throw.IfNull<object>(() => target);

            return source.CompareTo(target) == 0;
        }

        // [DebuggerHidden]
        internal static bool IsLessThan<T>(this T source, T target) where T : IComparable
        {
            Throw.IfNull<object>(() => source);
            Throw.IfNull<object>(() => target);

            return source.CompareTo(target) < 0;
        }

        // [DebuggerHidden]
        internal static bool IsLessOrEqual<T>(this T source, T target) where T : IComparable
        {
            Throw.IfNull<object>(() => source);
            Throw.IfNull<object>(() => target);

            return !source.IsGreaterThan(target);
        }

        // [DebuggerHidden]
        internal static bool IsGreaterThan<T>(this T source, T target) where T : IComparable
        {
            Throw.IfNull<object>(() => source);
            Throw.IfNull<object>(() => target);

            return source.CompareTo(target) > 0;
        }

        // [DebuggerHidden]
        internal static bool IsGreaterOrEqual<T>(this T source, T target) where T : IComparable
        {
            Throw.IfNull<object>(() => source);
            Throw.IfNull<object>(() => target);

            return !source.IsLessThan(target);
        }

        // [DebuggerHidden]
        internal static bool IsInRange<T>(this T source, T lowerLimit, T upperLimit) where T : IComparable
        {
            Throw.IfLessThan(() => upperLimit, lowerLimit);

            return source.IsLessOrEqual(upperLimit) && source.IsGreaterOrEqual(lowerLimit);
        }

        // [DebuggerHidden]
        internal static bool IsOutOfRange<T>(this T source, T lowerLimit, T upperLimit) where T : IComparable
        {
            Throw.IfLessThan(() => upperLimit, lowerLimit);

            return !source.IsInRange(lowerLimit, upperLimit);
        }
    }
}
