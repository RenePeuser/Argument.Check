using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#pragma warning disable 649

namespace Argument.Check.Test.ThrowHelper
{
    [TestClass]
    public class ThrowIfExistsTest
    {
        private readonly DirectoryInfo _existingDirectoryInfo = new DirectoryInfo(Environment.CurrentDirectory);
        private readonly FileInfo _existingFileInfo = new DirectoryInfo(Environment.CurrentDirectory).EnumerateFiles().First();
        private readonly FileInfo _notExistingFileInfo = new FileInfo(@"s:\SonGoku.db");
        private readonly FileSystemInfo _nullArgument;

        [TestMethod]
        public void Should_Throw_An_Exception_If_Directory_Info_Exist()
        {
            _ = Assert.ThrowsException<ArgumentException>(() => TestMethod(_existingDirectoryInfo), nameof(_existingDirectoryInfo));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_CorrectMessage_If_DirectoryInfo_Exist()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => TestMethod(_existingDirectoryInfo), nameof(_existingDirectoryInfo));

            Assert.AreEqual($"The directory: '{_existingDirectoryInfo.FullName}' already exists. (Parameter 'argument')", exception.Message);
        }


        [TestMethod]
        public void Should_Throw_An_Exception_If_FileInfo_Exist()
        {
            _ = Assert.ThrowsException<ArgumentException>(() => TestMethod(_existingFileInfo), nameof(_existingFileInfo));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_CorrectMessage_If_FileInfo_Exist()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => TestMethod(_existingFileInfo), nameof(_existingFileInfo));

            Assert.AreEqual($"The file: '{_existingFileInfo.FullName}' already exists. (Parameter 'argument')", exception.Message);
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_SystemFileInfo_Not_Exists()
        {
            TestMethod(_notExistingFileInfo);
        }

        [TestMethod]
        public void Should_Return_The_Same_Argument_Reference_Like_The_Checked_One()
        {
            Assert.AreEqual(_notExistingFileInfo, Throw.IfExists(_notExistingFileInfo));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_Argument_Is_Null()
        {
            _ = Assert.ThrowsException<ArgumentNullException>(() => TestMethod(_nullArgument), nameof(_nullArgument));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_ArgumentFunc_Is_Null()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                TestNullFunc();

                static void TestNullFunc()
                {
                    _ = Throw.IfExists(NullHelper.GetNullOf<FileSystemInfo>());
                }
            });

            Assert.AreEqual("Value cannot be null. (Parameter 'argumentFunc')", exception.Message);
        }

        private void TestMethod(FileSystemInfo argument)
        {
            _ = Throw.IfExists(argument);
        }
    }
}