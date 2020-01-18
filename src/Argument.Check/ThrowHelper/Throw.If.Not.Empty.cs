using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Argument.Check.Extensions;

namespace Argument.Check
{
    /// <summary>Provides a set of static methods to validate your arguments.</summary>
    public static partial class Throw
    {
        /// <summary>Throws an <see cref="ArgumentException" />, when the given argument string is not empty.</summary>
        /// <param name="argumentFunc">A function, which returns the string to validate.</param>
        /// <returns>The given argument, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, if the argument is not empty.</exception>
        [DebuggerHidden]
        public static string IfNotEmpty(Func<string> argumentFunc)
        {
            IfNull(() => argumentFunc);
            IfNull(argumentFunc);


            var argument = argumentFunc();
            if (argument.IsEmpty())
            {
                return argument;
            }

            throw new ArgumentException("The string must be empty.", argumentFunc.GetParameterName());
        }

        /// <summary>Throws an <see cref="ArgumentException" />, when the given sequence is not empty.</summary>
        /// <param name="argumentFunc">A function, which returns the sequence to validate.</param>
        /// <returns>The given sequence, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, if the sequence is not empty.</exception>
        [DebuggerHidden]
        public static IEnumerable<T> IfNotEmpty<T>(Func<IEnumerable<T>> argumentFunc)
        {
            IfNull(() => argumentFunc);
            IfNull(argumentFunc);

            var argument = argumentFunc();
            if (argument.IsEmpty())
            {
                return argument;
            }

            throw new ArgumentException("The enumerable must be empty.", argumentFunc.GetParameterName());
        }
    }
}
