using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.ThrowHelper
{
    [TestClass]
    public class ThrowIfNullOrAnyTest
    {
        private readonly IEnumerable<string> _listWithNullItem = new[] { "Vegeta", "Beerus", null };
        private readonly IEnumerable<string> _listWithoutNullItem = new[] { "Vegeta", "Beerus" };
        private readonly IEnumerable<string> _nullArgument = null;

        [TestMethod]
        public void Should_Throw_An_Exception_If_Any_Item_In_The_Source_Match_The_Given_Predicate()
        {
            Assert.ThrowsException<ArgumentException>(() => TestMethod(_listWithNullItem, x => x.Contains("Vegeta")));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_Correct_Message_If_Any_Item_In_The_Source_Is_Null()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => TestMethod(_listWithNullItem, x => x.Contains("Vegeta")));

            Assert.IsTrue(exception.Message.Contains("The sequence must not contain any items that satisfy the given predicate:"));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_Argument_Is_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => TestMethod(_nullArgument, x => x.Length == 1), nameof(_nullArgument));
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Source_Is_Not_Null_And_Does_Not_Contains_Null_Items()
        {
            TestMethod(_listWithoutNullItem, x => x == "ShenLong");
        }

        [TestMethod]
        public void Should_Return_The_Same_Argument_Reference_Like_The_Checked_One()
        {
            Assert.AreEqual(_listWithoutNullItem, Throw.IfNullOrAny(() => _listWithoutNullItem, x => x == "ShenLong"));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_Enumeration_ArgumentFunc_Is_Null()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                TestNullFunc();
                static void TestNullFunc()
                {
                    Throw.IfNullOrAny(NullHelper.GetNullOf<Func<string>>(), _ => true);
                }
            });

            Assert.AreEqual("Value cannot be null. (Parameter 'argumentFunc')", exception.Message);
        }

        private void TestMethod(IEnumerable<string> values, Func<string, bool> anyFunc)
        {
            Throw.IfNullOrAny(() => values, anyFunc);
        }
    }
}
