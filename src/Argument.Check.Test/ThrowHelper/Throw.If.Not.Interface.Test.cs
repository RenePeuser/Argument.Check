using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.ThrowHelper
{
    [TestClass]
    public class ThrowIfNotInterfaceTest
    {
        private readonly IEnumerable<string> _enumerable = Enumerable.Empty<string>();
        private readonly object _noInterface = new object();

        [TestMethod]
        public void Should_Throw_An_Exception_If_Type_Is_Not_An_Interface()
        {
            Assert.ThrowsException<ArgumentException>(Throw.IfNotInterface<object>);
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_Correct_Message_If_Type_Is_Not_An_Interface()
        {
            var exception = Assert.ThrowsException<ArgumentException>(Throw.IfNotInterface<object>);

            Assert.IsTrue(exception.Message.Contains($"Type: '{typeof(object)}' must be an interface."));
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Type_Is_Not_An_Interface()
        {
            Throw.IfNotInterface<ICloneable>();
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Instance_Is_An_Interface()
        {
            Throw.IfNotInterface(() => _enumerable);
        }

        [TestMethod]
        public void Should_Return_The_Same_Argument_Reference_Like_The_Checked_One()
        {
            Assert.AreEqual(_enumerable, Throw.IfNotInterface(() => _enumerable));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_Instance_Is_Not_An_Interface()
        {
            Assert.ThrowsException<ArgumentException>(() => Throw.IfNotInterface(() => _noInterface));
        }
    }
}
