using System.Diagnostics;

namespace Argument.Check.Extensions
{
    internal static class DoubleExtensions
    {
#if !DEBUG
        [DebuggerHidden] 
#endif
        internal static bool IsNan(this double value)
        {
            return double.IsNaN(value);
        }

#if !DEBUG
        [DebuggerHidden] 
#endif
        internal static bool IsZero(this double source)
        {
            var result = source.EqualsTo(default);
            return result;
        }
    }
}