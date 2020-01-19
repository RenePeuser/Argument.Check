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

                void Test(int a, int b, int c)
                {
                    Throw.IfEqualsTo(() => a, 13);

                    Throw.IfEqualsTo(() => b, 12);
                    Throw.IfEqualsTo(() => b, 13);
                    Throw.IfEqualsTo(() => b, 14);

                    Throw.IfEqualsTo(() => c, 24);
                }
            });

            Assert.AreEqual("The argument value: '12' was equal to: '12'. (Parameter 'b')", exception.Message);
        }
    }
}