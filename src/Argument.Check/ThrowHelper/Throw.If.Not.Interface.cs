using System;
using System.Diagnostics;
using Argument.Check.Extensions;

namespace Argument.Check
{
    /// <summary>Provides a set of static methods to validate your arguments.</summary>
    public partial class Throw
    {
        /// <summary>Throws an <see cref="ArgumentException" />, when the given type is not an interface.</summary>
        /// <exception cref="ArgumentException">The exception, which will be thrown, if the argument is not an interface.</exception>
        [DebuggerHidden]
        public static void IfNotInterface<T>() where T : class
        {
            var type = typeof(T);
            if (!type.IsInterface)
            {
                throw new ArgumentException($"Type: '{type}' must be an interface.");
            }
        }

        /// <summary>Throws an <see cref="ArgumentException" />, when the given type is not an interface.</summary>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="argumentFunc">A function, which returns the string to validate.</param>
        /// <returns>The given argument, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, if the argument is not an interface.</exception>
        [DebuggerHidden]
        public static T IfNotInterface<T>(Func<T> argumentFunc) where T : class
        {
            IfNull(() => argumentFunc);
            IfNull(argumentFunc);

            var argument = argumentFunc();
            var type = typeof(T);
            if (type.IsInterface)
            {
                return argument;
            }

            throw new ArgumentException($"Argument: '{argumentFunc.GetParameterName()}' must be an interface.");
        }
    }
}
