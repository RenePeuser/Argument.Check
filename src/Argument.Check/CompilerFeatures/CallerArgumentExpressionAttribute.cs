// Only define if not already available (e.g., when targeting .NET 6 or later)
#if !NET6_0_OR_GREATER
// ReSharper disable once CheckNamespace
// Compile feature hack for .net standard
#pragma warning disable IDE0130
namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
    public sealed class CallerArgumentExpressionAttribute(string parameterName) : Attribute
    {
        public string ParameterName { get; } = parameterName;
    }
}
#pragma warning restore IDE0130
#endif
