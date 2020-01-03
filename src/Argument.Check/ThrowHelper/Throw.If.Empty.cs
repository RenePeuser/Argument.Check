using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Argument.Check.Extensions;

namespace Argument.Check
{
    public static partial class Throw
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/>, when the given argument string is empty.
        /// </summary>
        /// <param name="argumentFunc">A function, which returns the string to validate.</param>
        /// <returns>The given argument, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, if the argument is not valid.</exception>
        [DebuggerHidden]
        public static string IfEmpty(Func<string> argumentFunc)
        {
            IfNull(() => argumentFunc);
            IfNull(argumentFunc);


            var argument = argumentFunc();
            if (!argument.IsEmpty())
            {
                return argument;
            }

            throw new ArgumentException("The string must not be empty.", argumentFunc.GetParameterName(arg => arg.Is<string>() && arg.Cast<string>().IsEmpty()));
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/>, when the given sequence is empty.
        /// </summary>
        /// <param name="argumentFunc">A function, which returns the sequence to validate.</param>
        /// <returns>The given sequence, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, if the sequence is not valid.</exception>
        [DebuggerHidden]
        public static IEnumerable<T> IfEmpty<T>(Func<IEnumerable<T>> argumentFunc)
        {
            IfNull(() => argumentFunc);
            IfNull(argumentFunc);

            var argument = argumentFunc();
            if (argument.Any())
            {
                return argument;
            }

            throw new ArgumentException("The enumerable must not be empty.", argumentFunc.GetParameterName(arg => arg.Is<IEnumerable<T>>() && arg.Cast<IEnumerable<T>>().IsEmpty()));
        }
    }
}
