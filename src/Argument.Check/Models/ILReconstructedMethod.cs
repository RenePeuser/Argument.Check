using System.Reflection;

namespace Argument.Check.Models
{
    internal sealed class ILReconstructedMethod
    {
        internal ILReconstructedMethod(MethodInfo methodInfo, FieldInfo returnValue)
        {
            Throw.IfNull(methodInfo);
            Throw.IfNull(returnValue);

            MethodInfo = methodInfo;
            ReturnValue = returnValue;
        }

        internal MethodInfo MethodInfo { get; }

        internal FieldInfo ReturnValue { get; }
    }
}
