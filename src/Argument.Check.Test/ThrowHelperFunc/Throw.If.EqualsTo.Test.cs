#pragma warning disable 649

namespace Argument.Check.Test.ThrowHelperFunc
{
    [TestClass]
    public class ThrowIfEqualsToTest
    {
        private readonly bool _expectedValue = true;
        private readonly object? _nullArgument;

        [TestMethod]
        public void Should_Throw_An_Exception_If_Value_Is_Equal()
        {
            _ = Assert.ThrowsExactly<ArgumentException>(() => TestMethod(_expectedValue, _expectedValue));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_Correct_Message_If_Value_Is_Equal()
        {
            var exception = Assert.ThrowsExactly<ArgumentException>(() => TestMethod(_expectedValue, _expectedValue));

            Assert.Contains($"The argument value: '{_expectedValue}' was equal to: '{_expectedValue}'.", exception.Message);
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Value_Is_Not_Equal()
        {
            _ = Throw.IfEqualsTo(_expectedValue, false);
        }

        [TestMethod]
        public void Should_Return_The_Same_Argument_Reference_Like_The_Checked_One()
        {
            Assert.AreEqual(_expectedValue, Throw.IfEqualsTo(_expectedValue, false));
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Argument_Is_Null()
        {
            _ = Throw.IfEqualsTo(_nullArgument, _expectedValue);
        }

        private void TestMethod<T>(T argument, T expected)
        {
            _ = Throw.IfEqualsTo(argument, expected);
        }
    }
}
