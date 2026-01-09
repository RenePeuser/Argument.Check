namespace Argument.Check.Test.ThrowHelper
{
    [TestClass]
    public class ThrowIfOutOfRangeTest
    {
        private readonly int _lowerLimit = 5;
        private readonly int _upperLimit = 9;
        private readonly int _valueHigherThanUpperLimit = 42;
        private readonly int _valueInRange = 7;
        private readonly int _valueLowerThanLowerLimit = 1;

        [TestMethod]
        public void Should_Throw_An_Exception_If_Value_Is_Higher_Than_Upper_Limit()
        {
            _ = Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => TestMethod(_valueHigherThanUpperLimit, _lowerLimit, _upperLimit));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_Value_Is_Lower_Than_Lower_Limit()
        {
            _ = Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => TestMethod(_valueLowerThanLowerLimit, _lowerLimit, _upperLimit));
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Value_Is_In_Range()
        {
            TestMethod(_valueInRange, _lowerLimit, _upperLimit);
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Value_Is_Equal_To_Lower_Limit()
        {
            TestMethod(_lowerLimit, _lowerLimit, _upperLimit);
        }

        [TestMethod]
        public void Should_Return_The_Same_LowerLimit_Argument_Reference_Like_The_Checked_One()
        {
            Assert.AreEqual(_lowerLimit, Throw.IfOutOfRange(_lowerLimit, _lowerLimit, _upperLimit));
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Value_Is_Equal_To_Upper_Limit()
        {
            TestMethod(_upperLimit, _lowerLimit, _upperLimit);
        }

        [TestMethod]
        public void Should_Return_The_Same_UpperLimit_Argument_Reference_Like_The_Checked_One()
        {
            Assert.AreEqual(_upperLimit, Throw.IfOutOfRange(_upperLimit, _lowerLimit, _upperLimit));
        }
        private void TestMethod(int value, int lower, int upper)
        {
            _ = Throw.IfOutOfRange(value, lower, upper);
        }
    }
}
