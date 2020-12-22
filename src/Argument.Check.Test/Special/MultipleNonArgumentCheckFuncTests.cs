using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.Special
{
    [TestClass]
    public class MultipleNonArgumentCheckFuncTests
    {
        [TestMethod]
        public void Should_Detect_Correct_Argument_Also_With_Pre_Func_Usage()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                Test(null);

                static void Test(object songoku)
                {
                    static object ReturnSomething()
                    {
                        return "Hello";
                    }

                    Assert.AreEqual("Hello", ReturnSomething());

                    _ = Throw.IfNull(songoku);
                }
            });

            Assert.AreEqual("Value cannot be null. (Parameter 'songoku')", exception.Message);
        }

        [TestMethod]
        public void Should_Detect_Correct_Argument_Also_With_Post_Func_Usage()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                Test(null);

                static void Test(object songoku)
                {
                    _ = Throw.IfNull(songoku);

                    Func<string> returnSomething = () => "Hello";
                    Assert.AreEqual("Hello", returnSomething());
                }
            });

            Assert.AreEqual("Value cannot be null. (Parameter 'songoku')", exception.Message);
        }

        [TestMethod]
        public void Should_Detect_Correct_Argument_Also_With_Pre_And_Post_Func_Usage()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                Test(null);

                static void Test(object songoku)
                {
                    Func<object> returnSomething0 = () => "Hello";
                    Assert.AreEqual("Hello", returnSomething0());

                    _ = Throw.IfNull(songoku);

                    Func<object> returnSomething1 = () => "Hello";
                    Assert.AreEqual("Hello", returnSomething1());
                }
            });

            Assert.AreEqual("Value cannot be null. (Parameter 'songoku')", exception.Message);
        }
    }
}