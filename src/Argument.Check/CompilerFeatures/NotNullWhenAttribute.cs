// Only define if not already available (e.g., when targeting .NET 6 or later)
#if NETSTANDARD2_0
// ReSharper disable once CheckNamespace
// Compile feature hack for .net standard
#pragma warning disable IDE0130
namespace System.Diagnostics.CodeAnalysis
{
    [AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
    public sealed class NotNullWhenAttribute : Attribute
    {
        /// <summary>Initializes the attribute with the specified return value condition.</summary>
        /// <param name="returnValue">
        /// The return value condition. If the method returns this value, the associated parameter will not be null.
        /// </param>
        public NotNullWhenAttribute(bool returnValue)
        {
            ReturnValue = returnValue;
        }

        /// <summary>Gets the return value condition.</summary>
        public bool ReturnValue { get; }
    }
}
#pragma warning restore IDE0130
#endif
