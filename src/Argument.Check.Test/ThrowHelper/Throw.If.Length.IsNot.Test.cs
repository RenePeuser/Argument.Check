using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.ThrowHelper
{
    [TestClass]
    public class ThrowIfLengthIsNotTest
    {
        private const string ArgumentFuncName = "argumentFunc";
        private readonly int _expectedLength = 5;
        private readonly Func<string> _nullArgumentFunc = null;
        private readonly string _nullString = null;
        private readonly string _sonGoku = "SonGoku";
        private readonly string _stringIsToSmall = "less";
        private readonly string _stringToLarge = "greater";

        [TestMethod]
        public void Should_Throw_Exception_If_String_Length_Is_Too_Small()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Throw.IfLengthIsNot(() => _stringIsToSmall, _expectedLength), nameof(_stringIsToSmall));
        }

        [TestMethod]
        public void Should_Throw_Exception_If_String_Length_Is_Too_Large()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Throw.IfLengthIsNot(() => _stringToLarge, _expectedLength), nameof(_stringToLarge));
        }

        [TestMethod]
        public void Should_Throw_Exception_With_Correct_Message_If_String_Length_Is_Too_Large()
        {
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() => Throw.IfLengthIsNot(() => _stringToLarge, _expectedLength), nameof(_stringToLarge));

            Assert.IsTrue(exception.Message.Contains($"String length: '{_stringToLarge}' is not as expected. Expected value: '{_expectedLength}'."));
        }

        [TestMethod]
        public void Should_Throw_Exception_If_ArgumentFunc_Is_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Throw.IfLengthIsNot(_nullArgumentFunc, _expectedLength), ArgumentFuncName);
        }

        [TestMethod]
        public void Should_Throw_Exception_If_Argument_Is_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Throw.IfLengthIsNot(() => _nullString, _expectedLength), nameof(_nullString));
        }

        [TestMethod]
        public void Should_Not_Throw_Exception_If_String_Length_Is_Equal_To_Expected_Length()
        {
            Throw.IfLengthIsNot(() => _sonGoku, 7);
        }

        [TestMethod]
        public void Should_Return_The_Same_Argument_Reference_Like_The_Checked_One()
        {
            Assert.AreEqual(_sonGoku, Throw.IfLengthIsNot(() => _sonGoku, 7));
        }
    }
}
