#pragma warning disable 649

namespace Argument.Check.Test.ThrowHelperFunc
{
    [TestClass]
    public class ThrowIfLessThanTest
    {
        private readonly int _limit = 42;
        private readonly int _smallerValue = 21;
        private readonly int _validValue = 84;

        [TestMethod]
        public void Should_Throw_Exception_If_Value_Is_Smaller_To_Expected_Limit()
        {
            _ = Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => TestMethod(_smallerValue, _limit));
        }

        [TestMethod]
        public void Should_Throw_Exception_With_Correct_Message_If_Value_Is_Equal_To_Expected_Limit()
        {
            var exception = Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => TestMethod(_smallerValue, _limit));

            Assert.AreEqual($"Value: '{_smallerValue}' must not be less than or equal to: '{_limit}'. (Parameter 'value')", exception.Message);
        }

        [TestMethod]
        public void Should_Not_Throw_Exception_If_Value_Is_Lower_Than_Expected_Limit()
        {
            TestMethod(_validValue, _limit);
        }

        [TestMethod]
        public void Should_Return_The_Same_Argument_Reference_Like_The_Checked_One()
        {
            Assert.AreEqual(_validValue, Throw.IfLessOrEqual(_validValue, _limit));
        }
        private void TestMethod(int value, int limit)
        {
            _ = Throw.IfLessOrEqual(value, limit);
        }
    }
}
