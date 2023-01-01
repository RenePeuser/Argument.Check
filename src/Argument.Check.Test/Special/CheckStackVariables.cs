using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.Special
{
    [TestClass]
    public class CheckStackVariables
    {
        [TestMethod]
        public void Should_Detect_Correct_Argument_Also_With_Pre_Func_Usage()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                Test("songoku");

                static void Test(object songoku)
                {
                    _ = Throw.IfNull(songoku);

                    object? nullObject = null;
                    _ = Throw.IfNull(nullObject);
                }
            });

            Assert.AreEqual("Value cannot be null. (Parameter 'nullObject')", exception.Message);
        }
    }
}
