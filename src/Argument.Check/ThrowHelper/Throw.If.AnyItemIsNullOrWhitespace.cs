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
        /// <param name="argument">The argument, which has to be checked.</param>
        /// <param name="argumentName">The parameter name will be automatically detected by the <see cref="CallerArgumentExpressionAttribute"/>, so please do not enter any name, otherwise you will got the wrong parameter name.</param>
        /// <returns>The given sequence, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, if the argument is not valid.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        public static IEnumerable<string> IfAnyItemIsNullOrWhitespace(IEnumerable<string?>? argument, [CallerArgumentExpression(nameof(argument))] string argumentName = "")
        {
            var checkedArgument = Throw.IfNull(argument);

            if (checkedArgument!.IsAnyItemNullOrWhitespace().IsFalse())
            {
                return checkedArgument!;
            }

            throw new ArgumentException($"At least one string in the enumeration '{string.Join(",", argument)}' was null or a whitespace.", argumentName);
        }
    }
}
