#if !DEBUG
using System.Diagnostics;
#endif
using System.Runtime.CompilerServices;

namespace Argument.Check.Extensions
{
    internal static class ComparableExtensions
    {
        // Compares without boxing value types.
        // Value types go through Comparer<T>.Default, which uses IComparable<T> when the type implements it (no boxing)
        // and falls back to IComparable otherwise. Reference types keep calling IComparable.CompareTo directly,
        // so a null argument behaves exactly as before.
#if !DEBUG
        [DebuggerHidden]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int Compare<T>(T source, T target) where T : IComparable
        {
            if (default(T) is null)
            {
                return source.CompareTo(target);
            }

            return Comparer<T>.Default.Compare(source, target);
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsEqualTo<T>(this T source, T target) where T : IComparable
        {
            return Compare(source, target) == 0;
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsLessThan<T>(this T source, T target) where T : IComparable
        {
            return Compare(source, target) < 0;
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsLessOrEqual<T>(this T source, T target) where T : IComparable
        {
            return !source.IsGreaterThan(target);
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsGreaterThan<T>(this T source, T target) where T : IComparable
        {
            return Compare(source, target) > 0;
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsGreaterOrEqual<T>(this T source, T target) where T : IComparable
        {
            return !source.IsLessThan(target);
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsInRange<T>(this T source, T lowerLimit, T upperLimit) where T : IComparable
        {
            Throw.IfLessThan(upperLimit, lowerLimit);

            return source.IsWithin(lowerLimit, upperLimit);
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsOutOfRange<T>(this T source, T lowerLimit, T upperLimit) where T : IComparable
        {
            // The limits are validated once (this used to happen twice). Same exception as before when min > max.
            Throw.IfLessThan(upperLimit, lowerLimit);

            return !source.IsWithin(lowerLimit, upperLimit);
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsWithin<T>(this T source, T lowerLimit, T upperLimit) where T : IComparable
        {
            return source.IsLessOrEqual(upperLimit) && source.IsGreaterOrEqual(lowerLimit);
        }
    }
}
