using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.ThrowHelper
{
    [TestClass]
    public class ThrowIfWhiteSpaceTest
    {
        private const string ArgumentFuncName = "argumentFunc";
        private readonly string _nullStringArgument = null;
        private readonly Func<string> _nullStringArgumentFunc = null;
        private readonly string _sonGoku = "SonGoku";
        private readonly string _whiteSpace = " ";


        [TestMethod]
        public void Should_Throw_An_Exception_If_String_Is_WhiteSpace()
        {
            Assert.ThrowsException<ArgumentException>(() => Throw.IfWhitespace(() => _whiteSpace), nameof(_whiteSpace));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_Correct_Message_If_String_Is_WhiteSpace()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => Throw.IfWhitespace(() => _whiteSpace), nameof(_whiteSpace));

            Assert.IsTrue(exception.Message.Contains("The string must not be only whitespace."));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_String_Is_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Throw.IfWhitespace(() => _nullStringArgument), nameof(_nullStringArgument));
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_String_Is_Not_Null_And_Does_Not_Contains_Null_Items()
        {
            Throw.IfWhitespace(() => _sonGoku);
        }

        [TestMethod]
        public void Should_Return_The_Same_String_Argument_Reference_Like_The_Checked_One()
        {
            Assert.AreEqual(_sonGoku, Throw.IfWhitespace(() => _sonGoku));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_String_ArgumentFunc_Is_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Throw.IfWhitespace(_nullStringArgumentFunc), ArgumentFuncName);
        }
    }
}
