using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.ThrowHelper
{
    [TestClass]
    public class IfNotTypeTest
    {
        private const string ArgumentFuncName = "argumentFunc";
        private readonly Func<object> _nullArgumentFunc = null;
        private readonly string _nullString = null;
        private readonly string _sonGoku = "SonGoku";
        private readonly int _unexpectedType = 4;

        [TestMethod]
        public void Should_Throw_An_Exception_If_Argument_Is_Not_Expected_Type()
        {
            Assert.ThrowsException<ArgumentException>(() => Throw.IfNotType<string>(() => _unexpectedType), nameof(_unexpectedType));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_Expected_Message_If_Argument_Is_Not_Expected_Type()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => Throw.IfNotType<string>(() => _unexpectedType), nameof(_unexpectedType));

            Assert.IsTrue(exception.Message.Contains($"The given type: '{_unexpectedType.GetType()}' is not the expected type: '{typeof(string)}'."));
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Argument_Is_Expected_Type()
        {
            Throw.IfNotType<string>(() => _sonGoku);
        }

        [TestMethod]
        public void Should_Return_The_Same_Argument_Reference_Like_The_Checked_One()
        {
            Assert.AreEqual(_sonGoku, Throw.IfNotType<string>(() => _sonGoku));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_ArgumentFunc_Is_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Throw.IfNotType<string>(_nullArgumentFunc), ArgumentFuncName);
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_Argument_Is_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Throw.IfNotType<string>(() => _nullString), nameof(_nullString));
        }
    }
}
