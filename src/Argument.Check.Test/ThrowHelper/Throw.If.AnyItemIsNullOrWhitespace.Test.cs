using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.ThrowHelper
{
    [TestClass]
    public class ThrowIfAnyItemIsNullOrWhitespace
    {
        private const string SonGoku = "SonGoku";
        private const string Vegeta = "Vegeta";
        private const string ArgumentName = "strings";

        private readonly IEnumerable<string> _validStrings = new[] { SonGoku };
        private readonly IEnumerable<string> _valuesWithAnEmptyString = new[] { SonGoku, string.Empty };
        private readonly IEnumerable<string> _valuesWithOneNull = new[] { SonGoku, null };
        private readonly IEnumerable<string> _valuesWithOneWhitespace = new[] { SonGoku, " ", Vegeta };

        [TestMethod]
        public void Should_Throw_An_Exception_If_Any_Item_Is_Empty()
        {
            _ = Assert.ThrowsException<ArgumentException>(() => TestMethod(_valuesWithOneNull), ArgumentName);
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_Any_Item_Is_A_Whitespace()
        {
            _ = Assert.ThrowsException<ArgumentException>(() => TestMethod(_valuesWithOneWhitespace), ArgumentName);
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_Any_Item_Is_A_Null()
        {
            _ = Assert.ThrowsException<ArgumentException>(() => TestMethod(_valuesWithOneNull), ArgumentName);
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_When_Strings_Are_Valid()
        {
            TestMethod(_validStrings);
        }

        [TestMethod]
        public void Should_Return_The_Same_Argument_Reference_Like_The_Checked_One()
        {
            Assert.AreEqual(_validStrings, Throw.IfAnyItemIsNullOrWhitespace(_validStrings));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_Correct_Information()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => TestMethod(_valuesWithOneWhitespace), nameof(_valuesWithAnEmptyString));

            Assert.IsTrue(exception.Message.Contains($"At least one string in the enumeration '{SonGoku}, ,{Vegeta}' was null or a whitespace."));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_ArgumentFunc_Is_Null()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                TestNullFunc();

                static void TestNullFunc()
                {
                    _ = Throw.IfAnyItemIsNullOrWhitespace(NullHelper.GetNullOf<IEnumerable<string>>());
                }
            });

            Assert.AreEqual("Value cannot be null. (Parameter 'argumentFunc')", exception.Message);
        }

        private void TestMethod(IEnumerable<string> strings)
        {
            _ = Throw.IfAnyItemIsNullOrWhitespace(strings);
        }
    }
}