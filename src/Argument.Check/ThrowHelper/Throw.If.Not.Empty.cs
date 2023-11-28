#if !DEBUG
using System.Diagnostics;
#endif
using System.Runtime.CompilerServices;
using Argument.Check.Extensions;

namespace Argument.Check
{
    /// <summary>Provides a set of static methods to validate your arguments.</summary>
    public static partial class Throw
    {
        /// <summary>Throws an <see cref="ArgumentException" />, when the given sequence is not empty.</summary>
        /// <param name="argumentFunc">A function, which returns the sequence to validate.</param>
        /// <returns>The given sequence, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, if the sequence is not empty.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        [Obsolete("This method is obsolete use the new version without func to check your arguments  Throw.IfNotEmpty(myArgument)", false)]
        public static IEnumerable<T> IfNotEmpty<T>(Func<IEnumerable<T>> argumentFunc)
        {
            IfNull(() => argumentFunc);
            IfNull(argumentFunc);

            var argument = argumentFunc();
            if (argument.IsEmpty())
            {
                return argument;
            }

            throw new ArgumentException("The enumerable must be empty.", argumentFunc.GetParameterName(arg => arg.Is<IEnumerable<T>>() && arg.Cast<IEnumerable<T>>().Any()));
        }


        /// <summary>Throws an <see cref="ArgumentException" />, when the given argument string is not empty.</summary>
        /// <param name="argument">The argument, which has to be checked.</param>
        /// <param name="argumentName">The argument name will be automatically detected by the <see cref="CallerArgumentExpressionAttribute"/>, so please do not enter any name, otherwise you will got the wrong parameter name.</param>
        /// <returns>The given argument, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, if the argument is not empty.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        public static string IfNotEmpty(string argument, [CallerArgumentExpression(nameof(argument))] string argumentName = "")
        {
            IfNull(argument);

            if (argument.IsEmpty())
            {
                return argument;
            }

            throw new ArgumentException("The string must be empty.", argumentName);
        }

        /// <summary>Throws an <see cref="ArgumentException" />, when the given sequence is not empty.</summary>
        /// <param name="argument">The argument, which has to be checked.</param>
        /// <param name="argumentName">The argument name will be automatically detected by the <see cref="CallerArgumentExpressionAttribute"/>, so please do not enter any name, otherwise you will got the wrong parameter name.</param>
        /// <returns>The given sequence, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, if the sequence is not empty.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        public static IEnumerable<T> IfNotEmpty<T>(IEnumerable<T> argument, [CallerArgumentExpression(nameof(argument))] string argumentName = "")
        {
            IfNull(argument);

            if (argument.IsEmpty())
            {
                return argument;
            }

            throw new ArgumentException("The enumerable must be empty.", argumentName);
        }
    }
}
