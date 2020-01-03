using System;
using System.Collections.Generic;
using System.Diagnostics;
using Argument.Check.Extensions;

namespace Argument.Check
{
    /// <summary>Provides a set of static methods to validate your arguments.</summary>
    public partial class Throw
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/>, when the given sequence is <c>null</c> or any item of the sequence is null.
        /// </summary>
        /// <param name="argumentFunc">A function, which returns the sequence to validate.</param>
        /// <returns>The given sequence, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, when the given sequence is <c>null</c> or any item of the sequence is null.</exception>
        [DebuggerHidden]
        public static IEnumerable<T> IfNullOrAnyItemIsNull<T>(Func<IEnumerable<T>> argumentFunc)
        {
            Throw.IfNull(() => argumentFunc);
            Throw.IfNull(argumentFunc);

            var argument = argumentFunc();
            if (!argument.IsAnyItemNull())
            {
                return argument;
            }

            throw new ArgumentNullException(argumentFunc.GetParameterName(Predicate), $"At least one item in the enumeration '{argumentFunc()}' was null.");

            bool Predicate(object arg)
            {
                return arg.Is<IEnumerable<T>>() && arg.Cast<IEnumerable<T>>().IsAnyItemNull();
            }
        }
    }
}
