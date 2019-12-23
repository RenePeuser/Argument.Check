using System;
using Argument.Check.ThrowHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.ThrowHelper
{
    [TestClass]
    public class ThrowIfNotInterfaceTest
    {
        [TestMethod]
        public void Should_Throw_An_Exception_If_Type_Is_Not_An_Interface()
        {
            Assert.ThrowsException<ArgumentException>(Throw.IfNotInterface<ThrowIfNotInterfaceTest>);
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_Correct_Message_If_Type_Is_Not_An_Interface()
        {
            var exception = Assert.ThrowsException<ArgumentException>(Throw.IfNotInterface<ThrowIfNotInterfaceTest>);

            Assert.IsTrue(exception.Message.Contains($"Type: '{typeof(ThrowIfNotInterfaceTest)}' must be an interface."));
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Type_Is_An_Interface()
        {
            Throw.IfNotInterface<TiDummy>();
        }

        private interface TiDummy
        {
        }
    }
}
