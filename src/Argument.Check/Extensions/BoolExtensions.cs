#pragma warning disable IDE0005 // It is used by the precompiler switch release !!
using System.Diagnostics;
#pragma warning restore IDE0005 // It is used by the precompiler switch release !!

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