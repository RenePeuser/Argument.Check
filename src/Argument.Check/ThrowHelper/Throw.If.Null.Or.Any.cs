using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using Argument.Check.Extensions;

namespace Argument.Check
{
    /// <summary>Provides a set of static methods to validate your arguments.</summary>
    public partial class Throw
    {
        /// <summary>Throws an <see cref="ArgumentException" />, when the given sequence is <c>null</c> or any item match the given <c>predicate</c>.</summary>
        /// <param name="argumentFunc">A function, which returns the sequence to validate.</param>
        /// <param name="predicate">A function which checks the argument, if it is valid or not.</param>
        /// <returns>The given sequence, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, when the given sequence is <c>null</c> or any item match the given <c>predicate</c>.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        [Obsolete("This method is obsolete use the new version without func to check your arguments  Throw.IfNullOrAny(myArgument, arg => arg.MyCheck())", false)]
        public static IEnumerable<T> IfNullOrAny<T>([NotNull] Func<IEnumerable<T>> argumentFunc, Func<T, bool> predicate)
        {
            IfNull(() => argumentFunc);
            IfNull(() => predicate);

            var argument = argumentFunc();
            if (!argument.Any(predicate))
            {
                return argument;
            }

            throw new ArgumentException($"The sequence must not contain any items that satisfy the given predicate: '{predicate.Method.Name}'.", argumentFunc.GetParameterName(x => x.Is<IEnumerable<T>>() && x.Cast<IEnumerable<T>>().Any(predicate)));
        }


        /// <summary>Throws an <see cref="ArgumentException" />, when the given sequence is <c>null</c> or any item match the given <c>predicate</c>.</summary>
        /// <param name="argument">The argument, which has to be checked.</param>
        /// <param name="argumentName">The argument name will be automatically detected by the <see cref="CallerArgumentExpressionAttribute"/>, so please do not enter any name, otherwise you will got the wrong parameter name.</param>
        /// <param name="predicate">A function which checks the argument, if it is valid or not.</param>
        /// <returns>The given sequence, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, when the given sequence is <c>null</c> or any item match the given <c>predicate</c>.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        public static IEnumerable<T> IfNullOrAny<T>([NotNull] IEnumerable<T> argument, Func<T, bool> predicate, [CallerArgumentExpression("argument")] string argumentName = default!)
        {
            IfNull(argument);
            IfNull(predicate);

            if (!argument.Any(predicate))
            {
                return argument;
            }

            throw new ArgumentException($"The sequence must not contain any items that satisfy the given predicate: '{predicate.Method.Name}'.", argumentName);
        }
    }
}
