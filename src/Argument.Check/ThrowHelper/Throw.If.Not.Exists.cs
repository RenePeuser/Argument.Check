using System;
#if !DEBUG
using System.Diagnostics;
#endif
using System.IO;
using System.Runtime.CompilerServices;

namespace Argument.Check
{
    /// <summary>Provides a set of static methods to validate your arguments.</summary>
    public partial class Throw
    {
        /// <summary>Throws an <see cref="ArgumentException" />, when the given <see cref="FileSystemInfo" /> does not exists.</summary>
        /// <param name="argument">The argument, which has to be checked.</param>
        /// <param name="argumentName">The argument name will be automatically detected by the <see cref="CallerArgumentExpressionAttribute"/>, so please do not enter any name, otherwise you will got the wrong parameter name.</param>
        /// <returns>The <see cref="FileSystemInfo" />, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, if <see cref="FileSystemInfo" /> does not exists.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        public static FileSystemInfo IfNotExists(FileSystemInfo argument, [CallerArgumentExpression("argument")] string argumentName = "")
        {
            IfNull(argument);

            if (argument.Exists)
            {
                return argument;
            }

            throw argument switch
            {
                FileInfo fileInfo => new ArgumentException($"The file: '{fileInfo.FullName}' does not exists.", argumentName),
                DirectoryInfo directoryInfo => new ArgumentException($"The directory: '{directoryInfo.FullName}' does not exists.", argumentName),
                _ => new ArgumentException($"The path: '{argument.FullName}' does not exists.", argumentName)
            };
        }
    }
}
