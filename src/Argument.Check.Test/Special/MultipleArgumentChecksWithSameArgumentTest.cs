using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.Special
{
    [TestClass]
    public class MultipleArgumentChecksWithSameArgumentTest
    {
        [TestMethod]
        public void Should_Detect_Correct_Argument_Secenario_01()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                Test(null);

                void Test(params string[] paths)
                {
                    // This should throw only.
                    Throw.IfNull(() => paths);
                    Throw.IfAnyItemIsNullOrWhitespace(() => paths);
                }
            });

            Assert.AreEqual("Value cannot be null. (Parameter 'paths')", exception.Message);
        }

        [TestMethod]
        public void Should_Detect_Correct_Argument_Secenario_02()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                Test(null, new[] { "test" });

                void Test(string[] test, string[] a)
                {
                    Throw.IfNull(() => test);
                    Throw.IfAnyItemIsNullOrWhitespace(() => test);

                    Throw.IfNull(() => a);
                    Throw.IfAnyItemIsNullOrWhitespace(() => a);
                }
            });

            Assert.AreEqual("Value cannot be null. (Parameter 'test')", exception.Message);
        }

        [TestMethod]
        public void Should_Detect_Correct_Argument_Secenario_03()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                Test(new string[] { null }, new[] { "test" });

                void Test(string[] test, string[] a)
                {
                    Throw.IfNull(() => test);
                    Throw.IfAnyItemIsNullOrWhitespace(() => test);

                    Throw.IfNull(() => a);
                    Throw.IfAnyItemIsNullOrWhitespace(() => a);
                }
            });

            Assert.AreEqual("At least one string in the enumeration '' was null or a whitespace. (Parameter 'test')", exception.Message);
        }

        [TestMethod]
        public void Should_Detect_Correct_Argument_Secenario_04()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                Test(new[] { "a" }, null);

                void Test(string[] test, string[] a)
                {
                    Throw.IfNull(() => test);
                    Throw.IfAnyItemIsNullOrWhitespace(() => test);

                    Throw.IfNull(() => a);
                }
            });

            Assert.AreEqual("Value cannot be null. (Parameter 'a')", exception.Message);
        }

        [TestMethod]
        public void Should_Detect_Correct_Argument_Secenario_05()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                Test(new[] { "a" }, new string[] { null });

                void Test(string[] test, string[] a)
                {
                    Throw.IfNull(() => test);
                    Throw.IfAnyItemIsNullOrWhitespace(() => test);

                    Throw.IfNull(() => a);
                    Throw.IfAnyItemIsNullOrWhitespace(() => a);
                }
            });

            Assert.AreEqual("At least one string in the enumeration '' was null or a whitespace. (Parameter 'a')", exception.Message);
        }

        [TestMethod]
        public void Should_Detect_Correct_Argument_Secenario_06()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                Test(new[] { "a" }, new string[] { null });

                void Test(string[] test, string[] a)
                {
                    Throw.IfNull(() => test);
                    Throw.IfAnyItemIsNullOrWhitespace(() => test);

                    Throw.IfNull(() => a);
                    Throw.IfAnyItemIsNullOrWhitespace(() => a);
                }
            });

            Assert.AreEqual("At least one string in the enumeration '' was null or a whitespace. (Parameter 'a')", exception.Message);
        }

        [TestMethod]
        public void Should_Detect_Correct_Argument_Secenario_07()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                Test(null, "test", "test");

                void Test(string a, string b, string c)
                {
                    Throw.IfNull(() => a);
                    Throw.IfWhitespace(() => a);
                    Throw.IfNullOrWhiteSpace(() => a);

                    Throw.IfNull(() => b);
                    Throw.IfNull(() => c);
                }
            });

            Assert.AreEqual("Value cannot be null. (Parameter 'a')", exception.Message);
        }

        [TestMethod]
        public void Should_Detect_Correct_Argument_Secenario_08()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                Test(" ", "test", "test");

                void Test(string a, string b, string c)
                {
                    Throw.IfNull(() => a);
                    Throw.IfWhitespace(() => a);

                    Throw.IfNull(() => b);
                    Throw.IfNull(() => c);
                }
            });

            Assert.AreEqual("The string must not be only whitespace. (Parameter 'a')", exception.Message);
        }

        [TestMethod]
        public void Should_Detect_Correct_Argument_Secenario_09()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                Test("abc", " ", "test");

                void Test(string a, string b, string c)
                {
                    Throw.IfNull(() => a);
                    Throw.IfWhitespace(() => a);

                    Throw.IfWhitespace(() => b);
                    Throw.IfNull(() => c);
                }
            });

            Assert.AreEqual("The string must not be only whitespace. (Parameter 'b')", exception.Message);
        }

        [TestMethod]
        public void Should_Detect_Correct_Argument_Secenario_10()
        {
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                Test(2, "test", new object());

                void Test(int a, string b, object c)
                {
                    Throw.IfLessThan(() => a, 5);
                    Throw.IfNull(() => b);
                    Throw.IfNull(() => c);
                }
            });

            Assert.AreEqual("Value: '2' must not be less than: '5'. (Parameter 'a')", exception.Message);
        }

        [TestMethod]
        public void Should_Detect_Correct_Argument_Secenario_11()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                Test(10, null, new object());

                void Test(int a, string b, object c)
                {
                    Throw.IfLessThan(() => a, 5);
                    Throw.IfNull(() => b);
                    Throw.IfNull(() => c);
                }
            });

            Assert.AreEqual("Value cannot be null. (Parameter 'b')", exception.Message);
        }

        [TestMethod]
        public void Should_Detect_Correct_Argument_Secenario_12()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                Test(10, "test", null);

                void Test(int a, string b, object c)
                {
                    Throw.IfLessThan(() => a, 5);
                    Throw.IfNull(() => b);
                    Throw.IfNull(() => c);
                }
            });

            Assert.AreEqual("Value cannot be null. (Parameter 'c')", exception.Message);
        }

        [TestMethod]
        public void Should_Detect_Correct_Argument_Secenario_13()
        {
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                Test(7, 4, 15);

                void Test(int a, int b, int c)
                {
                    Throw.IfLessThan(() => a, 2);
                    Throw.IfGreaterThan(() => a, 5);

                    Throw.IfOutOfRange(() => c, 10, 20);
                }
            });

            Assert.AreEqual("Value: '7' must not be greater than: '5'. (Parameter 'a')", exception.Message);
        }

        [TestMethod]
        public void Should_Detect_Correct_Argument_Secenario_14()
        {
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                Test(7, 4, 15);

                void Test(int a, int b, int c)
                {
                    Throw.IfLessThan(() => a, 2);
                    Throw.IfGreaterThan(() => a, 5);

                    Throw.IfLessThan(() => b, 2);
                    Throw.IfGreaterThan(() => b, 5);

                    Throw.IfLessThan(() => c, 2);
                    Throw.IfGreaterThan(() => c, 5);
                }
            });

            Assert.AreEqual("Value: '7' must not be greater than: '5'. (Parameter 'a')", exception.Message);
        }


        [TestMethod]
        public void Should_Detect_Correct_Argument_Secenario_15()
        {
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                Test(3, 7, 15);

                void Test(int a, int b, int c)
                {
                    Throw.IfLessThan(() => a, 2);
                    Throw.IfGreaterThan(() => a, 5);

                    Throw.IfLessThan(() => b, 2);
                    Throw.IfGreaterThan(() => b, 5);

                    Throw.IfLessThan(() => c, 2);
                    Throw.IfGreaterThan(() => c, 5);
                }
            });

            Assert.AreEqual("Value: '7' must not be greater than: '5'. (Parameter 'b')", exception.Message);
        }

        [TestMethod]
        public void Should_Detect_Correct_Argument_Secenario_16()
        {
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                Test(3, 3, 7);

                void Test(int a, int b, int c)
                {
                    Throw.IfLessThan(() => a, 2);
                    Throw.IfGreaterThan(() => a, 5);

                    Throw.IfLessThan(() => b, 2);
                    Throw.IfGreaterThan(() => b, 5);

                    Throw.IfLessThan(() => c, 2);
                    Throw.IfGreaterThan(() => c, 5);
                }
            });

            Assert.AreEqual("Value: '7' must not be greater than: '5'. (Parameter 'c')", exception.Message);
        }


        [TestMethod]
        public void Should_Detect_Correct_Argument_Secenario_17()
        {
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                Test(7, 0, 15);

                void Test(int a, int b, int c)
                {
                    Throw.IfLessThan(() => b, 2);
                }
            });

            Assert.AreEqual("Value: '0' must not be less than: '2'. (Parameter 'b')", exception.Message);
        }

        [TestMethod]
        public void Should_Detect_Correct_Argument_Secenario_18()
        {
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                Test(7, 3, 0);

                void Test(int a, int b, int c)
                {
                    Throw.IfLessThan(() => c, 2);
                }
            });

            Assert.AreEqual("Value: '0' must not be less than: '2'. (Parameter 'c')", exception.Message);
        }

        [TestMethod]
        public void Should_Detect_Correct_Argument_Secenario_19()
        {
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                Test(7, 3, 0);

                void Test(int a, int b, int c)
                {
                    Throw.IfLessThan(() => b, 2);
                    Throw.IfLessThan(() => c, 2);
                }
            });

            Assert.AreEqual("Value: '0' must not be less than: '2'. (Parameter 'c')", exception.Message);
        }

        [TestMethod]
        public void Should_Detect_Correct_Argument_Secenario_20()
        {
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                Test(1, 42, 42);

                void Test(int a, int b, int c)
                {
                    Throw.IfLessThan(() => a, 42);
                    Throw.IfEqualsTo(() => a, 24);
                    Throw.IfGreaterThan(() => a, 66);

                    Throw.IfLessThan(() => b, 42);
                    Throw.IfEqualsTo(() => b, 24);
                    Throw.IfGreaterThan(() => b, 66);

                    Throw.IfLessThan(() => c, 42);
                    Throw.IfEqualsTo(() => c, 24);
                    Throw.IfGreaterThan(() => c, 66);

                }
            });

            Assert.AreEqual("Value: '1' must not be less than: '42'. (Parameter 'a')", exception.Message);
        }

        [TestMethod]
        public void Should_Detect_Correct_Argument_Secenario_21()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                Test(24, 42, 42);

                void Test(int a, int b, int c)
                {
                    Throw.IfLessThan(() => a, 0);
                    Throw.IfEqualsTo(() => a, 24);
                    Throw.IfGreaterThan(() => a, 66);

                    Throw.IfLessThan(() => b, 42);
                    Throw.IfEqualsTo(() => b, 24);
                    Throw.IfGreaterThan(() => b, 66);

                    Throw.IfLessThan(() => c, 42);
                    Throw.IfEqualsTo(() => c, 24);
                    Throw.IfGreaterThan(() => c, 66);

                }
            });

            Assert.AreEqual("The argument value: '24' was equal to: '24'. (Parameter 'a')", exception.Message);
        }

        [TestMethod]
        public void Should_Detect_Correct_Argument_Secenario_22()
        {
            var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                Test(67, 42, 1);

                void Test(int a, int b, int c)
                {
                    Throw.IfLessThan(() => c, 42);
                    Throw.IfEqualsTo(() => c, 24);
                    Throw.IfGreaterThan(() => c, 66);

                    Throw.IfLessThan(() => a, 0);
                    Throw.IfEqualsTo(() => a, 24);
                    Throw.IfGreaterThan(() => a, 66);

                    Throw.IfLessThan(() => b, 42);
                    Throw.IfEqualsTo(() => b, 24);
                    Throw.IfGreaterThan(() => b, 66);
                }
            });

            Assert.AreEqual("Value: '1' must not be less than: '42'. (Parameter 'c')", exception.Message);
        }

        [TestMethod]
        public void Should_Detect_Correct_Argument_Secenario_23()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                Test(67, 42, 24);

                void Test(int a, int b, int c)
                {
                    Throw.IfLessThan(() => c, 1);
                    Throw.IfEqualsTo(() => c, 24);
                    Throw.IfGreaterThan(() => c, 66);

                    Throw.IfLessThan(() => a, 0);
                    Throw.IfEqualsTo(() => a, 24);
                    Throw.IfGreaterThan(() => a, 66);

                    Throw.IfLessThan(() => b, 42);
                    Throw.IfEqualsTo(() => b, 24);
                    Throw.IfGreaterThan(() => b, 66);
                }
            });

            Assert.AreEqual("The argument value: '24' was equal to: '24'. (Parameter 'c')", exception.Message);
        }

        [TestMethod]
        public void Should_Detect_Correct_Argument_Secenario_24()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                Test(24, 24, 24);

                void Test(int a, int b, int c)
                {
                    Throw.IfLessThan(() => c, 1);
                    Throw.IfEqualsTo(() => c, 24);
                    Throw.IfGreaterThan(() => c, 66);

                    Throw.IfLessThan(() => a, 0);
                    Throw.IfEqualsTo(() => a, 24);
                    Throw.IfGreaterThan(() => a, 66);

                    Throw.IfLessThan(() => b, 42);
                    Throw.IfEqualsTo(() => b, 24);
                    Throw.IfGreaterThan(() => b, 66);
                }
            });

            Assert.AreEqual("The argument value: '24' was equal to: '24'. (Parameter 'c')", exception.Message);
        }

        [TestMethod]
        public void Should_Detect_Correct_Argument_Secenario_25()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                Test(24, 24, 24);

                void Test(int a, int b, int c)
                {
                    Throw.IfLessThan(() => b, 1);
                    Throw.IfEqualsTo(() => b, 24);
                    Throw.IfGreaterThan(() => b, 66);

                    Throw.IfLessThan(() => c, 1);
                    Throw.IfEqualsTo(() => c, 24);
                    Throw.IfGreaterThan(() => c, 66);

                    Throw.IfLessThan(() => a, 0);
                    Throw.IfEqualsTo(() => a, 24);
                    Throw.IfGreaterThan(() => a, 66);
                }
            });

            Assert.AreEqual("The argument value: '24' was equal to: '24'. (Parameter 'b')", exception.Message);
        }

        [TestMethod]
        public void Should_Detect_Correct_Argument_Secenario_26()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                Test(24, 24, 24);

                void Test(int a, int b, int c)
                {
                    Throw.IfLessThan(() => b, 1);
                    Throw.IfEqualsTo(() => b, 24);
                    Throw.IfGreaterThan(() => b, 66);

                    Throw.IfEqualsTo(() => c, 24);
                    Throw.IfGreaterThan(() => c, 66);

                    Throw.IfLessThan(() => a, 0);
                }
            });

            Assert.AreEqual("The argument value: '24' was equal to: '24'. (Parameter 'b')", exception.Message);
        }

        [TestMethod]
        public void Should_Detect_Correct_Argument_Secenario_27()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                Test(24, 24, 24);

                void Test(int a, int b, int c)
                {
                    Throw.IfLessThan(() => b, 1);
                    Throw.IfEqualsTo(() => b, 24);
                    Throw.IfGreaterThan(() => b, 66);

                    Throw.IfEqualsTo(() => c, 24);

                    Throw.IfLessThan(() => a, 0);
                }
            });

            Assert.AreEqual("The argument value: '24' was equal to: '24'. (Parameter 'b')", exception.Message);
        }

        [TestMethod]
        public void Should_Detect_Correct_Argument_Secenario_28()
        {
            var exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                Test(24, 24, 24);

                void Test(int a, int b, int c)
                {
                    Throw.IfLessThan(() => b, 1);
                    Throw.IfEqualsTo(() => b, 24);
                    Throw.IfGreaterThan(() => b, 66);

                    Throw.IfEqualsTo(() => c, 24);
                }
            });

            Assert.AreEqual("The argument value: '24' was equal to: '24'. (Parameter 'b')", exception.Message);
        }
    }
}