using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.ThrowHelper
{
    [TestClass]
    public class ThrowIfInterfaceTest
    {
        [TestMethod]
        public void Should_Throw_An_Exception_If_Type_Is_An_Interface()
        {
            Assert.ThrowsException<ArgumentException>(Throw.IfInterface<TiDummy>);
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_Correct_Message_If_Type_Is_An_Interface()
        {
            var exception = Assert.ThrowsException<ArgumentException>(Throw.IfInterface<TiDummy>);

            Assert.IsTrue(exception.Message.Contains($"Type: '{typeof(TiDummy)}' must not be an interface."));
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Type_Is_Not_An_Interface()
        {
            Throw.IfInterface<ThrowIfInterfaceTest>();
        }

        private interface TiDummy
        {
        }
    }
}
