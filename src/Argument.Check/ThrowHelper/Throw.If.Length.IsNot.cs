using System;
using System.Diagnostics;
using Argument.Check.Extensions;

namespace Argument.Check
{
    /// <summary>Provides a set of static methods to validate your arguments.</summary>
    public static partial class Throw
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/>, when the given string has not an expected length of <see cref="length"/>.
        /// </summary>
        /// <param name="argumentFunc">A function, which returns the string to validate.</param>
        /// <param name="length">The length which the string argument must have.</param>
        /// <returns>The given string, which was checked.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The exception, which will be thrown, if the given string has not an expected length of <see cref="length"/>.</exception>
        [DebuggerHidden]
        public static string IfLengthIsNot(Func<string> argumentFunc, int length)
        {
            IfNull(() => argumentFunc);
            IfNull(argumentFunc);

            var argument = argumentFunc();
            if (!argument.Length.NotEqualsTo(length))
            {
                return argument;
            }

            throw new ArgumentOutOfRangeException(argumentFunc.GetParameterName(Predicate), $"String length: '{argument}' is not as expected. Expected value: '{length}'.");

            bool Predicate(object arg)
            {
                return arg.Is<string>() && arg.Cast<string>().Length.NotEqualsTo(length);
            }
        }
    }
}
