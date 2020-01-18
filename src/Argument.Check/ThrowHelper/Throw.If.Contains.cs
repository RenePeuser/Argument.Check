using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Argument.Check.Extensions;

namespace Argument.Check
{
    /// <summary>Provides a set of static methods to validate your arguments.</summary>
    public partial class Throw
    {
        /// <summary>Throws an <see cref="ArgumentException" />, when the given argument is part of the given sequence <c>source</c>.</summary>
        /// <typeparam name="T">The type of the argument, which must be a type of <see cref="IComparable" />"/>.</typeparam>
        /// <param name="argumentFunc">A function, which returns the string to validate.</param>
        /// <param name="source">The sequence which should contains the given argument.</param>
        /// <returns>The given argument, which was checked.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The exception, which will be thrown, if the given argument is part of the given sequence <c>source</c>.</exception>
        // [DebuggerHidden]
        public static T IfContains<T>(Func<T> argumentFunc, IEnumerable<T> source)
        {
            IfNull(() => argumentFunc);
            IfNull(() => source);

            var argument = argumentFunc();
            if (source.Contains(argument).IsFalse())
            {
                return argument;
            }

            throw new ArgumentException($"The argument '{argument}' is contained in the enumeration.", argumentFunc.GetParameterName());
        }
    }
}
