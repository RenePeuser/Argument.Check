using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Argument.Check
{
    /// <summary>Provides a set of static methods to validate your arguments.</summary>
    public static partial class Throw
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/>, when the given string is <c>null</c> or empty.
        /// </summary>
        /// <param name="argumentFunc">A function, which returns the sequence to validate.</param>
        /// <returns>The given sequence, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, when the given string is <c>null</c> or empty.</exception>
        [DebuggerHidden]
        public static string IfNullOrEmpty(Func<string> argumentFunc)
        {
            Throw.IfNull(() => argumentFunc);
            Throw.IfNull(argumentFunc);
            Throw.IfEmpty(argumentFunc);

            return argumentFunc();
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/>, when the given sequence is <c>null</c> or empty.
        /// </summary>
        /// <param name="argumentFunc">A function, which returns the sequence to validate.</param>
        /// <returns>The given sequence, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, when the given sequence is <c>null</c> or empty.</exception>
        [DebuggerHidden]
        public static IEnumerable<T> IfNullOrEmpty<T>(Func<IEnumerable<T>> argumentFunc)
        {
            Throw.IfNull(() => argumentFunc);
            Throw.IfNull(argumentFunc);
            Throw.IfEmpty(argumentFunc);

            return argumentFunc();
        }
    }
}
