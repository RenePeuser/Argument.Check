using System;
using System.Diagnostics;
using Argument.Check.Extensions;

namespace Argument.Check
{
    public partial class Throw
    {
        /// <summary>
        /// Throws an <see cref="ArgumentException"/>, when the given argument is <c>null</c>.
        /// </summary>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="argumentFunc">A function, which returns the argument to validate.</param>
        /// <returns>The given argument, which was checked.</returns>
        /// <exception cref="ArgumentNullException">The exception, which will be thrown, if the argument is not valid.</exception>
        [DebuggerHidden]
        public static T IfNull<T>(Func<T> argumentFunc) where T : class
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

            throw new ArgumentNullException(argumentFunc.GetParameterName(arg => arg == null));
        }
    }
}
