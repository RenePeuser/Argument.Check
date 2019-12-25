using System;
using System.Diagnostics;

namespace Argument.Check.Extensions
{
    internal static class TypeExtensions
    {
        [DebuggerHidden]
        internal static bool IsTypeOf<T>(this Type type)
        {
            Throw.IfNull(() => type);

            return type == typeof(T);
        }
    }
}
