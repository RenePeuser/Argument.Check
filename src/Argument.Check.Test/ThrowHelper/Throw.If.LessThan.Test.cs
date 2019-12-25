using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.ThrowHelper
{
    [TestClass]
    public class ThrowIfLessThanTest
    {
        private const string ArgumentFuncName = "argumentFunc";
        private readonly int _limit = 42;
        private readonly Func<int> _nullArgumentFunc = null;
        private readonly int _smallerValue = 21;
        private readonly int _validValue = 84;

        [TestMethod]
        public void Should_Throw_Exception_If_Value_Is_Smaller_To_Expected_Limit()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Throw.IfLessThan(() => _smallerValue, _limit), nameof(_limit));
        }

        [TestMethod]
        public void Should_Throw_Exception_With_Correct_Message_If_Value_Is_Equal_To_Expected_Limit()
        {
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() => Throw.IfLessThan(() => _smallerValue, _limit), nameof(_limit));

            Assert.IsTrue(exception.Message.Contains($"Value: '{_smallerValue}' must not be less than: '{_limit}'."));
        }

        [TestMethod]
        public void Should_Not_Throw_Exception_If_Value_Is_Lower_Than_Expected_Limit()
        {
            Throw.IfLessThan(() => _validValue, _limit);
        }

        [TestMethod]
        public void Should_Throw_Exception_If_ArgumentFunc_Is_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Throw.IfLessThan(_nullArgumentFunc, _limit), nameof(ArgumentFuncName));
        }
    }
}
