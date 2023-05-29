using System;
using System.Collections.Generic;
#if !DEBUG
using System.Diagnostics;
#endif
using System.Linq;
using System.Runtime.CompilerServices;
using Argument.Check.Extensions;

namespace Argument.Check
{
    /// <summary>Provides a set of static methods to validate your arguments.</summary>
    public static partial class Throw
    {
        /// <summary>Throws an <see cref="ArgumentException" />, when the given argument string is empty.</summary>
        /// <param name="argument">The argument, which has to be checked.</param>
        /// <param name="argumentName">The argument name will be automatically detected by the <see cref="CallerArgumentExpressionAttribute"/>, so please do not enter any name, otherwise you will got the wrong parameter name.</param>
        /// <returns>The given argument, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, if the argument is not valid.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        public static string IfEmpty(string argument, [CallerArgumentExpression(nameof(argument))] string argumentName = "")
        {
            IfNull(argument);

            if (!argument.IsEmpty())
            {
                return argument;
            }

            throw new ArgumentException("The string must not be empty.", argumentName);
        }

        /// <summary>Throws an <see cref="ArgumentException" />, when the given sequence is empty.</summary>
        /// <param name="argument">The argument, which has to be checked.</param>
        /// <param name="argumentName">The argument name will be automatically detected by the <see cref="CallerArgumentExpressionAttribute"/>, so please do not enter any name, otherwise you will got the wrong parameter name.</param>
        /// <returns>The given sequence, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, if the sequence is not valid.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        public static IEnumerable<T> IfEmpty<T>(IEnumerable<T> argument, [CallerArgumentExpression(nameof(argument))] string argumentName = "")
        {
            IfNull(argument);

            if (argument.Any())
            {
                return argument;
            }

            throw new ArgumentException("The enumerable must not be empty.", argumentName);
        }

    }
}
