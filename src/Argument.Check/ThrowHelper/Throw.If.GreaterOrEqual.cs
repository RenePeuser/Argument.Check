using System;
using System.Diagnostics;
using Argument.Check.Extensions;

namespace Argument.Check
{
    /// <summary>Provides a set of static methods to validate your arguments.</summary>
    public partial class Throw
    {
        /// <summary>Throws an <see cref="ArgumentException" />, when the given argument is equals or greater than the <c>limit</c>.</summary>
        /// <typeparam name="T">The type of the argument, which must be a type of <see cref="IComparable" />"/>.</typeparam>
        /// <param name="argumentFunc">A function, which returns the string to validate.</param>
        /// <param name="limit">The limit for the expected value.</param>
        /// <returns>The given argument, which was checked.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The exception, which will be thrown, if the argument is equals or greater than the <c>limit</c>.</exception>
        [DebuggerHidden]
        public static T IfGreaterOrEqual<T>(Func<T> argumentFunc, T limit) where T : IComparable
        {
            IfNull(() => argumentFunc);

            var argument = argumentFunc();
            if (!argument.IsGreaterOrEqual(limit))
            {
                return argument;
            }

            throw new ArgumentOutOfRangeException(argumentFunc.GetParameterName(), $"Value: '{argument}' must not be greater than or equal to: '{limit}'.");
        }
    }
}
