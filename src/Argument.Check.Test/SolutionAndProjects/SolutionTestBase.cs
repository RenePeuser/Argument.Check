using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.SolutionAndProjects
{
    [TestClass]
    public abstract class SolutionTestBase
    {
        internal static List<CSharpFileInfo> CSharpFileInfos { get; private set; }

        internal static List<CSharpFileInfo> ThrowHelperCSharpFileInfos { get; private set; }

        [AssemblyInitialize]
        public static void ClassInit(TestContext testContext)
        {
            var currentDirectory = new DirectoryInfo(Environment.CurrentDirectory);

            var argumentCheckDirectory = FindFolderWithSources(currentDirectory, "Argument.Check");
            var allCSharpFiles = argumentCheckDirectory.EnumerateFiles("*.cs", SearchOption.AllDirectories);
            CSharpFileInfos = allCSharpFiles.Select(csharpFile =>
                {
                    var syntaxTree = CSharpSyntaxTree.ParseText(File.ReadAllText(csharpFile.FullName));
                    return new CSharpFileInfo(csharpFile, syntaxTree);
                })
                .ToList();

            ThrowHelperCSharpFileInfos = CSharpFileInfos.Where(file => file.FileInfo.FullName.Contains("ThrowHelper")).ToList();
        }

        private static DirectoryInfo FindFolderWithSources(DirectoryInfo startDirectoryInfo, string name)
        {
            if (startDirectoryInfo == null)
            {
                return null;
            }

            if (startDirectoryInfo.Name == name)
            {
                return startDirectoryInfo;
            }

            var directory = startDirectoryInfo.EnumerateDirectories(name).FirstOrDefault();
            if (directory != null)
            {
                return directory;
            }

            return FindFolderWithSources(startDirectoryInfo.Parent, name);
        }

        [DebuggerDisplay("{CSharpFileInfo.Name}")]
        internal class AnalyzeResult
        {
            public AnalyzeResult(FileInfo cSharpFileInfo, string methodName)
            {
                CSharpFileInfo = cSharpFileInfo;
                MethodName = methodName;
            }

            public FileInfo CSharpFileInfo { get; set; }

            public string MethodName { get; set; }
        }

        [DebuggerDisplay("{FileInfo.Name}")]
        internal class CSharpFileInfo
        {
            public CSharpFileInfo(FileInfo fileInfo, SyntaxTree syntaxTree)
            {
                FileInfo = fileInfo;
                SyntaxTree = syntaxTree;
            }

            public FileInfo FileInfo { get; }

            public SyntaxTree SyntaxTree { get; }
        }
    }
}