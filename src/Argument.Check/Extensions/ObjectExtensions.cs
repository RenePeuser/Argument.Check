using System.Diagnostics;
using Argument.Check.ThrowHelper;

namespace Argument.Check.Extensions
{
    internal static class ObjectExtensions
    {
        [DebuggerHidden]
        internal static bool Is<T>(this object source)
        {
            return source is T;
        }

        [DebuggerHidden]
        internal static bool IsNotNull(this object source)
        {
            return !source.EqualsTo(null);
        }

        [DebuggerHidden]
        internal static bool IsNotTypeOf<T>(this object source)
        {
            Throw.IfNull(() => source);

            return !source.IsTypeOf<T>();
        }

        [DebuggerHidden]
        internal static bool IsTypeOf<T>(this object source)
        {
            Throw.IfNull(() => source);

            return source.GetType().IsTypeOf<T>();
        }

        [DebuggerHidden]
        internal static T Cast<T>(this object source)
        {
            Throw.IfNull(() => source);

            return (T) source;
        }
    }
}
