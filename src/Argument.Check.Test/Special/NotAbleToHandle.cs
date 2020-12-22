using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.Special
{
    [Ignore]
    [TestClass]
    public class NotAbleToHandle
    {
        [TestMethod]
        public void Not_Able_To_Handle_Scenario_01()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                Test(12, 12, 24);

                static void Test(int a, int b, int c)
                {
                    _ = Throw.IfEqualsTo(a, 13);

                    _ = Throw.IfEqualsTo(b, 12);
                    _ = Throw.IfEqualsTo(b, 13);
                    _ = Throw.IfEqualsTo(b, 14);

                    _ = Throw.IfEqualsTo(c, 24);
                }
            });

            Assert.AreEqual("The argument value: '12' was equal to: '12'. (Parameter 'b')", exception.Message);
        }
    }
}