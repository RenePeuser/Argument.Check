using System;
using System.Diagnostics;

namespace Argument.Check.Extensions
{
    internal static class TypeExtensions
    {
#if !DEBUG
        [DebuggerHidden] 
#endif
        internal static bool IsTypeOf<T>(this Type type)
        {
            return type == typeof(T);
        }
    }
}