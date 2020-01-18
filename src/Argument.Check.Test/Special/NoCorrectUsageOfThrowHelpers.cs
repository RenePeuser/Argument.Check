using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.Special
{
    [TestClass]
    public class NoCorrectUsageOfThrowHelpers
    {
        // here we need this func to simulate that it will not work if we have more Func<int> => for simulating mor methods than fields
        private Func<int> Funcy = () => 42;
        private readonly int value = 42;
        private const string ExpectedMessage = @"Please check, that you only do argument checking with the 'Throw' helpers in the scope of an constructor or method. It will not work for outer scope stuff. Sample:


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

            Assert.AreEqual(ExpectedMessage, exception.Message);
        }

        [TestMethod]
        public void Assert_Only_To_Simulate_Multiple_Methods_For_Argument_Check()
        {
            Assert.AreEqual(42, Funcy());
        }
    }
}