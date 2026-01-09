// Only define if not already available (e.g., when targeting .NET 6 or later)
#if NETSTANDARD2_0
// ReSharper disable once CheckNamespace
// Compile feature hack for .net standard
#pragma warning disable IDE0130
namespace System.Diagnostics.CodeAnalysis
{
    [AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
    public sealed class NotNullAttribute() : Attribute
    {
    }
}
#pragma warning restore IDE0130
#endif
