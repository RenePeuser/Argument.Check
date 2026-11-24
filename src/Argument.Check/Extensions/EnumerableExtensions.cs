#if !DEBUG
using System.Diagnostics;
#endif
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Argument.Check.Extensions
{
    // Plain loops instead of LINQ with a lambda: no closure and no delegate per call.
    // Arrays and List<T> are walked without allocating an enumerator; any other sequence is enumerated once, as before.
    internal static class EnumerableExtensions
    {
#if !DEBUG
        [DebuggerHidden]
#endif
        internal static bool IsAnyItemNull<T>(this IEnumerable<T> source)
        {
            if (source is T[] array)
            {
                foreach (var item in array)
                {
                    if (item is null)
                    {
                        return true;
                    }
                }

                return false;
            }

            if (source is List<T> list)
            {
                foreach (var item in list)
                {
                    if (item is null)
                    {
                        return true;
                    }
                }

                return false;
            }

            foreach (var item in source)
            {
                if (item is null)
                {
                    return true;
                }
            }

            return false;
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        internal static bool IsAnyItemNullOrWhitespace(this IEnumerable<string> source)
        {
            if (source is string[] array)
            {
                foreach (var item in array)
                {
                    if (string.IsNullOrWhiteSpace(item))
                    {
                        return true;
                    }
                }

                return false;
            }

            if (source is List<string> list)
            {
                foreach (var item in list)
                {
                    if (string.IsNullOrWhiteSpace(item))
                    {
                        return true;
                    }
                }

                return false;
            }

            foreach (var item in source)
            {
                if (string.IsNullOrWhiteSpace(item))
                {
                    return true;
                }
            }

            return false;
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        internal static bool IsAnyItem<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source is T[] array)
            {
                foreach (var item in array)
                {
                    if (predicate(item))
                    {
                        return true;
                    }
                }

                return false;
            }

            if (source is List<T> list)
            {
                foreach (var item in list)
                {
                    if (predicate(item))
                    {
                        return true;
                    }
                }

                return false;
            }

            foreach (var item in source)
            {
                if (predicate(item))
                {
                    return true;
                }
            }

            return false;
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        internal static bool IsEmpty<T>(this IEnumerable<T> source)
        {
            if (source is ICollection<T> collection)
            {
                return collection.Count == 0;
            }

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
