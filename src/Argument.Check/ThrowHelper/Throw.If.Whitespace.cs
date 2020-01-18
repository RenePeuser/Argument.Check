using System;
using System.Diagnostics;
using Argument.Check.Extensions;

namespace Argument.Check
{
    /// <summary>Provides a set of static methods to validate your arguments.</summary>
    public static partial class Throw
    {
        /// <summary>Throws an <see cref="ArgumentException" />, when the given argument string is whitespace.</summary>
        /// <param name="argumentFunc">A function, which returns the string to validate.</param>
        /// <returns>The given argument, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, when the given argument string is whitespace.</exception>
        // [DebuggerHidden]
        public static string IfWhitespace(Func<string> argumentFunc)
        {
            IfNull(() => argumentFunc);
            IfNull(argumentFunc);

            var argument = argumentFunc();

            if (!argument.IsNullOrWhiteSpace())
            {
                return argument;
            }

            throw new ArgumentException("The string must not be only whitespace.", argumentFunc.GetParameterName());
        }
    }
}
