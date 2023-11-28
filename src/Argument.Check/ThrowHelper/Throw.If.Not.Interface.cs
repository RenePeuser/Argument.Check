#if !DEBUG
using System.Diagnostics;
#endif
using System.Runtime.CompilerServices;

namespace Argument.Check
{
    /// <summary>Provides a set of static methods to validate your arguments.</summary>
    public partial class Throw
    {
        /// <summary>Throws an <see cref="ArgumentException" />, when the given type is not an interface.</summary>
        /// <exception cref="ArgumentException">The exception, which will be thrown, if the argument is not an interface.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
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
        /// <param name="argument">The argument, which has to be checked.</param>
        /// <param name="argumentName">The argument name will be automatically detected by the <see cref="CallerArgumentExpressionAttribute"/>, so please do not enter any name, otherwise you will got the wrong parameter name.</param>
        /// <returns>The given argument, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, if the argument is not an interface.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        public static object IfNotInterface<T>(object argument, [CallerArgumentExpression(nameof(argument))] string argumentName = "") where T : class
        {
            IfNull(argument);

            if (argument is T)
            {
                return argument;
            }

            throw new ArgumentException($"Argument: '{argumentName}' must be an interface.");
        }
    }
}
