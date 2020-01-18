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

                void Test(object songoku)
                {
                    Throw.IfNull(() => songoku);

                    object nullObject = null;
                    Throw.IfNull(() => nullObject);
                }
            });

            Assert.AreEqual("Value cannot be null. (Parameter 'nullObject')", exception.Message);
        }
    }

    [TestClass]
    public class NoCorrectUsageOfThrowHelpers
    {
        private string test = "Just test";
        private int value = 42;
        private int someValue = 42;

        private const string expectedMessage = @"Please check, that you only do argument checking with the 'Throw' helpers in the scope of an constructor or method. It will not work for outer scope stuff. Sample:


Simple usage:

public Class(IService service)
{
    Throw.IfNull(() => service);
}

Variables which exists on stack:

public Class(IService service)
{
    Throw.IfNull(() => service);

    var result = service.GetSomething();
    Throw.IfNull(() => result);
}
";


        [TestMethod]
        public void Should_Detect_Correct_Argument_Also_With_Pre_Func_Usage()
        {
            var exception = Assert.ThrowsException<InvalidOperationException>(() => Throw.IfLessThan(() => value, 100));

            Assert.AreEqual(expectedMessage, exception.Message);
        }
    }
}