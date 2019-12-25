using System;
using System.Diagnostics;
using System.IO;
using Argument.Check.Extensions;

namespace Argument.Check
{
    public partial class Throw
    {
        [DebuggerHidden]
        public static void IfExists(Func<FileSystemInfo> fileSystemInfoFunc)
        {
            IfNull(() => fileSystemInfoFunc);
            IfNullInternal(fileSystemInfoFunc);

            var fileSystemInfo = fileSystemInfoFunc();
            if (fileSystemInfo.Exists.IsFalse())
            {
                return;
            }

            switch (fileSystemInfo)
            {
                case FileInfo fileInfo:
                    throw new ArgumentException($"The file: '{fileInfo.FullName}' already exists.", fileSystemInfoFunc.GetParameterName(arg => arg.Is<FileSystemInfo>() && arg.Cast<FileSystemInfo>().Exists));
                case DirectoryInfo directoryInfo:
                    throw new ArgumentException($"The directory: '{directoryInfo.FullName}' already exists.", fileSystemInfoFunc.GetParameterName(arg => arg.Is<FileSystemInfo>() && arg.Cast<FileSystemInfo>().Exists));
                default:
                    throw new ArgumentException($"The path: '{fileSystemInfo.FullName}' already exists.", fileSystemInfoFunc.GetParameterName(arg => arg.Is<FileSystemInfo>() && arg.Cast<FileSystemInfo>().Exists));
            }
        }
    }
}
