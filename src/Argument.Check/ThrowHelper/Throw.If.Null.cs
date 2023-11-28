#if !DEBUG
using System.Diagnostics;
#endif
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Argument.Check
{
    /// <summary>Provides a set of static methods to validate your arguments.</summary>
    public partial class Throw
    {
        /// <summary>Throws an <see cref="ArgumentException" />, when the given argument is <c>null</c>.</summary>
        /// <param name="argument">The argument, which has to be checked.</param>
        /// <param name="argumentName">The argument name will be automatically detected by the <see cref="CallerArgumentExpressionAttribute"/>, so please do not enter any name, otherwise you will got the wrong parameter name.</param>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <returns>The given argument, which was checked.</returns>
        /// <exception cref="ArgumentNullException">The exception, which will be thrown, if the argument is not valid.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        public static T IfNull<T>([NotNull] T? argument, [CallerArgumentExpression(nameof(argument))] string argumentName = "") where T : class
        {
            if (argument is null)
            {
                throw new ArgumentNullException(argumentName);
            }

            return argument;
        }
    }
}
