using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#pragma warning disable 649

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
        private readonly IEnumerable<string> _nullEnumerableFunc;

        [TestMethod]
        public void Should_Throw_An_Exception_If_String_Is_Not_Empty()
        {
            _ = Assert.ThrowsException<ArgumentException>(() => TestMethod(_notEmptyString));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_Correct_Message_If_String_Is_Not_Empty()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => TestMethod(_notEmptyString));

            Assert.AreEqual("The string must be empty. (Parameter 'contains')", exception.Message);
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_When_String_Is_Valid()
        {
            TestMethod(_emptyString);
        }

        [TestMethod]
        public void Should_Return_The_Same_String_Argument_Reference_Like_The_Checked_One()
        {
            Assert.AreEqual(_emptyString, Throw.IfNotEmpty(_emptyString));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_Strings_Are_Empty()
        {
            _ = Assert.ThrowsException<ArgumentException>(() => TestMethod(_notEmptyStrings));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_Correct_Message_If_Strings_Are_Empty()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => TestMethod(_notEmptyStrings));

            Assert.AreEqual("The enumerable must be empty. (Parameter 'source')", exception.Message);
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_When_Strings_Are_Not_Empty()
        {
            TestMethod(_emptyStrings);
        }

        [TestMethod]
        public void Should_Return_The_Same_String_Sequence_Reference_Like_The_Checked_One()
        {
            Assert.AreEqual(_emptyStrings, Throw.IfNotEmpty(_emptyStrings));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_Enumerable_ArgumentFunc_Is_Null()
        {
            _ = Assert.ThrowsException<ArgumentNullException>(() => Throw.IfNotEmpty(_nullEnumerableFunc), ArgumentFuncName);
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_String_ArgumentFunc_Is_Null()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                TestNullFunc();

                static void TestNullFunc()
                {
                    _ = Throw.IfNotEmpty(NullHelper.GetNullOf<Func<string>>());
                }
            });

            Assert.AreEqual("Value cannot be null. (Parameter 'argumentFunc')", exception.Message);
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_Enumeration_ArgumentFunc_Is_Null()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                TestNullFunc();

                static void TestNullFunc()
                {
                    _ = Throw.IfNotEmpty(NullHelper.GetNullOf<IEnumerable<string>>());
                }
            });

            Assert.AreEqual("Value cannot be null. (Parameter 'argumentFunc')", exception.Message);
        }

        private void TestMethod(string contains)
        {
            _ = Throw.IfNotEmpty(contains);
        }

        private void TestMethod<T>(IEnumerable<T> source)
        {
            _ = Throw.IfNotEmpty(source);
        }
    }
}