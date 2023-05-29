using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.SpecialFunc
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

                static void Test(object? songoku)
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
    }
}
