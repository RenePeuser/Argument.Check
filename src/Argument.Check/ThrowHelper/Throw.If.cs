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
        /// <summary>Throws an <see cref="ArgumentException" />, when validation predicate is <c>true</c>.</summary>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="argumentFunc">A function, which returns the argument to validate.</param>
        /// <param name="validationPredicate">A function which checks the argument, if it is valid or not.</param>
        /// <returns>The given argument, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, if the argument is not valid.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        [Obsolete("This method is obsolete use the new version without func to check your arguments  Throw.If(myArgument, arg => arg.AnyCheck())", false)]
        public static T If<T>(Func<T> argumentFunc, Func<T, bool> validationPredicate)
        {
            IfNull(() => argumentFunc);
            IfNull(() => validationPredicate);

            var argument = argumentFunc();
            var isMatching = validationPredicate(argument);

            if (isMatching.IsFalse())
            {
                return argument;
            }

            throw new ArgumentException(string.Empty, argumentFunc.GetParameterName(arg => arg.EqualsTo(argument)));
        }

        /// <summary>Throws an <see cref="ArgumentException" />, when validation predicate is <c>true</c>.</summary>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="argumentFunc">A function, which returns the argument to validate.</param>
        /// <param name="validationPredicate">A function which checks the argument, if it is valid or not.</param>
        /// <param name="exceptionMessage">The exception exceptionMessage which should be shown, if argument was not valid.</param>
        /// <returns>The given argument, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, if the argument is not valid.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        [Obsolete("This method is obsolete use the new version without func to check your arguments  Throw.If(myArgument, arg => arg.AnyCheck(), 'Argument does not have to match my specific predicate')", false)]
        public static T If<T>(Func<T> argumentFunc, Func<T, bool> validationPredicate, string exceptionMessage)
        {
            IfNull(() => argumentFunc);
            IfNull(() => validationPredicate);

            var argument = argumentFunc();
            var isMatching = validationPredicate(argument);

            if (isMatching.IsFalse())
            {
                return argument;
            }

            throw new ArgumentException(exceptionMessage, argumentFunc.GetParameterName(arg => arg.EqualsTo(argument)));
        }

        /// <summary>Throws an <see cref="ArgumentException" />, when validation predicate is <c>true</c>.</summary>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="argument">The argument, which has to be checked.</param>
        /// <param name="argumentName">The argument name will be automatically detected by the <see cref="CallerArgumentExpressionAttribute"/>, so please do not enter any name, otherwise you will got the wrong parameter name.</param>
        /// <param name="validationPredicate">A function which checks the argument, if it is valid or not.</param>
        /// <param name="exceptionMessage">The exception exceptionMessage which should be shown, if argument was not valid.</param>
        /// <returns>The given argument, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, if the argument is not valid.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        public static T If<T>(T argument, Func<T, bool> validationPredicate, string exceptionMessage, [CallerArgumentExpression("argument")] string argumentName = "")
        {
            IfNull<object>(argument);
            IfNull(validationPredicate);

            var isMatching = validationPredicate(argument);
            if (isMatching.IsFalse())
            {
                return argument;
            }

            throw new ArgumentException(exceptionMessage, argumentName);
        }
    }
}
