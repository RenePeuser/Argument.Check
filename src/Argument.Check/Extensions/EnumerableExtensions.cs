using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Argument.Check.Extensions
{
    internal static class EnumerableExtensions
    {
        [DebuggerHidden]
        internal static bool IsAnyItemNull<T>(this IEnumerable<T> source)
        {
            Throw.IfNull(() => source);

            return source.IsAnyItem(item => item == null);
        }

        [DebuggerHidden]
        internal static bool IsAnyItemNullOrWhitespace(this IEnumerable<string> source)
        {
            Throw.IfNull(() => source);

            return source.IsAnyItem(item => item.IsNullOrWhiteSpace());
        }

        [DebuggerHidden]
        internal static bool IsAnyItem<T>(this IEnumerable<T> source, Predicate<T> check)
        {
            Throw.IfNull(() => source);

            return source.Any(item => check(item));
        }

        [DebuggerHidden]
        internal static bool IsEmpty<T>(this IEnumerable<T> source)
        {
            Throw.IfNull(() => source);

            return !source.Any();
        }
    }
}
