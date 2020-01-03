using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.ThrowHelper
{
    [TestClass]
    public class ThrowIfContainsTest
    {
        private const string Vegeta = "Vegeta";
        private const string ArgumentFuncName = "argumentFunc";
        private readonly string _nullArgument = null;
        private readonly Func<string> _nullArgumentFunc = null;
        private readonly string _containedValue = Vegeta;
        private readonly string _valueNotContained = "SonGoku";
        private readonly IEnumerable<string> _stringValues = new[] { Vegeta, "Beerus" };

        [TestMethod]
        public void Should_Throw_An_Exception_If_Value_Is_Not_In_Expected_Source()
        {
            Assert.ThrowsException<ArgumentException>(() => Throw.IfContains(() => _containedValue, _stringValues), nameof(_containedValue));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_Expected_Message_If_Value_Is_Not_In_Expected_Source()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => Throw.IfContains(() => _containedValue, _stringValues), nameof(_containedValue));

            Assert.IsTrue(exception.Message.Contains(_containedValue));
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Value_Is_Not_In_Expected_Source()
        {
            Throw.IfContains(() => _valueNotContained, _stringValues);
        }

        [TestMethod]
        public void Should_Return_The_Same_Argument_Reference_Like_The_Checked_One()
        {
            Assert.AreEqual(_valueNotContained, Throw.IfContains(() => _valueNotContained, _stringValues));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_ArgumentFunc_Is_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Throw.IfContains(_nullArgumentFunc, _stringValues), ArgumentFuncName);
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Argument_Is_Null()
        {
            Throw.IfContains(() => _nullArgument, _stringValues);
        }
    }
}
