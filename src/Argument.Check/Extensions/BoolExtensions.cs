using System.Diagnostics;

namespace Argument.Check.Extensions
{
    internal static class BoolExtensions
    {
#if !DEBUG
        [DebuggerHidden] 
#endif
        internal static bool IsFalse(this bool source)
        {
            return !source;
        }

#if !DEBUG
        [DebuggerHidden] 
#endif
        internal static bool IsNot(this bool source)
        {
            return !source;
        }
    }
}