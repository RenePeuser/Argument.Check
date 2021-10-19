using System;
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
        /// <summary>Throws an <see cref="ArgumentException" />, when the given argument is <c>null</c>.</summary>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="argumentFunc">A function, which returns the argument to validate.</param>
        /// <returns>The given argument, which was checked.</returns>
        /// <exception cref="ArgumentNullException">The exception, which will be thrown, if the argument is not valid.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        [Obsolete("This method is obsolete use the new version without func to check your arguments  Throw.IfNull(myArgument)", false)]
        public static T IfNull<T>([NotNull] Func<T> argumentFunc) where T : class
        {
            if (argumentFunc == null)
            {
                throw new ArgumentNullException(nameof(argumentFunc));
            }

            var argument = argumentFunc();
            if (argument.IsNotNull())
            {
                return argument;
            }

            throw new ArgumentNullException(argumentFunc.GetParameterName(arg => arg.IsNull()));
        }

        /// <summary>Throws an <see cref="ArgumentException" />, when the given argument is <c>null</c>.</summary>
        /// <param name="argument">The argument, which has to be checked.</param>
        /// <param name="argumentName">The argument name will be automatically detected by the <see cref="CallerArgumentExpressionAttribute"/>, so please do not enter any name, otherwise you will got the wrong parameter name.</param>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <returns>The given argument, which was checked.</returns>
        /// <exception cref="ArgumentNullException">The exception, which will be thrown, if the argument is not valid.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        public static T IfNull<T>(T? argument, [CallerArgumentExpression("argument")] string argumentName = "") where T : class
        {
            if (argument == null)
            {
                throw new ArgumentNullException(argumentName);
            }

            return argument;
        }
    }
}
