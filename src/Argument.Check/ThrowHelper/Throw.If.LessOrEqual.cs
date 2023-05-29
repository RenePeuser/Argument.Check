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
        /// <summary>Throws an <see cref="ArgumentException" />, when the given argument is equals or less than the <c>limit</c>.</summary>
        /// <typeparam name="T">The type of the argument, which must be a type of <see cref="IComparable" />"/>.</typeparam>
        /// <param name="argument">The argument, which has to be checked.</param>
        /// <param name="argumentName">The argument name will be automatically detected by the <see cref="CallerArgumentExpressionAttribute"/>, so please do not enter any name, otherwise you will got the wrong parameter name.</param>
        /// <param name="limit">The limit for the expected value.</param>
        /// <returns>The given argument, which was checked.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The exception, which will be thrown, if the given argument is equals or less than the <c>limit</c>.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        public static T IfLessOrEqual<T>(T argument, T limit, [CallerArgumentExpression(nameof(argument))] string argumentName = "") where T : IComparable
        {
            if (!argument.IsLessOrEqual(limit))
            {
                return argument;
            }

            throw new ArgumentOutOfRangeException(argumentName, $"Value: '{argument}' must not be less than or equal to: '{limit}'.");
        }
    }
}
