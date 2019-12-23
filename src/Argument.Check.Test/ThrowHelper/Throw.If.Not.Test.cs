using System;
using Argument.Check.ThrowHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.ThrowHelper
{
    [TestClass]
    public class ThrowIfNotTest
    {
        private const Func<bool> NullFunc = null;
        private readonly string _argumentFuncName = "argumentFunc";
        private readonly bool _falseValue = false;
        private readonly string _message = "You can call Shenlong only once a year.";

        [TestMethod]
        public void Should_Throw_An_Exception_If_Predicate_Is_True()
        {
            Assert.ThrowsException<ArgumentException>(() => Throw.IfNot(() => _falseValue, item => item), nameof(_falseValue));
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Predicate_Is_True()
        {
            Throw.IfNot(() => _falseValue, item => !item);
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_ArgumentFunc_Is_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Throw.IfNot(NullFunc, item => item), _argumentFuncName);
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_Predicate_Is_True_With_The_Given_Message()
        {
            Assert.ThrowsException<ArgumentException>(() => Throw.IfNot(() => _falseValue, item => item, _message), nameof(_falseValue));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_The_Correct_Message_If_Predicate_Is_True()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => Throw.IfNot(() => _falseValue, item => item, _message), nameof(_falseValue));

            Assert.IsTrue(exception.Message.Contains(_message));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_The_Correct_Message_Which_Contains_The_Correct_ArgumentName_If_Predicate_Is_True()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => Throw.IfNot(() => _falseValue, item => item, _message), nameof(_falseValue));

            Assert.IsTrue(exception.Message.Contains(nameof(_falseValue)));
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Predicate_Is_False_With_The_Given_Message()
        {
            Throw.IfNot(() => _falseValue, item => !item, _message);
        }
    }
}
