using System.Diagnostics;

namespace Argument.Check.Extensions
{
    internal static class StringExtensions
    {
#if !DEBUG
        [DebuggerHidden]
#endif
        internal static bool IsNullOrWhiteSpace(this string source)
        {
            return string.IsNullOrWhiteSpace(source);
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        internal static bool IsWhitespace(this string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                return false;
            }

            return string.IsNullOrWhiteSpace(source);
        }
    }
}