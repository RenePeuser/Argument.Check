using System;
#if !DEBUG
using System.Diagnostics;
#endif
using System.IO;
using System.Runtime.CompilerServices;
using Argument.Check.Extensions;

namespace Argument.Check
{
    /// <summary>Provides a set of static methods to validate your arguments.</summary>
    public partial class Throw
    {
        /// <summary>Throws an <see cref="ArgumentException" />, when the given <see cref="FileSystemInfo" /> exists.</summary>
        /// <param name="argumentFunc">A function, which returns the <see cref="FileSystemInfo" /> to validate.</param>
        /// <returns>The <see cref="FileSystemInfo" />, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, if <see cref="FileSystemInfo" /> does exists.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        [Obsolete("This method is obsolete use the new version without func to check your arguments  Throw.IfExists(myArgument)", false)]
        public static FileSystemInfo IfExists(Func<FileSystemInfo> argumentFunc)
        {
            IfNull(() => argumentFunc);
            IfNull(argumentFunc);

            var fileSystemInfo = argumentFunc();
            if (fileSystemInfo.Exists.IsFalse())
            {
                return fileSystemInfo;
            }

            throw fileSystemInfo switch
            {
                FileInfo fileInfo => new ArgumentException($"The file: '{fileInfo.FullName}' already exists.", argumentFunc.GetParameterName(arg => arg.Is<FileInfo>() && arg.Cast<FileInfo>().Exists)),
                DirectoryInfo directoryInfo => new ArgumentException($"The directory: '{directoryInfo.FullName}' already exists.", argumentFunc.GetParameterName(arg => arg.Is<DirectoryInfo>() && arg.Cast<DirectoryInfo>().Exists)),
                _ => new ArgumentException($"The path: '{fileSystemInfo.FullName}' already exists.", argumentFunc.GetParameterName(arg => arg.Is<FileSystemInfo>() && arg.Cast<FileSystemInfo>().Exists))
            };
        }

        /// <summary>Throws an <see cref="ArgumentException" />, when the given <see cref="FileSystemInfo" /> exists.</summary>
        /// <param name="argument">The argument, which has to be checked.</param>
        /// <param name="argumentName">The argument name will be automatically detected by the <see cref="CallerArgumentExpressionAttribute"/>, so please do not enter any name, otherwise you will got the wrong parameter name.</param>
        /// <returns>The <see cref="FileSystemInfo" />, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, if <see cref="FileSystemInfo" /> does exists.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        public static FileSystemInfo IfExists(FileSystemInfo argument, [CallerArgumentExpression("argument")] string argumentName = "")
        {
            IfNull(argument);

            if (argument.Exists.IsFalse())
            {
                return argument;
            }

            throw argument switch
            {
                FileInfo fileInfo => new ArgumentException($"The file: '{fileInfo.FullName}' already exists.", argumentName),
                DirectoryInfo directoryInfo => new ArgumentException($"The directory: '{directoryInfo.FullName}' already exists.", argumentName),
                _ => new ArgumentException($"The path: '{argument.FullName}' already exists.", argumentName)
            };
        }
    }
}
