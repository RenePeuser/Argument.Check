using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.ThrowHelperFunc
{
    [TestClass]
    public class ThrowIfNotExistsTest
    {
        private readonly DirectoryInfo _existingDirectoryInfo = new DirectoryInfo(Environment.CurrentDirectory);
        private readonly DirectoryInfo _notExistingDirectioryInfo = new DirectoryInfo(@"s:\SonGoku\");
        private readonly FileInfo _notExistingFileInfo = new FileInfo(@"s:\SonGoku.db");
        private readonly FileSystemInfo _nullArgument = null!;

        [TestMethod]
        public void Should_Throw_An_Exception_If_DirectoryInfo_Not_Exist()
        {
            _ = Assert.ThrowsException<ArgumentException>(() => TestMethod(_notExistingDirectioryInfo));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_CorrectMessage_If_DirectoryInfo_Not_Exist()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => TestMethod(_notExistingDirectioryInfo));

            Assert.AreEqual($"The directory: '{_notExistingDirectioryInfo.FullName}' does not exists. (Parameter 'argument')", exception.Message);
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_FileInfo_Not_Exist()
        {
            _ = Assert.ThrowsException<ArgumentException>(() => TestMethod(_notExistingFileInfo));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_CorrectMessage_If_FileInfo_Not_Exist()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => TestMethod(_notExistingFileInfo));

            Assert.IsTrue(exception.Message.Contains($"The file: '{_notExistingFileInfo.FullName}' does not exists."));
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_SystemFileInfo_Exists()
        {
            TestMethod(_existingDirectoryInfo);
        }

        [TestMethod]
        public void Should_Return_The_Same_Argument_Reference_Like_The_Checked_One()
        {
            Assert.AreEqual(_existingDirectoryInfo, Throw.IfNotExists(() => _existingDirectoryInfo));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_Argument_Is_Null()
        {
            _ = Assert.ThrowsException<ArgumentNullException>(() => TestMethod(_nullArgument));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_ArgumentFunc_Is_Null()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                TestNullFunc();

                static void TestNullFunc()
                {
                    _ = Throw.IfNotExists(NullHelper.GetNullOf<Func<FileSystemInfo>>());
                }
            });

            Assert.AreEqual("Value cannot be null. (Parameter 'argumentFunc')", exception.Message);
        }

        private void TestMethod(FileSystemInfo argument)
        {
            _ = Throw.IfNotExists(() => argument);
        }
    }
}