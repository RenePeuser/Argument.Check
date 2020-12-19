using System;
using System.Diagnostics;

namespace Argument.Check.Extensions
{
    internal static class ComparableExtensions
    {
#if !DEBUG
        [DebuggerHidden]
#endif
        internal static bool IsEqualTo<T>(this T source, T target) where T : IComparable
        {
            return source.CompareTo(target) == 0;
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        internal static bool IsLessThan<T>(this T source, T target) where T : IComparable
        {
            return source.CompareTo(target) < 0;
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        internal static bool IsLessOrEqual<T>(this T source, T target) where T : IComparable
        {
            return !source.IsGreaterThan(target);
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        internal static bool IsGreaterThan<T>(this T source, T target) where T : IComparable
        {
            return source.CompareTo(target) > 0;
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        internal static bool IsGreaterOrEqual<T>(this T source, T target) where T : IComparable
        {
            return !source.IsLessThan(target);
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        internal static bool IsInRange<T>(this T source, T lowerLimit, T upperLimit) where T : IComparable
        {
            Throw.IfLessThan(() => upperLimit, lowerLimit);

            return source.IsLessOrEqual(upperLimit) && source.IsGreaterOrEqual(lowerLimit);
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        internal static bool IsOutOfRange<T>(this T source, T lowerLimit, T upperLimit) where T : IComparable
        {
            Throw.IfLessThan(() => upperLimit, lowerLimit);

            return !source.IsInRange(lowerLimit, upperLimit);
        }
    }
}