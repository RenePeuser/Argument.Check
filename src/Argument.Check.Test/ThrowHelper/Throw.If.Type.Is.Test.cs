using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.ThrowHelper
{
    [TestClass]
    public class IfTypeIsTest
    {
        private readonly int _notExpectedType = 4;
        private readonly string _nullString = null;
        private readonly string _sonGoku = "SonGoku";

        [TestMethod]
        public void Should_Throw_An_Exception_If_Argument_Is_Expected_Type()
        {
            Assert.ThrowsException<ArgumentException>(() => TestMethod<string>(_sonGoku));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_Expected_Message_If_Argument_Is_Expected_Type()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => TestMethod<string>(_sonGoku));

            Assert.AreEqual($"The given type: '{_sonGoku.GetType()}' is the expected type: '{typeof(string)}'. (Parameter 'argument')", exception.Message);
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Argument_Is_Expected_Type()
        {
            TestMethod<string>(_notExpectedType);
        }

        [TestMethod]
        public void Should_Return_The_Same_Argument_Reference_Like_The_Checked_One()
        {
            Assert.AreEqual(_notExpectedType, Throw.IfTypeIs<string>(() => _notExpectedType));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_Argument_Is_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => TestMethod<string>(_nullString), nameof(_nullString));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_ArgumentFunc_Is_Null()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                TestNullFunc();
                void TestNullFunc()
                {
                    Throw.IfTypeIs<object>(NullHelper.GetNullOf<Func<object>>());
                }
            });

            Assert.AreEqual("Value cannot be null. (Parameter 'argumentFunc')", exception.Message);
        }

        private void TestMethod<T>(object argument) where T : class
        {
            Throw.IfTypeIs<T>(() => argument);
        }
    }
}
