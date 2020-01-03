using System;
using System.Diagnostics;
using Argument.Check.Extensions;

namespace Argument.Check
{
    public partial class Throw
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/>, when the given type is an interface.
        /// </summary>
        /// <exception cref="ArgumentException">The exception, which will be thrown, if the argument is an interface.</exception>
        [DebuggerHidden]
        public static void IfInterface<T>() where T : class
        {
            var type = typeof(T);
            if (type.IsInterface)
            {
                throw new ArgumentException($"Type: '{type}' must not be an interface.");
            }
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/>, when the given type is an interface.
        /// </summary>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="argumentFunc">A function, which returns the string to validate.</param>
        /// <returns>The given argument, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, if the argument is an interface.</exception>
        [DebuggerHidden]
        public static T IfInterface<T>(Func<T> argumentFunc) where T : class
        {
            Throw.IfNull(() => argumentFunc);
            Throw.IfNull(argumentFunc);

            var argument = argumentFunc();
            var type = typeof(T);
            if (type.IsInterface.IsFalse())
            {
                return argument;
            }

            throw new ArgumentException($"Type: '{type}' must not be an interface.");
        }
    }
}
