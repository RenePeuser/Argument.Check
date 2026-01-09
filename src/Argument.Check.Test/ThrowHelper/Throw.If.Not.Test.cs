#pragma warning disable 649

namespace Argument.Check.Test.ThrowHelper
{
    [TestClass]
    public class ThrowIfNotTest
    {
        private readonly bool _falseValue;
        private readonly string _message = "You can call Shenlong only once a year.";

        [TestMethod]
        public void Should_Throw_An_Exception_If_Predicate_Is_True()
        {
            _ = Assert.ThrowsExactly<ArgumentException>(() => TestMethod(_falseValue, item => item, "Value must be false"));
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Predicate_Is_True()
        {
            TestMethod(_falseValue, item => !item, "Value must be true");
        }

        [TestMethod]
        public void Should_Return_The_Same_Argument_Reference_Like_The_Checked_One_Wihtout_Message()
        {
            Assert.AreEqual(_falseValue, Throw.IfNot(_falseValue, item => !item, "Value must be true"));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_Predicate_Is_True_With_The_Given_Message()
        {
            _ = Assert.ThrowsExactly<ArgumentException>(() => TestMethod(_falseValue, item => item, _message));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_The_Correct_Message_If_Predicate_Is_True()
        {
            var exception = Assert.ThrowsExactly<ArgumentException>(() => TestMethod(_falseValue, item => item, _message));

            Assert.Contains(_message, exception.Message);
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_The_Correct_Message_Which_Contains_The_Correct_ArgumentName_If_Predicate_Is_True()
        {
            var exception = Assert.ThrowsExactly<ArgumentException>(() => TestMethod(_falseValue, item => item, _message));

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
            Assert.AreEqual(_falseValue, Throw.IfNot(_falseValue, item => !item, _message));
        }

        private void TestMethod(bool argument, Func<bool, bool> predicate, string message)
        {
            _ = Throw.IfNot(argument, predicate, message);
        }
    }
}
