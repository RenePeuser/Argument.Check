using System;
using System.Collections.Generic;
#pragma warning disable IDE0005 // It is used by the precompiler switch release !!
using System.Diagnostics;
#pragma warning restore IDE0005 // It is used by the precompiler switch release !!
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Argument.Check.Extensions;

namespace Argument.Check
{
    /// <summary>Provides a set of static methods to validate your arguments.</summary>
    public partial class Throw
    {
        /// <summary>Throws an <see cref="ArgumentException" />, when the given sequence is <c>null</c> or any item of the sequence is null.</summary>
        /// <param name="argumentFunc">A function, which returns the sequence to validate.</param>
        /// <returns>The given sequence, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, when the given sequence is <c>null</c> or any item of the sequence is null.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        [Obsolete("This method is obsolete use the new version without func to check your arguments  Throw.IfNullOrAnyItemIsNull(myArgument)", false)]
        public static IEnumerable<T> IfNullOrAnyItemIsNull<T>([NotNull] Func<IEnumerable<T>> argumentFunc)
        {
            IfNull(() => argumentFunc);
            IfNull(argumentFunc);

            var argument = argumentFunc();
            if (!argument.IsAnyItemNull())
            {
                return argument;
            }

            throw new ArgumentNullException(argumentFunc.GetParameterName(arg => arg.Is<IEnumerable<T>>() && arg.Cast<IEnumerable<T>>().IsAnyItemNull()), $"At least one item in the enumeration '{argumentFunc()}' was null.");
        }

        /// <summary>Throws an <see cref="ArgumentException" />, when the given sequence is <c>null</c> or any item of the sequence is null.</summary>
        /// <param name="argument">The argument, which has to be checked.</param>
        /// <param name="argumentName">The argument name will be automatically detected by the <see cref="CallerArgumentExpressionAttribute"/>, so please do not enter any name, otherwise you will got the wrong parameter name.</param>
        /// <returns>The given sequence, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, when the given sequence is <c>null</c> or any item of the sequence is null.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        public static IEnumerable<T> IfNullOrAnyItemIsNull<T>([NotNull] IEnumerable<T> argument, [CallerArgumentExpression("argument")] string argumentName = default!)
        {
            IfNull(argument);

            if (!argument.IsAnyItemNull())
            {
                return argument;
            }

            throw new ArgumentNullException(argumentName, $"At least one item in the enumeration '{argumentName}' was null.");
        }
    }
}
