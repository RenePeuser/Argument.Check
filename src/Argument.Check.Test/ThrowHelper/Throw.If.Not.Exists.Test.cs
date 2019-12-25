using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.ThrowHelper
{
    [TestClass]
    public class ThrowIfNotExistsTest
    {
        private const string ArgumentFuncName = "argumentFunc";
        private readonly DirectoryInfo _existingDirectoryInfo = new DirectoryInfo(Environment.CurrentDirectory);
        private readonly DirectoryInfo _notExistingDirectioryInfo = new DirectoryInfo(@"s:\SonGoku\");
        private readonly FileInfo _notExistingFileInfo = new FileInfo(@"s:\SonGoku.db");
        private readonly FileSystemInfo _nullArgument = null;
        private readonly Func<FileSystemInfo> _nullArgumentFunc = null;


        [TestMethod]
        public void Should_Throw_An_Exception_If_DirectoryInfo_Not_Exist()
        {
            Assert.ThrowsException<ArgumentException>(() => Throw.IfNotExists(() => _notExistingDirectioryInfo), nameof(_notExistingDirectioryInfo));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_CorrectMessage_If_DirectoryInfo_Not_Exist()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => Throw.IfNotExists(() => _notExistingDirectioryInfo), nameof(_notExistingDirectioryInfo));

            Assert.IsTrue(exception.Message.Contains($"The directory: '{_notExistingDirectioryInfo.FullName}' does not exists."));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_FileInfo_Not_Exist()
        {
            Assert.ThrowsException<ArgumentException>(() => Throw.IfNotExists(() => _notExistingFileInfo), nameof(_notExistingFileInfo));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_CorrectMessage_If_FileInfo_Not_Exist()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => Throw.IfNotExists(() => _notExistingFileInfo), nameof(_notExistingFileInfo));

            Assert.IsTrue(exception.Message.Contains($"The file: '{_notExistingFileInfo.FullName}' does not exists."));
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_SystemFileInfo_Exists()
        {
            Throw.IfNotExists(() => _existingDirectoryInfo);
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_ArgumentFunc_Is_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Throw.IfNotExists(_nullArgumentFunc), ArgumentFuncName);
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_Argument_Is_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Throw.IfNotExists(() => _nullArgument), nameof(_nullArgument));
        }
    }
}
