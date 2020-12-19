using System;
#pragma warning disable IDE0005 // It is used by the precompiler switch release !!
using System.Diagnostics;
#pragma warning restore IDE0005 // It is used by the precompiler switch release !!

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