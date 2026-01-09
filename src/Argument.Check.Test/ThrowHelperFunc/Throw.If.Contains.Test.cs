namespace Argument.Check.Test.ThrowHelperFunc
{
    [TestClass]
    public class ThrowIfContainsTest
    {
        private const string ArgumentName = "contains";
        private const string Vegeta = "Vegeta";
        private readonly string _containedValue = Vegeta;
        private readonly string _nullArgument = null!;
        private readonly IEnumerable<string> _stringValues = new[] { Vegeta, "Beerus" };
        private readonly string _valueNotContained = "SonGoku";

        [TestMethod]
        public void Should_Throw_An_Exception_If_Value_Is_Not_In_Expected_Source()
        {
            _ = Assert.ThrowsExactly<ArgumentException>(() => TestMethod(_containedValue, _stringValues));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_Expected_Message_If_Value_Is_Not_In_Expected_Source()
        {
            var exception = Assert.ThrowsExactly<ArgumentException>(() => TestMethod(_containedValue, _stringValues), nameof(_containedValue));

            Assert.Contains($"The argument '{Vegeta}' is contained in the enumeration. (Parameter '{ArgumentName}')", exception.Message);
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Value_Is_Not_In_Expected_Source()
        {
            TestMethod(_valueNotContained, _stringValues);
        }

        [TestMethod]
        public void Should_Return_The_Same_Argument_Reference_Like_The_Checked_One()
        {
            Assert.AreEqual(_valueNotContained, Throw.IfContains(_valueNotContained, _stringValues));
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Argument_Is_Null()
        {
            TestMethod(_nullArgument, _stringValues);
        }

        private void TestMethod<T>(T contains, IEnumerable<T> source)
        {
            _ = Throw.IfContains(contains, source);
        }
    }
}
