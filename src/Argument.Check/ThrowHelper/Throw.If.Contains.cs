using System;
using System.Collections.Generic;
#pragma warning disable IDE0005 // It is used by the precompiler switch release !!
using System.Diagnostics;
#pragma warning restore IDE0005 // It is used by the precompiler switch release !!
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
        /// <param name="argumentFunc">A function, which returns the string to validate.</param>
        /// <param name="source">The sequence which should contains the given argument.</param>
        /// <returns>The given argument, which was checked.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The exception, which will be thrown, if the given argument is part of the given sequence <c>source</c>.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        [Obsolete("This method is obsolete use the new version without func to check your arguments  Throw.IfContains(myArgument, mySequence)", false)]
        public static T IfContains<T>(Func<T> argumentFunc, IEnumerable<T> source)
        {
            IfNull(() => argumentFunc);
            IfNull(() => source);

            var argument = argumentFunc();
            if (source.Contains(argument).IsFalse())
            {
                return argument;
            }

            throw new ArgumentException($"The argument '{argument}' is contained in the enumeration.", argumentFunc.GetParameterName(arg => arg.EqualsTo(argument) && source.Contains(argument)));
        }

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
