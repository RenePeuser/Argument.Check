#pragma warning disable 649

namespace Argument.Check.Test.ThrowHelperFunc
{
    [TestClass]
    public class ThrowIfWhiteSpaceTest
    {
        private readonly string? _nullStringArgument;
        private readonly string _sonGoku = "SonGoku";
        private readonly string _whiteSpace = " ";


        [TestMethod]
        public void Should_Throw_An_Exception_If_String_Is_WhiteSpace()
        {
            _ = Assert.ThrowsExactly<ArgumentException>(() => TestMethod(_whiteSpace));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_Correct_Message_If_String_Is_WhiteSpace()
        {
            var exception = Assert.ThrowsExactly<ArgumentException>(() => TestMethod(_whiteSpace));

            Assert.Contains("The string must not be only whitespace.", exception.Message);
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_String_Is_Null()
        {
            _ = Assert.ThrowsExactly<ArgumentNullException>(() => TestMethod(_nullStringArgument), nameof(_nullStringArgument));
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_String_Is_Not_Null_And_Does_Not_Contains_Null_Items()
        {
            TestMethod(_sonGoku);
        }

        [TestMethod]
        public void Should_Return_The_Same_String_Argument_Reference_Like_The_Checked_One()
        {
            Assert.AreEqual(_sonGoku, Throw.IfWhitespace(_sonGoku));
        }

        private void TestMethod(string? contains)
        {
            _ = Throw.IfWhitespace(contains);
        }
    }
}
