using System;
using System.Collections;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.ThrowHelper
{
    [TestClass]
    public class ThrowIfInterfaceTest
    {
        private readonly object _noInterface = new object();

        [TestMethod]
        public void Should_Throw_An_Exception_If_Type_Is_An_Interface()
        {
            _ = Assert.ThrowsException<ArgumentException>(Throw.IfInterface<ICloneable>);
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_Correct_Message_If_Type_Is_An_Interface()
        {
            var exception = Assert.ThrowsException<ArgumentException>(Throw.IfInterface<ICloneable>);

            Assert.AreEqual($"Type: '{typeof(ICloneable)}' must not be an interface.", exception.Message);
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_Correct_Message_If_Type_Instance_Is_An_Interface()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => TestMethod(Enumerable.Empty<string>()));

            Assert.AreEqual("Argument: 'argument' must not be an interface.", exception.Message);
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Type_Is_Not_An_Interface()
        {
            Throw.IfInterface<ThrowIfInterfaceTest>();
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Instance_Is_An_Interface()
        {
            _ = Throw.IfInterface<IEnumerable>(_noInterface);
        }

        [TestMethod]
        public void Should_Return_The_Same_Argument_Reference_Like_The_Checked_One()
        {
            Assert.AreEqual(_noInterface, Throw.IfInterface<IEnumerable>(_noInterface));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_ArgumentFunc_Is_Null()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                TestNullFunc();

                static void TestNullFunc()
                {
                    _ = Throw.IfInterface<IEnumerable>(NullHelper.GetNullOf<object>());
                }
            });

            Assert.AreEqual("Value cannot be null. (Parameter 'argumentFunc')", exception.Message);
        }

        private void TestMethod(IEnumerable argument)
        {
            _ = Throw.IfInterface<IEnumerable>(argument);
        }
    }
}