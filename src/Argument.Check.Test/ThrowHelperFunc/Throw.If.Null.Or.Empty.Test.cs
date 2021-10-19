using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#pragma warning disable 649

namespace Argument.Check.Test.ThrowHelperFunc
{
    [TestClass]
    public class ThrowIfNullOrEmptyTest
    {
        private const string ArgumentFuncName = "argumentFunc";

        private readonly IEnumerable<string> _emptyList = Enumerable.Empty<string>();


        private readonly string _emptyString = string.Empty;
        private readonly IEnumerable<string> _listWithoutNullItem = new[] {"Vegeta", "Beerus"};
        private readonly IEnumerable<string> _nullArgument;
        private readonly Func<IEnumerable<string>> _nullArgumentFunc;
        private readonly string _nullStringArgument;
        private readonly Func<string> _nullStringArgumentFunc;
        private readonly string _sonGoku = "SonGoku";


        [TestMethod]
        public void Should_Throw_An_Exception_If_Source_Is_Empty()
        {
            _ = Assert.ThrowsException<ArgumentException>(() => TestMethod(_emptyList));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_Correct_Message_If_Source_Is_Empty()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => TestMethod(_emptyList));

            Assert.AreEqual("The enumerable must not be empty. (Parameter 'values')", exception.Message);
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_Source_Is_Null()
        {
            _ = Assert.ThrowsException<ArgumentNullException>(() => TestMethod(_nullArgument), nameof(_nullArgument));
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_Source_Is_Not_Null_And_Does_Not_Contains_Null_Items()
        {
            TestMethod(_listWithoutNullItem);
        }

        [TestMethod]
        public void Should_Return_The_Same_Enumeration_Like_The_Checked_One()
        {
            Assert.AreEqual(_listWithoutNullItem, Throw.IfNullOrEmpty(() => _listWithoutNullItem));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_Source_ArgumentFunc_Is_Null()
        {
            _ = Assert.ThrowsException<ArgumentNullException>(() => Throw.IfNullOrEmpty(_nullArgumentFunc), ArgumentFuncName);
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_String_Is_Empty()
        {
            _ = Assert.ThrowsException<ArgumentException>(() => TestMethod(_emptyString), nameof(_emptyString));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_With_Correct_Message_If_String_Is_Empty()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() => TestMethod(_emptyString), nameof(_emptyString));

            Assert.IsTrue(exception.Message.Contains("The string must not be empty."));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_String_Is_Null()
        {
            _ = Assert.ThrowsException<ArgumentNullException>(() => TestMethod(_nullStringArgument), nameof(_nullStringArgument));
        }

        [TestMethod]
        public void Should_Not_Throw_An_Exception_If_String_Is_Not_Null_And_Does_Not_Contains_Null_Items()
        {
            TestMethod(_sonGoku);
        }

        [TestMethod]
        public void Should_Return_The_Same_String_Like_The_Checked_One()
        {
            Assert.AreEqual(_sonGoku, Throw.IfNullOrEmpty(() => _sonGoku));
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_String_ArgumentFunc_Is_Null()
        {
            _ = Assert.ThrowsException<ArgumentNullException>(() => Throw.IfNullOrEmpty(_nullStringArgumentFunc), ArgumentFuncName);
        }

        [TestMethod]
        public void Should_Throw_An_Exception_If_Enumeration_ArgumentFunc_Is_Null()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                TestNullFunc();

                static void TestNullFunc()
                {
                    _ = Throw.IfNullOrEmpty(NullHelper.GetNullOf<Func<string>>());
                }
            });

            Assert.AreEqual("Value cannot be null. (Parameter 'argumentFunc')", exception.Message);
        }

        private void TestMethod(string value)
        {
            _ = Throw.IfNullOrEmpty(() => value);
        }

        private void TestMethod(IEnumerable<string> values)
        {
            _ = Throw.IfNullOrEmpty(() => values);
        }
    }
}