using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.ThrowHelper
{
    [TestClass]
    public class ThrowIfEqualsToTest
    {
        private readonly bool _expectedValue = true;
        private readonly object _nullArgument = null;

        [TestMethod]
        public void Should_Throw_An_Exception_If_Value_Is_Equal()
        {
            Assert.ThrowsException<ArgumentException>(() => TestMethod(_expectedValue, _expectedValue));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_Correct_Message_If_Value_Is_Equal()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => TestMethod(_expectedValue, _expectedValue));

            Assert.IsTrue(exception.Message.Contains($"The argument value: '{_expectedValue}' was equal to: '{_expectedValue}'."));
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Value_Is_Not_Equal()
        {
            Throw.IfEqualsTo(() => _expectedValue, false);
        }

        [TestMethod]
        public void Should_Return_The_Same_Argument_Reference_Like_The_Checked_One()
        {
            Assert.AreEqual(_expectedValue, Throw.IfEqualsTo(() => _expectedValue, false));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_ArgumentFunc_Is_Null()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                TestNullFunc();
                void TestNullFunc()
                {
                    Throw.IfEqualsTo(NullHelper.GetNullOf<Func<int>>(), 5);
                }
            });

            Assert.AreEqual("Value cannot be null. (Parameter 'argumentFunc')", exception.Message);
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Argument_Is_Null()
        {
            Throw.IfEqualsTo(() => _nullArgument, _expectedValue);
        }

        private void TestMethod<T>(T argument, T expected)
        {
            Throw.IfEqualsTo(() => argument, expected);
        }
    }
}
