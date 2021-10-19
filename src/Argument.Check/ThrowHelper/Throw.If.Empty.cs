using System;
using System.Collections.Generic;
#pragma warning disable IDE0005 // It is used by the precompiler switch release !!
using System.Diagnostics;
#pragma warning restore IDE0005 // It is used by the precompiler switch release !!
using System.Linq;
using System.Runtime.CompilerServices;
using Argument.Check.Extensions;

namespace Argument.Check
{
    /// <summary>Provides a set of static methods to validate your arguments.</summary>
    public static partial class Throw
    {
        /// <summary>Throws an <see cref="ArgumentException" />, when the given argument string is empty.</summary>
        /// <param name="argumentFunc">A function, which returns the string to validate.</param>
        /// <returns>The given argument, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, if the argument is not valid.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        [Obsolete("This method is obsolete use the new version without func to check your arguments  Throw.IfEmpty(myArgument)", false)]
        public static string IfEmpty(Func<string> argumentFunc)
        {
            IfNull(() => argumentFunc);
            IfNull(argumentFunc);


            var argument = argumentFunc();
            if (!argument.IsEmpty())
            {
                return argument;
            }

            throw new ArgumentException("The string must not be empty.", argumentFunc.GetParameterName(arg => arg.Is<string>() && arg.Cast<string>().IsEmpty()));
        }

        /// <summary>Throws an <see cref="ArgumentException" />, when the given sequence is empty.</summary>
        /// <param name="argumentFunc">A function, which returns the sequence to validate.</param>
        /// <returns>The given sequence, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, if the sequence is not valid.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        [Obsolete("This method is obsolete use the new version without func to check your arguments  Throw.IfEmpty(mySequence)", false)]
        public static IEnumerable<T> IfEmpty<T>(Func<IEnumerable<T>> argumentFunc)
        {
            IfNull(() => argumentFunc);
            IfNull(argumentFunc);

            var argument = argumentFunc();
            if (argument.Any())
            {
                return argument;
            }

            throw new ArgumentException("The enumerable must not be empty.", argumentFunc.GetParameterName(arg => arg.Is<IEnumerable<T>>() && arg.Cast<IEnumerable<T>>().IsEmpty()));
        }

        /// <summary>Throws an <see cref="ArgumentException" />, when the given argument string is empty.</summary>
        /// <param name="argument">The argument, which has to be checked.</param>
        /// <param name="argumentName">The argument name will be automatically detected by the <see cref="CallerArgumentExpressionAttribute"/>, so please do not enter any name, otherwise you will got the wrong parameter name.</param>
        /// <returns>The given argument, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, if the argument is not valid.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        public static string IfEmpty(string argument, [CallerArgumentExpression("argument")] string argumentName = "")
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
        public static IEnumerable<T> IfEmpty<T>(IEnumerable<T> argument, [CallerArgumentExpression("argument")] string argumentName = "")
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
