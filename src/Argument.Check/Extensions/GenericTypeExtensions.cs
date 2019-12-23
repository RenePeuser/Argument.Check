using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Argument.Check.Extensions
{
    internal static class GenericTypeExtensions
    {
        private const double DefaultDoubleTolerance = 0.000001;

        [DebuggerHidden]
        internal static bool EqualsTo<T>(this T source, T target)
        {
            return EqualityComparer<T>.Default.Equals(source, target);
        }

        [DebuggerHidden]
        internal static bool EqualsTo(this double source, double target)
        {
            return EqualsTo(source, target, DefaultDoubleTolerance);
        }

        [DebuggerHidden]
        internal static bool EqualsTo(this double source, double target, double tolerance)
        {
            return Math.Abs(source - target).IsLessThan(tolerance);
        }

        [DebuggerHidden]
        internal static bool NotEqualsTo<T>(this T source, T target)
        {
            return !source.EqualsTo(target);
        }
    }
}
