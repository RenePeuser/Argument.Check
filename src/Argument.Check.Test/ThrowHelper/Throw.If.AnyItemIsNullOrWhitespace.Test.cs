using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.ThrowHelper
{
    [TestClass]
    public class ThrowIfAnyItemIsNullOrWhitespace
    {
        private const string ArgumentFuncName = "argumentFunc";
        private const string SonGoku = "SonGoku";
        private const string Vegeta = "Vegeta";

        private readonly IEnumerable<string> _validStrings = new[] { SonGoku };
        private readonly IEnumerable<string> _valuesWithAnEmptyString = new[] { SonGoku, string.Empty };
        private readonly IEnumerable<string> _valuesWithOneNull = new[] { SonGoku, null };
        private readonly IEnumerable<string> _valuesWithOneWhitespace = new[] { SonGoku, " ", Vegeta };

        [TestMethod]
        public void Should_Throw_An_Exception_If_Any_Item_Is_Empty()
        {
            Assert.ThrowsException<ArgumentException>(() => Throw.IfAnyItemIsNullOrWhitespace(() => _valuesWithAnEmptyString), nameof(_valuesWithAnEmptyString));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_Any_Item_Is_A_Whitespace()
        {
            Assert.ThrowsException<ArgumentException>(() => Throw.IfAnyItemIsNullOrWhitespace(() => _valuesWithOneWhitespace), nameof(_valuesWithAnEmptyString));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_Any_Item_Is_A_Null()
        {
            Assert.ThrowsException<ArgumentException>(() => Throw.IfAnyItemIsNullOrWhitespace(() => _valuesWithOneNull), nameof(_valuesWithAnEmptyString));
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_When_Strings_Are_Valid()
        {
            Throw.IfAnyItemIsNullOrWhitespace(() => _validStrings);
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_ArgumentFunc_Is_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Throw.IfAnyItemIsNullOrWhitespace(null), ArgumentFuncName);
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_Correct_Information()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => Throw.IfAnyItemIsNullOrWhitespace(() => _valuesWithOneWhitespace), nameof(_valuesWithAnEmptyString));

            Assert.IsTrue(exception.Message.Contains($"At least one string in the enumeration '{SonGoku}, ,{Vegeta}' was null or a whitespace."));
        }
    }
}
