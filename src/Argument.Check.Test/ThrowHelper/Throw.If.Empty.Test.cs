using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.ThrowHelper
{
    [TestClass]
    public class ThrowIfEmpty
    {
        private const string ArgumentFuncName = "argumentFunc";
        private const string SonGoku = "SonGoku";
        private readonly string _emptyString = string.Empty;
        private readonly IEnumerable<string> _emptyStrings = Enumerable.Empty<string>();
        private readonly IEnumerable<string> _notEmptyStrings = new[] { SonGoku };
        private readonly Func<IEnumerable<string>> _nullEnumerableFunc = null;
        private readonly Func<string> _nullStringFunc = null;

        [TestMethod]
        public void Should_Throw_An_Exception_If_String_Is_Empty()
        {
            Assert.ThrowsException<ArgumentException>(() => Throw.IfEmpty(() => _emptyString), nameof(_emptyString));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_Correct_Message_If_String_Is_Empty()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => Throw.IfEmpty(() => _emptyString), nameof(_emptyString));

            Assert.IsTrue(exception.Message.Contains("The string must not be empty."));
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_When_String_Is_Valid()
        {
            Throw.IfEmpty(() => SonGoku);
        }

        [TestMethod]
        public void Should_Return_The_Same_String_Argument_Reference_Like_The_Checked_One()
        {
            Assert.AreEqual(SonGoku, Throw.IfEmpty(() => SonGoku));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_Strings_Are_Empty()
        {
            Assert.ThrowsException<ArgumentException>(() => Throw.IfEmpty(() => _emptyStrings), nameof(_emptyStrings));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_Correct_Message_If_Strings_Are_Empty()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => Throw.IfEmpty(() => _emptyStrings), nameof(_emptyStrings));

            Assert.IsTrue(exception.Message.Contains("The enumerable must not be empty."));
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_When_Strings_Are_Not_Empty()
        {
            Throw.IfEmpty(() => _notEmptyStrings);
        }

        [TestMethod]
        public void Should_Return_The_Same_String_Enumeration_Reference_Like_The_Checked_One()
        {
            Assert.AreEqual(_notEmptyStrings, Throw.IfEmpty(() => _notEmptyStrings));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_Enumerable_ArgumentFunc_Is_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Throw.IfEmpty(_nullEnumerableFunc), ArgumentFuncName);
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_String_ArgumentFunc_Is_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Throw.IfEmpty(_nullStringFunc), ArgumentFuncName);
        }
    }
}
