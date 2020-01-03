using System;
using System.Diagnostics;
using Argument.Check.Extensions;

namespace Argument.Check
{
    /// <summary>Provides a set of static methods to validate your arguments.</summary>
    public partial class Throw
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/>, when the given type is the specific type <see cref="T"/>.
        /// Hint: It is a type equal test, it is not assignable from check !.
        /// </summary>
        /// <param name="argumentFunc">A function, which returns the string to validate.</param>
        /// <returns>The given argument, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, when the given type is the specific type.</exception>
        [DebuggerHidden]
        public static object IfTypeIs<T>(Func<object> argumentFunc) where T : class
        {
            IfNull(() => argumentFunc);
            IfNull(argumentFunc);

            var argument = argumentFunc();
            if (argument.IsNotTypeOf<T>())
            {
                return argument;
            }

            throw new ArgumentException($"The given type: '{argument.GetType()}' is the expected type: '{typeof(T)}'.", argumentFunc.GetParameterName(arg => arg.EqualsTo(argument) && arg.IsTypeOf<T>()));
        }
    }
}
