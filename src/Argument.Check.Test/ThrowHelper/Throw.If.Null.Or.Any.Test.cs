using System;
using System.Collections.Generic;
using Argument.Check.ThrowHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.ThrowHelper
{
    [TestClass]
    public class ThrowIfNullOrAnyTest
    {
        private const string ArgumentFuncName = "argumentFunc";
        private readonly IEnumerable<string> _listWithNullItem = new[] { "Vegeta", "Beerus", null };
        private readonly IEnumerable<string> _listWithoutNullItem = new[] { "Vegeta", "Beerus" };
        private readonly IEnumerable<string> _nullArgument = null;
        private readonly Func<IEnumerable<string>> _nullArgumentFunc = null;

        [TestMethod]
        public void Should_Throw_An_Exception_If_Any_Item_In_The_Source_Match_The_Given_Predicate()
        {
            Assert.ThrowsException<ArgumentException>(() => Throw.IfNullOrAny(() => _listWithNullItem, x => x.Contains("Vegeta")), nameof(_listWithNullItem));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_Correct_Message_If_Any_Item_In_The_Source_Is_Null()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => Throw.IfNullOrAny(() => _listWithNullItem, x => x.Contains("Vegeta")), nameof(_listWithNullItem));

            Assert.IsTrue(exception.Message.Contains("The sequence must not contain any items that satisfy the given predicate: "));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_Argument_Is_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Throw.IfNullOrAny(() => _nullArgument, x => x.Length == 1), nameof(_nullArgument));
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Source_Is_Not_Null_And_Does_Not_Contains_Null_Items()
        {
            Throw.IfNullOrAny(() => _listWithoutNullItem, x => x == "ShenLong");
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_ArgumentFunc_Is_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Throw.IfNullOrAny(_nullArgumentFunc, x => x.Length == 1), ArgumentFuncName);
        }
    }
}
