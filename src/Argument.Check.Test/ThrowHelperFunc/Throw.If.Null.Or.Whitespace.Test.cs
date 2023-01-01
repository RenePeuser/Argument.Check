using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#pragma warning disable 649

namespace Argument.Check.Test.ThrowHelperFunc
{
    [TestClass]
    public class ThrowIfNullOrWhiteSpaceTest
    {
        private readonly string _emptyString = " ";
        private readonly string? _nullStringArgument;
        private readonly string _sonGoku = "SonGoku";


        [TestMethod]
        public void Should_Throw_An_Exception_If_String_Is_WhiteSpace()
        {
            _ = Assert.ThrowsException<ArgumentException>(() => TestMethod(_emptyString));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_Correct_Message_If_String_Is_WhiteSpace()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => TestMethod(_emptyString));

            Assert.AreEqual("The string must not be only whitespace. (Parameter 'value')", exception.Message);
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_String_Is_Null()
        {
            _ = Assert.ThrowsException<ArgumentNullException>(() => TestMethod(_nullStringArgument), nameof(_nullStringArgument));
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_String_Is_Not_Null_And_Does_Not_Contains_Null_Items()
        {
            TestMethod(_sonGoku);
        }

        [TestMethod]
        public void Should_Return_The_Same_String_Argument_Reference_Like_The_Checked_One()
        {
            Assert.AreEqual(_sonGoku, Throw.IfNullOrWhiteSpace(_sonGoku));
        }

        private void TestMethod(string? value)
        {
            _ = Throw.IfNullOrWhiteSpace(value);
        }
    }
}
