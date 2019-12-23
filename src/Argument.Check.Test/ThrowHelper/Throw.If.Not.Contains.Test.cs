using System;
using System.Collections.Generic;
using System.Linq;
using Argument.Check.ThrowHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.ThrowHelper
{
    [TestClass]
    public class ThrowIfNotContainsTest
    {
        private const string ArgumentFuncName = "argumentFunc";
        private readonly string _nullArgument = null;
        private readonly Func<string> _nullArgumentFunc = null;
        private readonly IEnumerable<string> _stringValues = new[] { "Vegeta", "Beerus" };
        private readonly string _valueNotContained = "SonGoku";

        [TestMethod]
        public void Should_Throw_An_Exception_If_Value_Is_Not_In_Expected_Source()
        {
            Assert.ThrowsException<ArgumentException>(() => Throw.IfNotContains(() => _valueNotContained, _stringValues), nameof(_valueNotContained));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_Expected_Message_If_Value_Is_Not_In_Expected_Source()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => Throw.IfNotContains(() => _valueNotContained, _stringValues), nameof(_valueNotContained));

            Assert.IsTrue(exception.Message.Contains(_valueNotContained));
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Value_Is_In_Expected_Source()
        {
            Throw.IfNotContains(() => _stringValues.First(), _stringValues);
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_ArgumentFunc_Is_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Throw.IfNotContains(_nullArgumentFunc, _stringValues), ArgumentFuncName);
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_Argument_Is_Null()
        {
            Assert.ThrowsException<ArgumentException>(() => Throw.IfNotContains(() => _nullArgument, _stringValues), nameof(_nullArgument));
        }
    }
}
