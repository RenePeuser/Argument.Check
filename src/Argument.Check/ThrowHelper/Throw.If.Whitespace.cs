using System;
#pragma warning disable IDE0005 // It is used by the precompiler switch release !!
using System.Diagnostics;
#pragma warning restore IDE0005 // It is used by the precompiler switch release !!
using System.Runtime.CompilerServices;
using Argument.Check.Extensions;

namespace Argument.Check
{
    /// <summary>Provides a set of static methods to validate your arguments.</summary>
    public static partial class Throw
    {
        /// <summary>Throws an <see cref="ArgumentException" />, when the given argument string is whitespace.</summary>
        /// <param name="argumentFunc">A function, which returns the string to validate.</param>
        /// <returns>The given argument, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, when the given argument string is whitespace.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        [Obsolete("This method is obsolete use the new version without func to check your arguments  Throw.IfWhitespace(myArgument)", false)]
        public static string IfWhitespace(Func<string> argumentFunc)
        {
            IfNull(() => argumentFunc);
            IfNull(argumentFunc);

            var argument = argumentFunc();

            if (!argument.IsNullOrWhiteSpace())
            {
                return argument;
            }

            throw new ArgumentException("The string must not be only whitespace.", argumentFunc.GetParameterName(arg => arg.Is<string>() && arg.Cast<string>().IsWhitespace()));
        }


        /// <summary>Throws an <see cref="ArgumentException" />, when the given argument string is whitespace.</summary>
        /// <param name="argument">The argument, which has to be checked.</param>
        /// <param name="argumentName">The argument name will be automatically detected by the <see cref="CallerArgumentExpressionAttribute"/>, so please do not enter any name, otherwise you will got the wrong parameter name.</param>
        /// <returns>The given argument, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, when the given argument string is whitespace.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        public static string IfWhitespace(string argument, [CallerArgumentExpression("argument")] string argumentName = default!)
        {
            IfNull(argument);

            if (!argument.IsNullOrWhiteSpace())
            {
                return argument;
            }

            throw new ArgumentException("The string must not be only whitespace.", argumentName);
        }
    }
}
