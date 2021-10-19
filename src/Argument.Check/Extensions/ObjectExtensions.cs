#pragma warning disable IDE0005 // It is used by the precompiler switch release !!
using System.Diagnostics;
#pragma warning restore IDE0005 // It is used by the precompiler switch release !!
using System.Diagnostics.CodeAnalysis;

namespace Argument.Check.Extensions
{
    internal static class ObjectExtensions
    {
#if !DEBUG
        [DebuggerHidden]
#endif
        internal static bool Is<T>(this object source)
        {
            return source is T;
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        internal static bool IsNot<T>(this object source)
        {
            return source is not T;
        }

#if !DEBUG
        [DebuggerHidden]
#endif
#pragma warning disable CS8777 // This method returns true if the given object is not null
        internal static bool IsNotNull([NotNull] this object? source) => source is not null;
#pragma warning restore CS8777 // This method returns true if the given object is not null

#if !DEBUG
        [DebuggerHidden]
#endif
        internal static bool IsNull([NotNull] this object? source)
        {
#pragma warning disable CS8777 // This is a helper to check object for null like => "obj is null"
            return source is null;
#pragma warning restore CS8777 // Parameter must have a non-null value when exiting.
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        internal static bool IsNotTypeOf<T>(this object source)
        {
            return !source.IsTypeOf<T>();
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        internal static bool IsTypeOf<T>(this object source)
        {
            return source.GetType().IsTypeOf<T>();
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        internal static T Cast<T>(this object source)
        {
            return (T)source;
        }
    }
}