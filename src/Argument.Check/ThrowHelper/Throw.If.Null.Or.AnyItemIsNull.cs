using System;
using System.Collections.Generic;
#if !DEBUG
using System.Diagnostics;
#endif
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Argument.Check.Extensions;

namespace Argument.Check
{
    /// <summary>Provides a set of static methods to validate your arguments.</summary>
    public partial class Throw
    {
        /// <summary>Throws an <see cref="ArgumentException" />, when the given sequence is <c>null</c> or any item of the sequence is null.</summary>
        /// <param name="argument">The argument, which has to be checked.</param>
        /// <param name="argumentName">The argument name will be automatically detected by the <see cref="CallerArgumentExpressionAttribute"/>, so please do not enter any name, otherwise you will got the wrong parameter name.</param>
        /// <returns>The given sequence, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, when the given sequence is <c>null</c> or any item of the sequence is null.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        public static IEnumerable<T> IfNullOrAnyItemIsNull<T>([NotNull] IEnumerable<T?>? argument, [CallerArgumentExpression("argument")] string argumentName = "")
        {
            IfNull(argument);

            if (!argument.IsAnyItemNull())
            {
                return argument!;
            }

            throw new ArgumentNullException(argumentName, $"At least one item in the enumeration '{argumentName}' was null.");
        }
    }
}
