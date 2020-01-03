using System;
using System.Diagnostics;
using Argument.Check.Extensions;

namespace Argument.Check
{
    /// <summary>Provides a set of static methods to validate your arguments.</summary>
    public partial class Throw
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/>, when the given argument is equals or less than the <see cref="limit"/>.
        /// </summary>
        /// <typeparam name="T">The type of the argument, which must be a type of <see cref="IComparable"/>"/>.</typeparam>
        /// <param name="argumentFunc">A function, which returns the string to validate.</param>
        /// <param name="limit">The limit for the expected value.</param>
        /// <returns>The given argument, which was checked.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The exception, which will be thrown, if the given argument is equals or less than the <see cref="limit"/>.</exception>
        [DebuggerHidden]
        public static T IfLessOrEqual<T>(Func<T> argumentFunc, T limit) where T : IComparable
        {
            IfNull(() => argumentFunc);

            var argument = argumentFunc();
            if (!argument.IsLessOrEqual(limit))
            {
                return argument;
            }

            throw new ArgumentOutOfRangeException(argumentFunc.GetParameterName(Predicate), $"Value: '{argument}' must not be less than or equal to: '{limit}'.");

            bool Predicate(object arg)
            {
                return arg is T && ((T) arg).IsLessOrEqual(limit);
            }
        }
    }
}
