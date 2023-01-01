using System;
using System.Collections.Generic;
#if !DEBUG
using System.Diagnostics;
#endif
using System.Linq;
using System.Runtime.CompilerServices;
using Argument.Check.Extensions;

namespace Argument.Check
{
    /// <summary>Provides a set of static methods to validate your arguments.</summary>
    public partial class Throw
    {
        /// <summary>Throws an <see cref="ArgumentException" />, when the given argument is part of the given sequence <c>source</c>.</summary>
        /// <typeparam name="T">The type of the argument, which must be a type of <see cref="IComparable" />"/>.</typeparam>
        /// <param name="argument">The argument, which has to be checked.</param>
        /// <param name="argumentName">The parameter name will be automatically detected by the <see cref="CallerArgumentExpressionAttribute"/>, so please do not enter any name, otherwise you will got the wrong parameter name.</param>
        /// <param name="source">The sequence which should contains the given argument.</param>
        /// <returns>The given argument, which was checked.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The exception, which will be thrown, if the given argument is part of the given sequence <c>source</c>.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        public static T IfContains<T>(T argument, IEnumerable<T> source, [CallerArgumentExpression("argument")] string argumentName = "")
        {
            IfNull(source);

            if (source.Contains(argument).IsFalse())
            {
                return argument;
            }

            throw new ArgumentException($"The argument '{argument}' is contained in the enumeration.", argumentName);
        }
    }
}
