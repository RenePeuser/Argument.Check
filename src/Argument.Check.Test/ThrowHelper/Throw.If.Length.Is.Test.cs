using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.ThrowHelper
{
    [TestClass]
    public class ThrowIfLengthIsTest
    {
        private const string ArgumentFuncName = "argumentFunc";
        private readonly int _expectedLength = 5;
        private readonly Func<string> _nullArgumentFunc = null;
        private readonly string _nullString = null;
        private readonly string _sonGoku = "SonGoku";
        private readonly string _stringHasExpectedLength = "abcde";

        [TestMethod]
        public void Should_Throw_Exception_If_String_Length_Is_Has_An_Expected_Length()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => TestMethod(_stringHasExpectedLength, _expectedLength));
        }

        [TestMethod]
        public void Should_Throw_Exception_With_Correct_Message_If_String_Length_Is_Too_Large()
        {
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() => TestMethod(_stringHasExpectedLength, _expectedLength));

            Assert.AreEqual($"String length: '{_stringHasExpectedLength}' must not be equals to to a length of: '{_expectedLength}'. (Parameter 'argument')", exception.Message);
        }

        [TestMethod]
        public void Should_Throw_Exception_If_ArgumentFunc_Is_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Throw.IfLengthIs(_nullArgumentFunc, _expectedLength), ArgumentFuncName);
        }

        [TestMethod]
        public void Should_Throw_Exception_If_Argument_Is_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => TestMethod(_nullString, _expectedLength), nameof(_nullString));
        }

        [TestMethod]
        public void Should_Not_Throw_Exception_If_String_Length_Is_Higher_Than_Expected_Length()
        {
            TestMethod(_sonGoku, 10);
        }

        [TestMethod]
        public void Should_Not_Throw_Exception_If_String_Length_Is_Less_Than_Expected_Length()
        {
            TestMethod(_sonGoku, 2);
        }

        [TestMethod]
        public void Should_Return_The_Same_Argument_Reference_Like_The_Checked_One()
        {
            Assert.AreEqual(_sonGoku, Throw.IfLengthIs(() => _sonGoku, 10));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_ArgumentFunc_Is_Null()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                TestNullFunc();
                void TestNullFunc()
                {
                    Throw.IfLengthIs(NullHelper.GetNullOf<Func<string>>(), 5);
                }
            });

            Assert.AreEqual("Value cannot be null. (Parameter 'argumentFunc')", exception.Message);
        }

        private void TestMethod(string argument, int length)
        {
            Throw.IfLengthIs(() => argument, length);
        }
    }
}
