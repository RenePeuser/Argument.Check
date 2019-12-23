using System;
using Argument.Check.ThrowHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.ThrowHelper
{
    [TestClass]
    public class ThrowIfGreaterOrEqualTest
    {
        private const string ArgumentFuncName = "argumentFunc";
        private readonly int _greaterValue = 84;
        private readonly int _limit = 42;
        private readonly Func<int> _nullArgumentFunc = null;
        private readonly int _validValue = 1;

        [TestMethod]
        public void Should_Throw_Exception_If_Value_Is_Equal_To_Expected_Limit()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Throw.IfGreaterOrEqual(() => _limit, _limit), nameof(_limit));
        }

        [TestMethod]
        public void Should_Throw_Exception_If_Value_Is_Greater_To_Expected_Limit()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Throw.IfGreaterOrEqual(() => _greaterValue, _limit), nameof(_limit));
        }

        [TestMethod]
        public void Should_Throw_Exception_With_Correct_Message_If_Value_Is_Equal_To_Expected_Limit()
        {
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() => Throw.IfGreaterOrEqual(() => _greaterValue, _limit), nameof(_limit));

            Assert.IsTrue(exception.Message.Contains($"Value: '{_greaterValue}' must not be greater than or equal to: '{_limit}'."));
        }

        [TestMethod]
        public void Should_Not_Throw_Exception_If_Value_Is_Lower_Than_Expected_Limit()
        {
            Throw.IfGreaterOrEqual(() => _validValue, _limit);
        }

        [TestMethod]
        public void Should_Throw_Exception_If_ArgumentFunc_Is_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Throw.IfGreaterOrEqual(_nullArgumentFunc, _limit), nameof(ArgumentFuncName));
        }
    }
}
