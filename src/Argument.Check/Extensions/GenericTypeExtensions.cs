using System;
using System.Collections.Generic;
#pragma warning disable IDE0005 // It is used by the precompiler switch release !!
using System.Diagnostics;
#pragma warning restore IDE0005 // It is used by the precompiler switch release !!

namespace Argument.Check.Extensions
{
    internal static class GenericTypeExtensions
    {
        private const double DefaultDoubleTolerance = 0.000001;

#if !DEBUG
        [DebuggerHidden] 
#endif
        internal static bool EqualsTo<T>(this T source, T? target)
        {
            return EqualityComparer<T>.Default.Equals(source, target);
        }

#if !DEBUG
        [DebuggerHidden] 
#endif
        internal static bool EqualsTo(this double source, double target, double tolerance = DefaultDoubleTolerance)
        {
            return Math.Abs(source - target).IsLessThan(tolerance);
        }

#if !DEBUG
        [DebuggerHidden] 
#endif
        internal static bool NotEqualsTo<T>(this T source, T target)
        {
            return !source.EqualsTo(target);
        }
    }
}