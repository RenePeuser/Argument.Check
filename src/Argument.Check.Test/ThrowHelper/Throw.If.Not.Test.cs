using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.ThrowHelper
{
    [TestClass]
    public class ThrowIfNotTest
    {
        private readonly bool _falseValue = false;
        private readonly string _message = "You can call Shenlong only once a year.";

        [TestMethod]
        public void Should_Throw_An_Exception_If_Predicate_Is_True()
        {
            Assert.ThrowsException<ArgumentException>(() => TestMethod(_falseValue, item => item));
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Predicate_Is_True()
        {
            TestMethod(_falseValue, item => !item);
        }

        [TestMethod]
        public void Should_Return_The_Same_Argument_Reference_Like_The_Checked_One_Wihtout_Message()
        {
            Assert.AreEqual(_falseValue, Throw.IfNot(() => _falseValue, item => !item));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_Predicate_Is_True_With_The_Given_Message()
        {
            Assert.ThrowsException<ArgumentException>(() => TestMethod(_falseValue, item => item, _message));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_The_Correct_Message_If_Predicate_Is_True()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => TestMethod(_falseValue, item => item, _message));

            Assert.IsTrue(exception.Message.Contains(_message));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_The_Correct_Message_Which_Contains_The_Correct_ArgumentName_If_Predicate_Is_True()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => TestMethod(_falseValue, item => item, _message));

            Assert.AreEqual("You can call Shenlong only once a year. (Parameter 'argument')", exception.Message);
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Predicate_Is_False_With_The_Given_Message()
        {
            TestMethod(_falseValue, item => !item, _message);
        }

        [TestMethod]
        public void Should_Return_The_Same_Argument_Reference_Like_The_Checked_One()
        {
            Assert.AreEqual(_falseValue, Throw.IfNot(() => _falseValue, item => !item, _message));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_ArgumentFunc_Is_Null()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                TestNullFunc();
                void TestNullFunc()
                {
                    Throw.IfNot(NullHelper.GetNullOf<Func<object>>(), _ => true);
                }
            });

            Assert.AreEqual("Value cannot be null. (Parameter 'argumentFunc')", exception.Message);
        }

        private void TestMethod(bool argument, Func<bool, bool> predicate)
        {
            Throw.IfNot(() => argument, predicate);
        }

        private void TestMethod(bool argument, Func<bool, bool> predicate, string message)
        {
            Throw.IfNot(() => argument, predicate, message);
        }
    }
}
