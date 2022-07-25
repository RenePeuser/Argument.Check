using System;
#if !DEBUG
using System.Diagnostics;
#endif
using System.Runtime.CompilerServices;
using Argument.Check.Extensions;

namespace Argument.Check
{
    /// <summary>Provides a set of static methods to validate your arguments.</summary>
    public partial class Throw
    {
        /// <summary>Throws an <see cref="ArgumentException" />, when the given type is an interface.</summary>
        /// <exception cref="ArgumentException">The exception, which will be thrown, if the argument is an interface.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        public static void IfInterface<T>() where T : class
        {
            var type = typeof(T);
            if (type.IsInterface)
            {
                throw new ArgumentException($"Type: '{type}' must not be an interface.");
            }
        }

        /// <summary>Throws an <see cref="ArgumentException" />, when the given type is an interface.</summary>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="argumentFunc">A function, which returns the string to validate.</param>
        /// <returns>The given argument, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, if the argument is an interface.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        [Obsolete("This method is obsolete use the new version without func to check your arguments  Throw.IfInterface(myArgument)", false)]
        public static object IfInterface<T>(Func<object> argumentFunc) where T : class
        {
            IfNull(() => argumentFunc);
            IfNull(argumentFunc);

            var argument = argumentFunc();
            if (argument.Is<T>().IsNot())
            {
                return argument;
            }

            throw new ArgumentException($"Argument: '{argumentFunc.GetParameterName(arg => arg.Is<T>())}' must not be an interface.");
        }

        /// <summary>Throws an <see cref="ArgumentException" />, when the given type is an interface.</summary>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="argument">The argument, which has to be checked.</param>
        /// <param name="argumentName">The argument name will be automatically detected by the <see cref="CallerArgumentExpressionAttribute"/>, so please do not enter any name, otherwise you will got the wrong parameter name.</param>
        /// <returns>The given argument, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, if the argument is an interface.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        public static object IfInterface<T>(object argument, [CallerArgumentExpression("argument")] string argumentName = "") where T : class
        {
            IfNull(argument);

            if (argument is not T)
            {
                return argument;
            }

            throw new ArgumentException($"Argument: '{argumentName}' must not be an interface.");
        }
    }
}
