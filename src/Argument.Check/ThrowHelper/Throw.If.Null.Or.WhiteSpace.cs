using System;
using System.Diagnostics;

namespace Argument.Check
{
    /// <summary>Provides a set of static methods to validate your arguments.</summary>
    public static partial class Throw
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/>, when the given string is <c>null</c>, whitespace or empty.
        /// </summary>
        /// <param name="argumentFunc">A function, which returns the string to validate.</param>
        /// <returns>The given sequence, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, when the given string is <c>null</c>, whitespace or empty.</exception>
        [DebuggerHidden]
        public static string IfNullOrWhiteSpace(Func<string> argumentFunc)
        {
            Throw.IfNull(() => argumentFunc);
            Throw.IfNull(argumentFunc);
            Throw.IfEmpty(argumentFunc);
            Throw.IfWhitespace(argumentFunc);

            return argumentFunc();
        }
    }
}
