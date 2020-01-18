using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.ThrowHelper
{
    [TestClass]
    public class ThrowIfGreaterOrEqualTest
    {
        private readonly int _greaterValue = 84;
        private readonly int _limit = 42;
        private readonly int _validValue = 1;

        [TestMethod]
        public void Should_Throw_Exception_If_Value_Is_Equal_To_Expected_Limit()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>TestMethod(_limit, _limit));
        }

        [TestMethod]
        public void Should_Throw_Exception_If_Value_Is_Greater_To_Expected_Limit()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>TestMethod(_greaterValue, _limit));
        }

        [TestMethod]
        public void Should_Throw_Exception_With_Correct_Message_If_Value_Is_Equal_To_Expected_Limit()
        {
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() =>TestMethod(_greaterValue, _limit));

            Assert.AreEqual($"Value: '{_greaterValue}' must not be greater than or equal to: '{_limit}'. (Parameter 'current')", exception.Message);
        }

        [TestMethod]
        public void Should_Not_Throw_Exception_If_Value_Is_Lower_Than_Expected_Limit()
        {
           TestMethod(_validValue, _limit);
        }

        [TestMethod]
        public void Should_Return_The_Same_Argument_Reference_Like_The_Checked_One()
        {
            Assert.AreEqual(_validValue, Throw.IfGreaterOrEqual(() => _validValue, _limit));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_ArgumentFunc_Is_Null()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                TestNullFunc();
                void TestNullFunc()
                {
                    Throw.IfGreaterOrEqual(NullHelper.GetNullOf<Func<int>>(), 5);
                }
            });

            Assert.AreEqual("Value cannot be null. (Parameter 'argumentFunc')", exception.Message);
        }

        private void TestMethod(int current, int limit)
        {
            Throw.IfGreaterOrEqual(() => current, limit);
        }
    }
}
