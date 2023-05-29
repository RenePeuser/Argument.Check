using System;
#if !DEBUG
using System.Diagnostics;
#endif
using System.Runtime.CompilerServices;

namespace Argument.Check
{
    /// <summary>Provides a set of static methods to validate your arguments.</summary>
    public partial class Throw
    {
        /// <summary>Throws an <see cref="ArgumentException" />, when the given type is the specific type <c>T</c>. Hint: It is a type equal test, it is not assignable from check !.</summary>
        /// <param name="argument">The argument, which has to be checked.</param>
        /// <param name="argumentName">The argument name will be automatically detected by the <see cref="CallerArgumentExpressionAttribute"/>, so please do not enter any name, otherwise you will got the wrong parameter name.</param>
        /// <returns>The given argument, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, when the given type is the specific type.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        public static object IfTypeIs<T>(object? argument, [CallerArgumentExpression(nameof(argument))] string argumentName = "") where T : class
        {
            IfNull(argument);

            if (argument is not T)
            {
                return argument;
            }

            throw new ArgumentException($"The given type: '{argument.GetType()}' is the expected type: '{typeof(T)}'.", argumentName);
        }
    }
}
