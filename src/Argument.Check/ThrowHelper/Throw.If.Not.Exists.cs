using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using Argument.Check.Extensions;

namespace Argument.Check
{
    /// <summary>Provides a set of static methods to validate your arguments.</summary>
    public partial class Throw
    {
        /// <summary>Throws an <see cref="ArgumentException" />, when the given <see cref="FileSystemInfo" /> does not exists.</summary>
        /// <param name="argumentFunc">A function, which returns the <see cref="FileSystemInfo" /> to validate.</param>
        /// <returns>The <see cref="FileSystemInfo" />, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, if <see cref="FileSystemInfo" /> does not exists.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        [Obsolete("This method is obsolete use the new version without func to check your arguments  Throw.IfNotExists(myArgument)", false)]
        public static FileSystemInfo IfNotExists(Func<FileSystemInfo> argumentFunc)
        {
            IfNull(() => argumentFunc);
            IfNull(argumentFunc);

            var fileSystemInfo = argumentFunc();
            if (fileSystemInfo.Exists)
            {
                return fileSystemInfo;
            }

            throw fileSystemInfo switch
            {
                FileInfo fileInfo => new ArgumentException($"The file: '{fileInfo.FullName}' does not exists.", argumentFunc.GetParameterName(arg => arg.Is<FileInfo>() && arg.Cast<FileInfo>().Exists.IsFalse())),
                DirectoryInfo directoryInfo => new ArgumentException($"The directory: '{directoryInfo.FullName}' does not exists.", argumentFunc.GetParameterName(arg => arg.Is<DirectoryInfo>() && arg.Cast<DirectoryInfo>().Exists.IsFalse())),
                _ => new ArgumentException($"The path: '{fileSystemInfo.FullName}' does not exists.", argumentFunc.GetParameterName(arg => arg.Is<FileSystemInfo>() && arg.Cast<FileSystemInfo>().Exists.IsFalse()))
            };
        }


        /// <summary>Throws an <see cref="ArgumentException" />, when the given <see cref="FileSystemInfo" /> does not exists.</summary>
        /// <param name="argument">The argument, which has to be checked.</param>
        /// <param name="argumentName">The argument name will be automatically detected by the <see cref="CallerArgumentExpressionAttribute"/>, so please do not enter any name, otherwise you will got the wrong parameter name.</param>
        /// <returns>The <see cref="FileSystemInfo" />, which was checked.</returns>
        /// <exception cref="ArgumentException">The exception, which will be thrown, if <see cref="FileSystemInfo" /> does not exists.</exception>
#if !DEBUG
        [DebuggerHidden]
#endif
        public static FileSystemInfo IfNotExists(FileSystemInfo argument, [CallerArgumentExpression("argument")] string argumentName = default!)
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
