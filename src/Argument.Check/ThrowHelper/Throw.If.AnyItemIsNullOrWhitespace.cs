using System;
using System.Collections.Generic;
using System.Diagnostics;
using Argument.Check.Extensions;

namespace Argument.Check
{
    /// <summary>Provides a set of static methods to validate your arguments.</summary>
    public partial class Throw
    {
        /// <summary>Throws an <see cref="ArgumentException" />, when any item of the given sequence is null, empty or whitespace.</summary>
        /// <param name="argumentFunc">A function, which returns the sequence to validate.</param>
        /// <returns>The given sequence, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, if the argument is not valid.</exception>
        [DebuggerHidden]
        public static IEnumerable<string> IfAnyItemIsNullOrWhitespace(Func<IEnumerable<string>> argumentFunc)
        {
            IfNull(() => argumentFunc);
            IfNull(argumentFunc);

            var argument = argumentFunc();
            if (!argument.IsAnyItemNullOrWhitespace())
            {
                return argument;
            }

            throw new ArgumentException($"At least one string in the enumeration '{string.Join(",", argument)}' was null or a whitespace.", argumentFunc.GetParameterName());
        }
    }
}
