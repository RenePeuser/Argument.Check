using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.ThrowHelper
{
    [TestClass]
    public class ThrowIfNotEqualsToTest
    {
        [TestMethod]
        public void Should_Throw_An_Exception_If_Value_Is_Not_Equal()
        {
            Assert.ThrowsException<ArgumentException>(() => TestMethod(true, false));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_Correct_Message_If_Value_Is__Not_Equal()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => TestMethod(true, false));

            Assert.AreEqual("The argument value: 'True' is not equal to: 'False'. (Parameter 'argument')", exception.Message);
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Value_Is_Equal()
        {
            TestMethod(true, true);
        }

        [TestMethod]
        public void Should_Return_The_Same_Argument_Reference_Like_The_Checked_One()
        {
            Assert.AreEqual(true, Throw.IfNotEqualsTo(() => true, true));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_ArgumentFunc_Is_Null()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                TestNullFunc();
                void TestNullFunc()
                {
                    Throw.IfNotEqualsTo(NullHelper.GetNullOf<Func<int>>(), 5);
                }
            });

            Assert.AreEqual("Value cannot be null. (Parameter 'argumentFunc')", exception.Message);
        }

        private void TestMethod(object argument, object expected)
        {
            Throw.IfNotEqualsTo(() => argument, expected);
        }
    }
}
