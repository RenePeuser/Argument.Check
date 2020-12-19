using System;
#pragma warning disable IDE0005 // It is used by the precompiler switch release !!
using System.Diagnostics;
#pragma warning restore IDE0005 // It is used by the precompiler switch release !!
using System.Runtime.CompilerServices;
using Argument.Check.Extensions;

namespace Argument.Check
{
    /// <summary>Provides a set of static methods to validate your arguments.</summary>
    public partial class Throw
    {
        /// <summary>Throws an <see cref="ArgumentOutOfRangeException" />, when the given argument is out of range of <c>min</c> and <c>max</c>.</summary>
        /// <typeparam name="T">The type of the argument, which must be a type of <see cref="IComparable" />"/>.</typeparam>
        /// <param name="argumentFunc">A function, which returns the string to validate.</param>
        /// <param name="min">The minimum of the valid range.</param>
        /// <param name="max">The maximum of the valid range.</param>
        /// <returns>The given argument, which was checked.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The exception, which will be thrown, when the given argument is out of range of <c>min</c> and <c>max</c>.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        [Obsolete("This method is obsolete use the new version without func to check your arguments  Throw.IfOutOfRange(myArgument, myMin, myMax)", false)]
        public static T IfOutOfRange<T>(Func<T> argumentFunc, T min, T max) where T : IComparable
        {
            IfNull(() => argumentFunc);

            var argument = argumentFunc();
            if (!argument.IsOutOfRange(min, max))
            {
                return argument;
            }

            throw new ArgumentOutOfRangeException(argumentFunc.GetParameterName(arg => arg is T t && t.IsOutOfRange(min, max)), $"Value: '{argument}' is not in expected range from '{min}' to '{max}'.");
        }

        /// <summary>Throws an <see cref="ArgumentOutOfRangeException" />, when the given argument is out of range of <c>min</c> and <c>max</c>.</summary>
        /// <typeparam name="T">The type of the argument, which must be a type of <see cref="IComparable" />"/>.</typeparam>
        /// <param name="argument">The argument, which has to be checked.</param>
        /// <param name="argumentName">The argument name will be automatically detected by the <see cref="CallerArgumentExpressionAttribute"/>, so please do not enter any name, otherwise you will got the wrong parameter name.</param>
        /// <param name="min">The minimum of the valid range.</param>
        /// <param name="max">The maximum of the valid range.</param>
        /// <returns>The given argument, which was checked.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The exception, which will be thrown, when the given argument is out of range of <c>min</c> and <c>max</c>.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        public static T IfOutOfRange<T>(T argument, T min, T max, [CallerArgumentExpression("argument")] string argumentName = default!) where T : IComparable
        {
            if (!argument.IsOutOfRange(min, max))
            {
                return argument;
            }

            throw new ArgumentOutOfRangeException(argumentName, $"Value: '{argument}' is not in expected range from '{min}' to '{max}'.");
        }
    }
}
