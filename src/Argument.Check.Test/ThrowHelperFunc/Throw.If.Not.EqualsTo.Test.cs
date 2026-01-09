namespace Argument.Check.Test.ThrowHelperFunc
{
    [TestClass]
    public class ThrowIfNotEqualsToTest
    {
        [TestMethod]
        public void Should_Throw_An_Exception_If_Value_Is_Not_Equal()
        {
            _ = Assert.ThrowsExactly<ArgumentException>(() => TestMethod(true, false));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_Correct_Message_If_Value_Is__Not_Equal()
        {
            var exception = Assert.ThrowsExactly<ArgumentException>(() => TestMethod(true, false));

            Assert.AreEqual("The argument value: 'True' is not equal to: 'False'. (Parameter 'argument')", exception.Message);
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Value_Is_Equal()
        {
            TestMethod(true, true);
        }

        [TestMethod]
        public void Should_Return_The_Same_Argument_Reference_Like_The_Checked_One()
        {
            Assert.IsTrue(Throw.IfNotEqualsTo(true, true));
        }

        private void TestMethod(object argument, object expected)
        {
            _ = Throw.IfNotEqualsTo(argument, expected);
        }
    }
}
