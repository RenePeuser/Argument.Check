using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.Special
{
    [TestClass]
    public class MultiplParameterTypeWithSameTypesCheckTest
    {
        [TestMethod]
        public void Should_Detect_Last_Argument_Also_With_Multiple_Equal_Parameter_Types()
        {
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                Test(3, 4, 5, 6);

                void Test(int a, int b, int c, int d)
                {
                    Throw.IfLessThan(() => a, 2);
                    Throw.IfLessThan(() => b, 3);
                    Throw.IfLessThan(() => c, 4);

                    // only this condition must throw !!
                    Throw.IfLessThan(() => d, 7);
                }
            });

            Assert.AreEqual("Value: '6' must not be less than: '7'. (Parameter 'd')", exception.Message);
        }

        [TestMethod]
        public void Should_Detect_Third_Argument_Also_With_Multiple_Equal_Parameter_Types()
        {
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                Test(3, 4, 5, 6);

                void Test(int a, int b, int c, int d)
                {
                    Throw.IfLessThan(() => a, 2);
                    Throw.IfLessThan(() => b, 3);

                    // only this condition must throw !!
                    Throw.IfLessThan(() => c, 7);

                    Throw.IfLessThan(() => d, 6);
                }
            });

            Assert.AreEqual("Value: '5' must not be less than: '7'. (Parameter 'c')", exception.Message);
        }

        [TestMethod]
        public void Should_Detect_First_Argument_Also_With_Multiple_Equal_Parameter_Types()
        {
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                Test(3, 4, 5, 6);

                void Test(int a, int b, int c, int d)
                {
                    // only this condition must throw !!
                    Throw.IfLessThan(() => a, 7);

                    Throw.IfLessThan(() => b, 4);
                    Throw.IfLessThan(() => c, 5);
                    Throw.IfLessThan(() => d, 6);
                }
            });

            Assert.AreEqual("Value: '3' must not be less than: '7'. (Parameter 'a')", exception.Message);
        }
    }
}