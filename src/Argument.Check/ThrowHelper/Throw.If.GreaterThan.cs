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
        /// <summary>Throws an <see cref="ArgumentException" />, when the given argument is greater than the <c>limit</c>.</summary>
        /// <typeparam name="T">The type of the argument, which must be a type of <see cref="IComparable" />"/>.</typeparam>
        /// <param name="argumentFunc">A function, which returns the string to validate.</param>
        /// <param name="limit">The limit for the expected value.</param>
        /// <returns>The given argument, which was checked.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The exception, which will be thrown, if the argument is greater than the <c>limit</c>.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        [Obsolete("This method is obsolete use the new version without func to check your arguments  Throw.IfGreaterThan(myValue, myLimit)", false)]
        public static T IfGreaterThan<T>(Func<T> argumentFunc, T limit) where T : IComparable
        {
            IfNull(() => argumentFunc);

            var argument = argumentFunc();
            if (!argument.IsGreaterThan(limit))
            {
                return argument;
            }

            throw new ArgumentOutOfRangeException(argumentFunc.GetParameterName(Predicate), $"Value: '{argument}' must not be greater than: '{limit}'.");

            bool Predicate(object arg)
            {
                return arg is T comparable && comparable.IsGreaterThan(limit);
            }
        }

        /// <summary>Throws an <see cref="ArgumentException" />, when the given argument is greater than the <c>limit</c>.</summary>
        /// <typeparam name="T">The type of the argument, which must be a type of <see cref="IComparable" />"/>.</typeparam>
        /// <param name="argument">The argument, which has to be checked.</param>
        /// <param name="argumentName">The argument name will be automatically detected by the <see cref="CallerArgumentExpressionAttribute"/>, so please do not enter any name, otherwise you will got the wrong parameter name.</param>
        /// <param name="limit">The limit for the expected value.</param>
        /// <returns>The given argument, which was checked.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The exception, which will be thrown, if the argument is greater than the <c>limit</c>.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        public static T IfGreaterThan<T>(T argument, T limit, [CallerArgumentExpression("argument")] string argumentName = "") where T : IComparable
        {
            if (!argument.IsGreaterThan(limit))
            {
                return argument;
            }

            throw new ArgumentOutOfRangeException(argumentName, $"Value: '{argument}' must not be greater than: '{limit}'.");
        }
    }
}