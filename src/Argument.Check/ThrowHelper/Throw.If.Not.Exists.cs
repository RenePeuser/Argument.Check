using System;
using System.Diagnostics;
using System.IO;
using Argument.Check.Extensions;

namespace Argument.Check
{
    using static FormattableString;

    public partial class Throw
    {
        [DebuggerHidden]
        public static void IfNotExists(Func<FileSystemInfo> fileSystemInfoFunc)
        {
            IfNull(() => fileSystemInfoFunc);
            IfNullInternal(fileSystemInfoFunc);

            var fileSystemInfo = fileSystemInfoFunc();
            if (fileSystemInfo.Exists)
            {
                return;
            }

            switch (fileSystemInfo)
            {
                case FileInfo fileInfo:
                    throw new ArgumentException(Invariant($"The file: '{fileInfo.FullName}' does not exists."), fileSystemInfoFunc.GetParameterName(arg => arg.Is<FileSystemInfo>() && arg.Cast<FileSystemInfo>().Exists.IsFalse()));
                case DirectoryInfo directoryInfo:
                    throw new ArgumentException(Invariant($"The directory: '{directoryInfo.FullName}' does not exists."), fileSystemInfoFunc.GetParameterName(arg => arg.Is<FileSystemInfo>() && arg.Cast<FileSystemInfo>().Exists.IsFalse()));
                default:
                    throw new ArgumentException(Invariant($"The path: '{fileSystemInfo.FullName}' does not exists."), fileSystemInfoFunc.GetParameterName(arg => arg.Is<FileSystemInfo>() && arg.Cast<FileSystemInfo>().Exists.IsFalse()));
            }
        }
    }
}
