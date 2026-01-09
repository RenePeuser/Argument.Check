#pragma warning disable 649

namespace Argument.Check.Test.ThrowHelper
{
    [TestClass]
    public class ThrowIfNotContainsTest
    {
        private const string Vegeta = "Vegeta";
        private readonly string _containedValue = Vegeta;
        private readonly string? _nullArgument;
        private readonly IEnumerable<string?> _stringValues = new[] { Vegeta, "Beerus", null };
        private readonly string _valueNotContained = "SonGoku";

        [TestMethod]
        public void Should_Throw_An_Exception_If_Value_Is_Not_In_Expected_Source()
        {
            _ = Assert.ThrowsExactly<ArgumentException>(() => TestMethod(_valueNotContained, _stringValues));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_Expected_Message_If_Value_Is_Not_In_Expected_Source()
        {
            var exception = Assert.ThrowsExactly<ArgumentException>(() => TestMethod(_valueNotContained, _stringValues));

            Assert.AreEqual($"The argument '{_valueNotContained}' is not contained in the enumeration. (Parameter 'contains')", exception.Message);
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Value_Is_In_Expected_Source()
        {
            TestMethod(_containedValue, _stringValues);
        }

        [TestMethod]
        public void Should_Return_The_Same_Argument_Reference_Like_The_Checked_One()
        {
            Assert.AreEqual(_containedValue, Throw.IfNotContains(_containedValue, _stringValues));
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Argument_Is_Null()
        {
            TestMethod(_nullArgument, _stringValues);
        }

        private void TestMethod<T>(T contains, IEnumerable<T> source)
        {
            _ = Throw.IfNotContains(contains, source);
        }
    }
}
