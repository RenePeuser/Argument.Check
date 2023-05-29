using System;
using System.Collections.Generic;
#if !DEBUG
using System.Diagnostics;
#endif
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Argument.Check
{
    /// <summary>Provides a set of static methods to validate your arguments.</summary>
    public partial class Throw
    {
        /// <summary>Throws an <see cref="ArgumentException" />, when the given sequence is <c>null</c> or any item match the given <c>predicate</c>.</summary>
        /// <param name="argument">The argument, which has to be checked.</param>
        /// <param name="argumentName">The argument name will be automatically detected by the <see cref="CallerArgumentExpressionAttribute"/>, so please do not enter any name, otherwise you will got the wrong parameter name.</param>
        /// <param name="predicate">A function which checks the argument, if it is valid or not.</param>
        /// <returns>The given sequence, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, when the given sequence is <c>null</c> or any item match the given <c>predicate</c>.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        public static IEnumerable<T> IfNullOrAny<T>([NotNull] IEnumerable<T?>? argument, Func<T?, bool> predicate, [CallerArgumentExpression(nameof(argument))] string argumentName = "")
        {
            var checkArguments = IfNull(argument);
            IfNull(predicate);

            if (!checkArguments.Any(predicate))
            {
                return checkArguments!;
            }

            throw new ArgumentException($"The sequence must not contain any items that satisfy the given predicate: '{predicate.Method.Name}'.", argumentName);
        }
    }
}
