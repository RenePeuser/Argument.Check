#if !DEBUG
using System.Diagnostics;
#endif
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Argument.Check.Extensions
{
    internal static class EnumerableExtensions
    {
#if !DEBUG
        [DebuggerHidden]
#endif
        internal static bool IsAnyItemNull<T>(this IEnumerable<T> source)
        {
            return source.IsAnyItem(item => item == null);
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        internal static bool IsAnyItemNullOrWhitespace(this IEnumerable<string> source)
        {
            return source.IsAnyItem(item => item.IsNullOrWhiteSpace());
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        internal static bool IsAnyItem<T>(this IEnumerable<T> source, Predicate<T> check)
        {
            return source.Any(item => check(item));
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        internal static bool IsEmpty<T>(this IEnumerable<T> source)
        {
            return !source.Any();
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        internal static bool IsNullOrEmpty<T>([NotNull] this IEnumerable<T> source)
        {
            return source.IsNull() || source.IsEmpty();
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        internal static bool NotContains<T>(this IEnumerable<T> source, T itemWhichShouldNotBeInSide)
        {
            return !source.Contains(itemWhichShouldNotBeInSide);
        }
    }
}
