using System;
using Argument.Check.ThrowHelper;
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
            Assert.ThrowsException<ArgumentNullException>(() => Throw.IfNull(() => _nullString), nameof(_nullString));
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Argument_Is_Not_Null()
        {
            Throw.IfNull(() => _notNullString);
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_ArgumentFunc_Is_Null()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Throw.IfNull(_nullArgumentFunc), ArgumentFunc);
        }
    }
}
