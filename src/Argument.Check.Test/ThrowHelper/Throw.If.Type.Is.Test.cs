using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.ThrowHelper
{
    [TestClass]
    public class IfTypeIsTest
    {
        private const string ArgumentFuncName = "argumentFunc";
        private readonly int _notExpectedType = 4;
        private readonly Func<object> _nullArgumentFunc = null;
        private readonly string _nullString = null;
        private readonly string _sonGoku = "SonGoku";

        [TestMethod]
        public void Should_Throw_An_Exception_If_Argument_Is_Expected_Type()
        {
            Assert.ThrowsException<ArgumentException>(() => Throw.IfTypeIs<string>(() => _sonGoku), nameof(_sonGoku));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_Expected_Message_If_Argument_Is_Expected_Type()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => Throw.IfTypeIs<string>(() => _sonGoku), nameof(_sonGoku));

            Assert.IsTrue(exception.Message.Contains($"The given type: '{_sonGoku.GetType()}' is the expected type: '{typeof(string)}'."));
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Argument_Is_Expected_Type()
        {
            Throw.IfTypeIs<string>(() => _notExpectedType);
        }

        [TestMethod]
        public void Should_Return_The_Same_Argument_Reference_Like_The_Checked_One()
        {
            Assert.AreEqual(_notExpectedType, Throw.IfTypeIs<string>(() => _notExpectedType));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_ArgumentFunc_Is_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Throw.IfTypeIs<string>(_nullArgumentFunc), ArgumentFuncName);
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_Argument_Is_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Throw.IfTypeIs<string>(() => _nullString), nameof(_nullString));
        }
    }
}
