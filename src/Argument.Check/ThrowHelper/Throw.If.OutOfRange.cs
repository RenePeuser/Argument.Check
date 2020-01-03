using System;
using System.Diagnostics;
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
        [DebuggerHidden]
        public static T IfOutOfRange<T>(Func<T> argumentFunc, T min, T max) where T : IComparable
        {
            IfNull(() => argumentFunc);

            var argument = argumentFunc();
            if (!argument.IsOutOfRange(min, max))
            {
                return argument;
            }

            throw new ArgumentOutOfRangeException(argumentFunc.GetParameterName(Predicate), $"Value: '{argument}' is not in expected range from '{min}' to '{max}'.");

            bool Predicate(object arg)
            {
                return arg is T && ((T) arg).IsOutOfRange(min, max);
            }
        }
    }
}
