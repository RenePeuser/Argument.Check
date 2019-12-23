using System.Diagnostics;

namespace Argument.Check.Extensions
{
    internal static class StringExtensions
    {
        [DebuggerHidden]
        internal static bool IsNullOrWhiteSpace(this string source)
        {
            return string.IsNullOrWhiteSpace(source);
        }

        [DebuggerHidden]
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
