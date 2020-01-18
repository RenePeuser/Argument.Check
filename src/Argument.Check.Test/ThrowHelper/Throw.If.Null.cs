using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.ThrowHelper
{
    [TestClass]
    public class IfNullTest
    {
        private const string ArgumentFunc = "argumentFunc";
        private readonly string _notNullString = "SonGoku";
        private readonly Func<string> _nullArgumentFunc = null;
        private readonly string _nullString = null;

        [TestMethod]
        public void Should_Throw_An_Exception_If_Argument_Is_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => TestMethod(_nullString));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_Correct_Exception_Message_If_Argument_Is_Null()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() => TestMethod(_nullString));

            Assert.AreEqual("Value cannot be null. (Parameter 'argument')", exception.Message);
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Argument_Is_Not_Null()
        {
            TestMethod(_notNullString);
        }

        [TestMethod]
        public void Should_Return_The_Same_Argument_Reference_Like_The_Checked_One()
        {
            Assert.AreEqual(_notNullString, Throw.IfNull(() => _notNullString));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_ArgumentFunc_Is_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Throw.IfNull(_nullArgumentFunc), ArgumentFunc);
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_Enumeration_ArgumentFunc_Is_Null()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                TestNullFunc();
                void TestNullFunc()
                {
                    Throw.IfNull(NullHelper.GetNullOf<Func<string>>());
                }
            });

            Assert.AreEqual("Value cannot be null. (Parameter 'argumentFunc')", exception.Message);
        }

        private void TestMethod(string argument)
        {
            Throw.IfNull(() => argument);
        }
    }
}
