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
        /// <summary>Throws an <see cref="ArgumentException" />, when validation predicate is <c>true</c>.</summary>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="argument">The argument, which has to be checked.</param>
        /// <param name="argumentName">The argument name will be automatically detected by the <see cref="CallerArgumentExpressionAttribute"/>, so please do not enter any name, otherwise you will got the wrong parameter name.</param>
        /// <param name="validationPredicate">A function which checks the argument, if it is valid or not.</param>
        /// <param name="exceptionMessage">The exception exceptionMessage which should be shown, if argument was not valid.</param>
        /// <returns>The given argument, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, if the argument is not valid.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        public static T If<T>(T? argument, Func<T?, bool> validationPredicate, string exceptionMessage, [CallerArgumentExpression("argument")] string argumentName = "")
        {
            IfNull<object>(argument);
            IfNull(validationPredicate);

            var isMatching = validationPredicate(argument);
            if (isMatching.IsFalse())
            {
                return argument;
            }

            throw new ArgumentException(exceptionMessage, argumentName);
        }
    }
}
