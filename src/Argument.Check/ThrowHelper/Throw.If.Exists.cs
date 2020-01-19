using System;
using System.Diagnostics;
using System.IO;
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
        [DebuggerHidden]
        public static FileSystemInfo IfExists(Func<FileSystemInfo> argumentFunc)
        {
            IfNull(() => argumentFunc);
            IfNull(argumentFunc);

            var fileSystemInfo = argumentFunc();
            if (fileSystemInfo.Exists.IsFalse())
            {
                return fileSystemInfo;
            }

            switch (fileSystemInfo)
            {
                case FileInfo fileInfo:
                    throw new ArgumentException($"The file: '{fileInfo.FullName}' already exists.", argumentFunc.GetParameterName(arg => arg.Is<FileInfo>() && arg.Cast<FileInfo>().Exists));
                case DirectoryInfo directoryInfo:
                    throw new ArgumentException($"The directory: '{directoryInfo.FullName}' already exists.", argumentFunc.GetParameterName(arg => arg.Is<DirectoryInfo>() && arg.Cast<DirectoryInfo>().Exists));
                default:
                    throw new ArgumentException($"The path: '{fileSystemInfo.FullName}' already exists.", argumentFunc.GetParameterName(arg => arg.Is<FileSystemInfo>() && arg.Cast<FileSystemInfo>().Exists));
            }
        }
    }
}
