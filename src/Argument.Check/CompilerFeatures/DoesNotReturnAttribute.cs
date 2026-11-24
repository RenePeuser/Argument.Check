// Only define if not already available (e.g., when targeting .NET 6 or later)
#if NETSTANDARD2_0
// ReSharper disable once CheckNamespace
// Compile feature hack for .net standard. Internal on purpose: it must not become part of the public API.
#pragma warning disable IDE0130
namespace System.Diagnostics.CodeAnalysis
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    internal sealed class DoesNotReturnAttribute : Attribute
    {
    }
}
#pragma warning restore IDE0130
#endif
