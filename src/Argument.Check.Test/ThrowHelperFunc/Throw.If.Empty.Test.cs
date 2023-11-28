using Microsoft.VisualStudio.TestTools.UnitTesting;

#pragma warning disable 649

namespace Argument.Check.Test.ThrowHelperFunc
{
    [TestClass]
    public class ThrowIfEmpty
    {
        private const string SonGoku = "SonGoku";
        private readonly string _emptyString = string.Empty;
        private readonly IEnumerable<string> _emptyStrings = Enumerable.Empty<string>();
        private readonly IEnumerable<string> _notEmptyStrings = new[] { SonGoku };

        [TestMethod]
        public void Should_Throw_An_Exception_If_String_Is_Empty()
        {
            _ = Assert.ThrowsException<ArgumentException>(() => TestMethod(_emptyString));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_Correct_Message_If_String_Is_Empty()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => TestMethod(_emptyString));

            Assert.IsTrue(exception.Message.Contains($"The string must not be empty. (Parameter 'contains')"));
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_When_String_Is_Valid()
        {
            TestMethod(SonGoku);
        }

        [TestMethod]
        public void Should_Return_The_Same_String_Argument_Reference_Like_The_Checked_One()
        {
            Assert.AreEqual(SonGoku, Throw.IfEmpty(SonGoku));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_Strings_Are_Empty()
        {
            _ = Assert.ThrowsException<ArgumentException>(() => TestMethod(_emptyStrings));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_Correct_Message_If_Strings_Are_Empty()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => TestMethod(_emptyStrings));

            Assert.IsTrue(exception.Message.Contains("The enumerable must not be empty. (Parameter 'source')"));
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_When_Strings_Are_Not_Empty()
        {
            TestMethod(_notEmptyStrings);
        }

        [TestMethod]
        public void Should_Return_The_Same_String_Enumeration_Reference_Like_The_Checked_One()
        {
            Assert.AreEqual(_notEmptyStrings, Throw.IfEmpty(_notEmptyStrings));
        }

        private void TestMethod(string contains)
        {
            _ = Throw.IfEmpty(contains);
        }

        private void TestMethod<T>(IEnumerable<T> source)
        {
            _ = Throw.IfEmpty(source);
        }
    }
}
