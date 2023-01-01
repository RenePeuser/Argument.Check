using System;
#if !DEBUG
using System.Diagnostics;
#endif
using System.Runtime.CompilerServices;
using Argument.Check.Extensions;

namespace Argument.Check
{
    /// <summary>Provides a set of static methods to validate your arguments.</summary>
    public partial class Throw
    {
        /// <summary>Throws an <see cref="ArgumentException" />, when the given argument is not equals to the <c>expectedValue</c>.</summary>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="argument">The argument, which has to be checked.</param>
        /// <param name="argumentName">The argument name will be automatically detected by the <see cref="CallerArgumentExpressionAttribute"/>, so please do not enter any name, otherwise you will got the wrong parameter name.</param>
        /// <param name="expectedValue">The value which the argument must equals.</param>
        /// <returns>The given argument, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, if the argument is not equals to the <c>expectedValue</c>.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        public static T? IfNotEqualsTo<T>(T? argument, T? expectedValue, [CallerArgumentExpression("argument")] string argumentName = "")
        {
            if (argument.EqualsTo(expectedValue))
            {
                return argument;
            }

            throw new ArgumentException($"The argument value: '{argument}' is not equal to: '{expectedValue}'.", argumentName);
        }
    }
}
