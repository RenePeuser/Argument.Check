using Extensions.Pack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.ThrowHelperFunc
{
    [TestClass]
    public class ThrowIfNullOrAnyTest
    {
        private readonly IEnumerable<string?> _listWithNullItem = new[] { "Vegeta", "Beerus", null };
        private readonly IEnumerable<string> _listWithoutNullItem = new[] { "Vegeta", "Beerus" };
#pragma warning disable CS0649
        private readonly IEnumerable<string>? _nullArgument;
#pragma warning restore CS0649

        [TestMethod]
        public void Should_Throw_An_Exception_If_Any_Item_In_The_Source_Match_The_Given_Predicate()
        {
            _ = Assert.ThrowsException<ArgumentException>(() => TestMethod(_listWithNullItem, x => x.IsNotNull() && x.Contains("Vegeta")));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_Correct_Message_If_Any_Item_In_The_Source_Is_Null()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => TestMethod(_listWithNullItem, x => x.IsNotNull() && x.Contains("Vegeta")));

            Assert.IsTrue(exception.Message.Contains("The sequence must not contain any items that satisfy the given predicate:"));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_Argument_Is_Null()
        {
            _ = Assert.ThrowsException<ArgumentNullException>(() => TestMethod(_nullArgument, x => x?.Length == 1), nameof(_nullArgument));
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Source_Is_Not_Null_And_Does_Not_Contains_Null_Items()
        {
            TestMethod(_listWithoutNullItem, x => x == "ShenLong");
        }

        [TestMethod]
        public void Should_Return_The_Same_Argument_Reference_Like_The_Checked_One()
        {
            Assert.AreEqual(_listWithoutNullItem, Throw.IfNullOrAny(_listWithoutNullItem, x => x == "ShenLong"));
        }

        private void TestMethod(IEnumerable<string?>? values, Func<string?, bool> anyFunc)
        {
            _ = Throw.IfNullOrAny(values, anyFunc);
        }
    }
}
