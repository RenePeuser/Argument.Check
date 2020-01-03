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
        /// <summary>
        /// Throws an <see cref="ArgumentException"/>, when the given sequence is <c>null</c> or any item match the given <c>predicate</c>.
        /// </summary>
        /// <param name="argumentFunc">A function, which returns the sequence to validate.</param>
        /// <param name="predicate">A function which checks the argument, if it is valid or not.</param>
        /// <returns>The given sequence, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, when the given sequence is <c>null</c> or any item match the given <c>predicate</c>.</exception>
        [DebuggerHidden]
        public static IEnumerable<T> IfNullOrAny<T>(Func<IEnumerable<T>> argumentFunc, Func<T, bool> predicate)
        {
            Throw.IfNull(() => argumentFunc);
            Throw.IfNull(() => predicate);

            var argument = argumentFunc();
            if (!argument.Any(predicate))
            {
                return argument;
            }

            throw new ArgumentException($"The sequence must not contain any items that satisfy the given predicate: '{predicate.Method.Name}'.", argumentFunc.GetParameterName(x => x.Is<IEnumerable<T>>() && x.Cast<IEnumerable<T>>().Any(predicate)));
        }
    }
}
