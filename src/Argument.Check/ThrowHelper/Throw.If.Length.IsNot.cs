using System;
#if !DEBUG
using System.Diagnostics;
#endif
using System.Runtime.CompilerServices;
using Argument.Check.Extensions;

namespace Argument.Check
{
    /// <summary>Provides a set of static methods to validate your arguments.</summary>
    public static partial class Throw
    {
        /// <summary>Throws an <see cref="ArgumentException" />, when the given string has not an expected length of <c>length</c>.</summary>
        /// <param name="argument">The argument, which has to be checked.</param>
        /// <param name="argumentName">The argument name will be automatically detected by the <see cref="CallerArgumentExpressionAttribute"/>, so please do not enter any name, otherwise you will got the wrong parameter name.</param>
        /// <param name="length">The length which the string argument must have.</param>
        /// <returns>The given string, which was checked.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The exception, which will be thrown, if the given string has not an expected length of <c>length</c>.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        public static string IfLengthIsNot(string? argument, int length, [CallerArgumentExpression("argument")] string argumentName = "")
        {
            IfNull(argument);

            if (!argument.Length.NotEqualsTo(length))
            {
                return argument;
            }

            throw new ArgumentOutOfRangeException(argumentName, $"String length: '{argument}' is not as expected. Expected value: '{length}'.");
        }
    }
}
