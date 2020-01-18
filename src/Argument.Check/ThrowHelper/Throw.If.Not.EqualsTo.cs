using System;
using System.Diagnostics;
using Argument.Check.Extensions;

namespace Argument.Check
{
    /// <summary>Provides a set of static methods to validate your arguments.</summary>
    public partial class Throw
    {
        /// <summary>Throws an <see cref="ArgumentException" />, when the given argument is not equals to the <c>expectedValue</c>.</summary>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="argumentFunc">A function, which returns the string to validate.</param>
        /// <param name="expectedValue">The value which the argument must equals.</param>
        /// <returns>The given argument, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, if the argument is not equals to the <c>expectedValue</c>.</exception>
        // [DebuggerHidden]
        public static T IfNotEqualsTo<T>(Func<T> argumentFunc, T expectedValue)
        {
            IfNull(() => argumentFunc);

            var argument = argumentFunc();
            if (!argument.NotEqualsTo(expectedValue))
            {
                return argument;
            }

            throw new ArgumentException(
                $"The argument value: '{argument}' is not equal to: '{expectedValue}'.", argumentFunc.GetParameterName());
        }
    }
}
