using System.Diagnostics;

namespace Argument.Check.Extensions
{
    internal static class BoolExtensions
    {
        [DebuggerHidden]
        internal static bool IsFalse(this bool source)
        {
            return !source;
        }
    }
}
