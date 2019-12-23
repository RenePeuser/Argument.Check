using System;
using Argument.Check.ThrowHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.ThrowHelper
{
    [TestClass]
    public class ThrowIfOutOfRangeTest
    {
        private const string ArgumentFuncName = "argumentFunc";

        private readonly int _lowerLimit = 5;
        private readonly Func<int> _nullArgumentFunc = null;
        private readonly int _upperLimit = 9;
        private readonly int _valueHigherThanUpperLimit = 42;
        private readonly int _valueInRange = 7;
        private readonly int _valueLowerThanLowerLimit = 1;

        [TestMethod]
        public void Should_Throw_An_Exception_If_Value_Is_Higher_Than_Upper_Limit()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Throw.IfOutOfRange(() => _valueHigherThanUpperLimit, _lowerLimit, _upperLimit), nameof(_valueHigherThanUpperLimit));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_Value_Is_Lower_Than_Lower_Limit()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Throw.IfOutOfRange(() => _valueLowerThanLowerLimit, _lowerLimit, _upperLimit), nameof(_valueLowerThanLowerLimit));
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Value_Is_In_Range()
        {
            Throw.IfOutOfRange(() => _valueInRange, _lowerLimit, _upperLimit);
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Value_Is_Equal_To_Lower_Limit()
        {
            Throw.IfOutOfRange(() => _lowerLimit, _lowerLimit, _upperLimit);
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Value_Is_Equal_To_Upper_Limit()
        {
            Throw.IfOutOfRange(() => _upperLimit, _lowerLimit, _upperLimit);
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_ArgumentFunc_Is_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Throw.IfOutOfRange(_nullArgumentFunc, _lowerLimit, _upperLimit), ArgumentFuncName);
        }
    }
}
