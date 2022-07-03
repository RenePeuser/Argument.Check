using System;
#if !DEBUG
using System.Diagnostics;
#endif
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Argument.Check
{
    /// <summary>Provides a set of static methods to validate your arguments.</summary>
    public static partial class Throw
    {
        /// <summary>Throws an <see cref="ArgumentException" />, when the given string is <c>null</c>, whitespace or empty.</summary>
        /// <param name="argumentFunc">A function, which returns the string to validate.</param>
        /// <returns>The given sequence, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, when the given string is <c>null</c>, whitespace or empty.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        [Obsolete("This method is obsolete use the new version without func to check your arguments  Throw.IfNullOrWhiteSpace(myArgument)", false)]
        public static string IfNullOrWhiteSpace([NotNull] Func<string> argumentFunc)
        {
            IfNull(argumentFunc);
            IfEmpty(argumentFunc);
            IfWhitespace(argumentFunc);

            return argumentFunc();
        }


        /// <summary>Throws an <see cref="ArgumentException" />, when the given string is <c>null</c>, whitespace or empty.</summary>
        /// <param name="argument">The argument, which has to be checked.</param>
        /// <param name="argumentName">The argument name will be automatically detected by the <see cref="CallerArgumentExpressionAttribute"/>, so please do not enter any name, otherwise you will got the wrong parameter name.</param>
        /// <returns>The given sequence, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, when the given string is <c>null</c>, whitespace or empty.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        public static string IfNullOrWhiteSpace([NotNull] string? argument, [CallerArgumentExpression("argument")] string argumentName = "")
        {
            IfNull(argument, argumentName);
            IfEmpty(argument, argumentName);
            IfWhitespace(argument, argumentName);

            return argument;
        }
    }
}
