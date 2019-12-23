using System;
using Argument.Check.ThrowHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.ThrowHelper
{
    [TestClass]
    public class ThrowIfTest
    {
        private const Func<bool> NullFunc = null;
        private readonly string _argumentFuncName = "argumentFunc";
        private readonly string _message = "You can call Shenlong only once a year.";
        private readonly bool _trueValue = true;

        [TestMethod]
        public void Should_Throw_An_Exception_If_Predicate_Is_True()
        {
            Assert.ThrowsException<ArgumentException>(() => Throw.If(() => _trueValue, item => item), nameof(_trueValue));
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Predicate_Is_True()
        {
            Throw.If(() => _trueValue, item => !item);
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_ArgumentFunc_Is_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Throw.If(NullFunc, item => item), _argumentFuncName);
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_Predicate_Is_True_With_The_Given_Message()
        {
            Assert.ThrowsException<ArgumentException>(() => Throw.If(() => _trueValue, item => item, _message), nameof(_trueValue));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_The_Correct_Message_If_Predicate_Is_True()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => Throw.If(() => _trueValue, item => item, _message), nameof(_trueValue));

            Assert.IsTrue(exception.Message.Contains(_message));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_The_Correct_Message_Which_Contains_The_Correct_ArgumentName_If_Predicate_Is_True()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => Throw.If(() => _trueValue, item => item, _message), nameof(_trueValue));

            Assert.IsTrue(exception.Message.Contains(nameof(_trueValue)));
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Predicate_Is_False_With_The_Given_Message()
        {
            Throw.If(() => _trueValue, item => !item, _message);
        }
    }
}
