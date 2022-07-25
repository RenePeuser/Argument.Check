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
        /// <summary>Throws an <see cref="ArgumentException" />, when the given type is not the specific type <c>T</c>. Hint: It is a type equal test, it is not assignable from check !.</summary>
        /// <param name="argumentFunc">A function, which returns the string to validate.</param>
        /// <returns>The given argument, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, when the given type is not the specific type.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        [Obsolete("This method is obsolete use the new version without func to check your arguments  Throw.IfTypeIsNot<MyType>(myArgument)", false)]
        public static object IfTypeIsNot<T>(Func<object> argumentFunc) where T : class
        {
            IfNull(() => argumentFunc);
            IfNull(argumentFunc);

            var argument = argumentFunc();
            if (argument.IsTypeOf<T>())
            {
                return argument;
            }

            throw new ArgumentException($"The given type: '{argument.GetType()}' is not the expected type: '{typeof(T)}'.", argumentFunc.GetParameterName(arg => arg.EqualsTo(argument) && arg.IsNotTypeOf<T>()));
        }


        /// <summary>Throws an <see cref="ArgumentException" />, when the given type is not the specific type <c>T</c>. Hint: It is a type equal test, it is not assignable from check !.</summary>
        /// <param name="argument">The argument, which has to be checked.</param>
        /// <param name="argumentName">The argument name will be automatically detected by the <see cref="CallerArgumentExpressionAttribute"/>, so please do not enter any name, otherwise you will got the wrong parameter name.</param>
        /// <returns>The given argument, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, when the given type is not the specific type.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        public static object IfTypeIsNot<T>(object argument, [CallerArgumentExpression("argument")] string argumentName = "") where T : class
        {
            IfNull(argument);

            if (argument.IsTypeOf<T>())
            {
                return argument;
            }

            throw new ArgumentException($"The given type: '{argument.GetType()}' is not the expected type: '{typeof(T)}'.", argumentName);
        }
    }
}
