using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.ThrowHelperFunc
{
    [TestClass]
    public class ThrowIfNotInterfaceTest
    {
        private readonly IEnumerable<string> _enumerable = Enumerable.Empty<string>();
        private readonly object _noInterface = new object();

        [TestMethod]
        public void Should_Throw_An_Exception_If_Type_Is_Not_An_Interface()
        {
            _ = Assert.ThrowsException<ArgumentException>(Throw.IfNotInterface<object>);
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_Correct_Message_If_Type_Is_Not_An_Interface()
        {
            var exception = Assert.ThrowsException<ArgumentException>(Throw.IfNotInterface<object>);

            Assert.AreEqual("Type: 'System.Object' must be an interface.", exception.Message);
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_Correct_Message_If_Type_Instance_Is_Not_An_Interface()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => TestMethod(new object()));

            Assert.AreEqual("Argument: 'argument' must be an interface.", exception.Message);
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Type_Is_Not_An_Interface()
        {
            Throw.IfNotInterface<ICloneable>();
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Instance_Is_An_Interface()
        {
            _ = Throw.IfNotInterface<IEnumerable>(() => _enumerable);
        }

        [TestMethod]
        public void Should_Return_The_Same_Argument_Reference_Like_The_Checked_One()
        {
            Assert.AreEqual(_enumerable, Throw.IfNotInterface<IEnumerable>(() => _enumerable));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_Instance_Is_Not_An_Interface()
        {
            _ = Assert.ThrowsException<ArgumentException>(() => TestMethod(_noInterface));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_ArgumentFunc_Is_Null()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                TestNullFunc();

                static void TestNullFunc()
                {
                    _ = Throw.IfNotInterface<IEnumerable>(NullHelper.GetNullOf<Func<object>>());
                }
            });

            Assert.AreEqual("Value cannot be null. (Parameter 'argumentFunc')", exception.Message);
        }

        private void TestMethod(object argument)
        {
            _ = Throw.IfNotInterface<IEnumerable>(() => argument);
        }
    }
}