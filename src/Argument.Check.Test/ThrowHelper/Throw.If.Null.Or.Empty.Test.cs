using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.ThrowHelper
{
    [TestClass]
    public class ThrowIfNullOrEmptyTest
    {
        private const string ArgumentFuncName = "argumentFunc";

        private readonly IEnumerable<string> _emptyList = Enumerable.Empty<string>();


        private readonly string _emptyString = string.Empty;
        private readonly IEnumerable<string> _listWithoutNullItem = new[] { "Vegeta", "Beerus" };
        private readonly IEnumerable<string> _nullArgument = null;
        private readonly Func<IEnumerable<string>> _nullArgumentFunc = null;
        private readonly string _nullStringArgument = null;
        private readonly Func<string> _nullStringArgumentFunc = null;
        private readonly string _sonGoku = "SonGoku";


        [TestMethod]
        public void Should_Throw_An_Exception_If_Source_Is_Empty()
        {
            Assert.ThrowsException<ArgumentException>(() => Throw.IfNullOrEmpty(() => _emptyList), nameof(_emptyList));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_Correct_Message_If_Source_Is_Empty()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => Throw.IfNullOrEmpty(() => _emptyList), nameof(_emptyList));

            Assert.IsTrue(exception.Message.Contains("The enumerable must not be empty."));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_Source_Is_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Throw.IfNullOrEmpty(() => _nullArgument), nameof(_nullArgument));
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Source_Is_Not_Null_And_Does_Not_Contains_Null_Items()
        {
            Throw.IfNullOrEmpty(() => _listWithoutNullItem);
        }

        [TestMethod]
        public void Should_Return_The_Same_Enumeration_Like_The_Checked_One()
        {
            Assert.AreEqual(_listWithoutNullItem, Throw.IfNullOrEmpty(() => _listWithoutNullItem));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_Source_ArgumentFunc_Is_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Throw.IfNullOrEmpty(_nullArgumentFunc), ArgumentFuncName);
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_String_Is_Empty()
        {
            Assert.ThrowsException<ArgumentException>(() => Throw.IfNullOrEmpty(() => _emptyString), nameof(_emptyString));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_Correct_Message_If_String_Is_Empty()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => Throw.IfNullOrEmpty(() => _emptyString), nameof(_emptyString));

            Assert.IsTrue(exception.Message.Contains("The string must not be empty."));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_String_Is_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Throw.IfNullOrEmpty(() => _nullStringArgument), nameof(_nullStringArgument));
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_String_Is_Not_Null_And_Does_Not_Contains_Null_Items()
        {
            Throw.IfNullOrEmpty(() => _sonGoku);
        }

        [TestMethod]
        public void Should_Return_The_Same_String_Like_The_Checked_One()
        {
            Assert.AreEqual(_sonGoku, Throw.IfNullOrEmpty(() => _sonGoku));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_String_ArgumentFunc_Is_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Throw.IfNullOrEmpty(_nullStringArgumentFunc), ArgumentFuncName);
        }
    }
}
