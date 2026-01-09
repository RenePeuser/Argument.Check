namespace Argument.Check.Test.ThrowHelper
{
    [TestClass]
    public class ThrowIfGreaterThanTest
    {
        private readonly int _greaterValue = 84;
        private readonly int _limit = 42;
        private readonly int _validValue = 1;

        [TestMethod]
        public void Should_Throw_Exception_If_Value_Is_Greater_To_Expected_Limit()
        {
            _ = Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => TestMethod(_greaterValue, _limit));
        }

        [TestMethod]
        public void Should_Throw_Exception_With_Correct_Message_If_Value_Is_Equal_To_Expected_Limit()
        {
            var exception = Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => TestMethod(_greaterValue, _limit));

            Assert.AreEqual($"Value: '{_greaterValue}' must not be greater than: '{_limit}'. (Parameter 'current')", exception.Message);
        }

        [TestMethod]
        public void Should_Not_Throw_Exception_If_Value_Is_Lower_Than_Expected_Limit()
        {
            TestMethod(_validValue, _limit);
        }

        [TestMethod]
        public void Should_Return_The_Same_Argument_Reference_Like_The_Checked_One()
        {
            Assert.AreEqual(_validValue, Throw.IfGreaterThan(_validValue, _limit));
        }
        private void TestMethod(int current, int limit)
        {
            _ = Throw.IfGreaterThan(current, limit);
        }
    }
}
