using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.ThrowHelper
{
    [TestClass]
    public class ThrowIfNotEqualsToTest
    {
        private const string ArgumentFuncName = "argumentFunc";
        private readonly bool _expectedValue = true;
        private readonly object _nullArgument = null;
        private readonly Func<bool> _nullArgumentFunc = null;

        [TestMethod]
        public void Should_Throw_An_Exception_If_Value_Is_Not_Equal()
        {
            Assert.ThrowsException<ArgumentException>(() => Throw.IfNotEqualsTo(() => _expectedValue, false), nameof(_expectedValue));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_Correct_Message_If_Value_Is__Not_Equal()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => Throw.IfNotEqualsTo(() => _expectedValue, false), nameof(_expectedValue));

            Assert.IsTrue(exception.Message.Contains($"The argument value: '{_expectedValue}' is not equal to: '{false}'."));
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Value_Is_Equal()
        {
            Throw.IfNotEqualsTo(() => _expectedValue, true);
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_ArgumentFunc_Is_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Throw.IfNotEqualsTo(_nullArgumentFunc, _expectedValue), ArgumentFuncName);
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Argument_Is_Null()
        {
            Throw.IfNotEqualsTo(() => _nullArgument, null);
        }
    }
}
