using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.ThrowHelper
{
    [TestClass]
    public class ThrowIfNotEmpty
    {
        private const string ArgumentFuncName = "argumentFunc";

        private readonly string _emptyString = string.Empty;
        private readonly IEnumerable<string> _emptyStrings = Enumerable.Empty<string>();
        private readonly string _notEmptyString = "Vegeta";
        private readonly IEnumerable<string> _notEmptyStrings = new[] { "SonGoku" };
        private readonly Func<IEnumerable<string>> _nullEnumerableFunc = null;
        private readonly Func<string> _nullStringFunc = null;

        [TestMethod]
        public void Should_Throw_An_Exception_If_String_Is_Not_Empty()
        {
            Assert.ThrowsException<ArgumentException>(() => Throw.IfNotEmpty(() => _notEmptyString), nameof(_notEmptyString));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_Correct_Message_If_String_Is_Not_Empty()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => Throw.IfNotEmpty(() => _notEmptyString), nameof(_notEmptyString));

            Assert.IsTrue(exception.Message.Contains("The string must be empty."));
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_When_String_Is_Valid()
        {
            Throw.IfNotEmpty(() => _emptyString);
        }

        [TestMethod]
        public void Should_Return_The_Same_String_Argument_Reference_Like_The_Checked_One()
        {
            Assert.AreEqual(_emptyString, Throw.IfNotEmpty(() => _emptyString));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_Strings_Are_Empty()
        {
            Assert.ThrowsException<ArgumentException>(() => Throw.IfNotEmpty(() => _notEmptyStrings), nameof(_notEmptyStrings));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_Correct_Message_If_Strings_Are_Empty()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => Throw.IfNotEmpty(() => _notEmptyStrings), nameof(_notEmptyStrings));

            Assert.IsTrue(exception.Message.Contains("The enumerable must be empty."));
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_When_Strings_Are_Not_Empty()
        {
            Throw.IfNotEmpty(() => _emptyStrings);
        }

        [TestMethod]
        public void Should_Return_The_Same_String_Sequence_Reference_Like_The_Checked_One()
        {
            Assert.AreEqual(_emptyStrings, Throw.IfNotEmpty(() => _emptyStrings));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_Enumerable_ArgumentFunc_Is_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Throw.IfNotEmpty(_nullEnumerableFunc), ArgumentFuncName);
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_String_ArgumentFunc_Is_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Throw.IfNotEmpty(_nullStringFunc), ArgumentFuncName);
        }
    }
}
