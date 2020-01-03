using System;
using System.Diagnostics;
using Argument.Check.Extensions;

namespace Argument.Check
{
    /// <summary>Provides a set of static methods to validate your arguments.</summary>
    public partial class Throw
    {   
        /// <summary>
        /// Throws an <see cref="ArgumentException"/>, when <see cref="validationPredicate"/> is <c>true</c>.
        /// </summary>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="argumentFunc">A function, which returns the argument to validate.</param>
        /// <param name="validationPredicate">A function which checks the argument, if it is valid or not.</param>
        /// <returns>The given argument, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, if the argument is not valid.</exception>
        [DebuggerHidden]
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

        /// <summary>
        /// Throws an <see cref="ArgumentException"/>, when <see cref="validationPredicate"/> is <c>true</c>.
        /// </summary>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="argumentFunc">A function, which returns the argument to validate.</param>
        /// <param name="validationPredicate">A function which checks the argument, if it is valid or not.</param>
        /// <param name="exceptionMessage">The exception exceptionMessage which should be shown, if argument was not valid.</param>
        /// <returns>The given argument, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, if the argument is not valid.</exception>
        [DebuggerHidden]
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
    }
}
