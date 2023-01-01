using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#pragma warning disable 649

namespace Argument.Check.Test.ThrowHelper
{
    [TestClass]
    public class IfTypeIsNot
    {
        private readonly string? _nullString;
        private readonly string _sonGoku = "SonGoku";
        private readonly int _unexpectedType = 4;

        [TestMethod]
        public void Should_Throw_An_Exception_If_Argument_Is_Not_Expected_Type()
        {
            _ = Assert.ThrowsException<ArgumentException>(() => TestMethod<string>(_unexpectedType));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_Expected_Message_If_Argument_Is_Not_Expected_Type()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => TestMethod<string>(_unexpectedType));

            Assert.AreEqual($"The given type: '{_unexpectedType.GetType()}' is not the expected type: '{typeof(string)}'. (Parameter 'argument')", exception.Message);
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Argument_Is_Expected_Type()
        {
            TestMethod<string>(_sonGoku);
        }

        [TestMethod]
        public void Should_Return_The_Same_Argument_Reference_Like_The_Checked_One()
        {
            Assert.AreEqual(_sonGoku, Throw.IfTypeIsNot<string>(_sonGoku));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_Argument_Is_Null()
        {
            _ = Assert.ThrowsException<ArgumentNullException>(() => TestMethod<string>(_nullString), nameof(_nullString));
        }

        private void TestMethod<T>(object? argument) where T : class
        {
            _ = Throw.IfTypeIsNot<T>(argument);
        }
    }
}
