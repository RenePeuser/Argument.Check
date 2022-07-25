using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#pragma warning disable 649

namespace Argument.Check.Test.ThrowHelper
{
    [TestClass]
    public class ThrowIfLengthIsNotTest
    {
        private const string ArgumentFuncName = "argumentFunc";
        private readonly int _expectedLength = 5;
        private readonly string _nullArgumentFunc;
        private readonly string _nullString;
        private readonly string _sonGoku = "SonGoku";
        private readonly string _stringIsToSmall = "less";
        private readonly string _stringToLarge = "greater";

        [TestMethod]
        public void Should_Throw_Exception_If_String_Length_Is_Too_Small()
        {
            _ = Assert.ThrowsException<ArgumentOutOfRangeException>(() => TestMethod(_stringIsToSmall, _expectedLength));
        }

        [TestMethod]
        public void Should_Throw_Exception_If_String_Length_Is_Too_Large()
        {
            _ = Assert.ThrowsException<ArgumentOutOfRangeException>(() => TestMethod(_stringToLarge, _expectedLength));
        }

        [TestMethod]
        public void Should_Throw_Exception_With_Correct_Message_If_String_Length_Is_Too_Large()
        {
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() => TestMethod(_stringToLarge, _expectedLength));

            Assert.AreEqual($"String length: '{_stringToLarge}' is not as expected. Expected value: '{_expectedLength}'. (Parameter 'argument')", exception.Message);
        }

        [TestMethod]
        public void Should_Throw_Exception_If_ArgumentFunc_Is_Null()
        {
            _ = Assert.ThrowsException<ArgumentNullException>(() => Throw.IfLengthIsNot(_nullArgumentFunc, _expectedLength), ArgumentFuncName);
        }

        [TestMethod]
        public void Should_Throw_Exception_If_Argument_Is_Null()
        {
            _ = Assert.ThrowsException<ArgumentNullException>(() => TestMethod(_nullString, _expectedLength), nameof(_nullString));
        }

        [TestMethod]
        public void Should_Not_Throw_Exception_If_String_Length_Is_Equal_To_Expected_Length()
        {
            TestMethod(_sonGoku, 7);
        }

        [TestMethod]
        public void Should_Return_The_Same_Argument_Reference_Like_The_Checked_One()
        {
            Assert.AreEqual(_sonGoku, Throw.IfLengthIsNot(_sonGoku, 7));
        }

        private void TestMethod(string argument, int length)
        {
            _ = Throw.IfLengthIsNot(argument, length);
        }
    }
}
