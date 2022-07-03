using System;
using System.Collections.Generic;
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
        /// <summary>Throws an <see cref="ArgumentException" />, when any item of the given sequence is null, empty or whitespace.</summary>
        /// <param name="argumentFunc">A function, which returns the sequence to validate.</param>
        /// <returns>The given sequence, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, if the argument is not valid.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        [Obsolete("This method is obsolete use the new version without func to check your arguments  Throw.IfAnyItemIsNullOrWhitespace(myArgument)", false)]
        public static IEnumerable<string> IfAnyItemIsNullOrWhitespace(Func<IEnumerable<string>> argumentFunc)
        {
            IfNull(() => argumentFunc);
            IfNull(argumentFunc);

            var argument = argumentFunc();
            if (argument.IsAnyItemNullOrWhitespace().IsFalse())
            {
                return argument;
            }

            throw new ArgumentException($"At least one string in the enumeration '{string.Join(",", argument)}' was null or a whitespace.", argumentFunc.GetParameterName(arg => arg.Is<IEnumerable<string>>() && arg.Cast<IEnumerable<string>>().IsAnyItemNullOrWhitespace()));
        }

        /// <summary>Throws an <see cref="ArgumentException" />, when any item of the given sequence is null, empty or whitespace.</summary>
        /// <param name="argument">The argument, which has to be checked.</param>
        /// <param name="argumentName">The parameter name will be automatically detected by the <see cref="CallerArgumentExpressionAttribute"/>, so please do not enter any name, otherwise you will got the wrong parameter name.</param>
        /// <returns>The given sequence, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, if the argument is not valid.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        public static IEnumerable<string> IfAnyItemIsNullOrWhitespace(IEnumerable<string> argument, [CallerArgumentExpression("argument")] string argumentName = "")
        {
            IfNull(argument);

            if (argument.IsAnyItemNullOrWhitespace().IsFalse())
            {
                return argument;
            }

            throw new ArgumentException($"At least one string in the enumeration '{string.Join(",", argument)}' was null or a whitespace.", argumentName);
        }
    }
}
