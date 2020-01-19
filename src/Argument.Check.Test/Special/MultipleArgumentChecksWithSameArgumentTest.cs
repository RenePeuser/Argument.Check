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
                Combine(null);

                void Combine(params string[] paths)
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
                Combine(null, new[] { "test" });

                void Combine(string[] test, string[] a)
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
                Combine(new string[] { null }, new[] { "test" });

                void Combine(string[] test, string[] a)
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
                Combine(new[] { "a" }, null);

                void Combine(string[] test, string[] a)
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
                Combine(new[] { "a" }, new string[] { null });

                void Combine(string[] test, string[] a)
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
                Combine(new[] { "a" }, new string[] { null });

                void Combine(string[] test, string[] a)
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
                Combine(null, "test", "test");

                void Combine(string a, string b, string c)
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
                Combine(" ", "test", "test");

                void Combine(string a, string b, string c)
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
                Combine("abc", " ", "test");

                void Combine(string a, string b, string c)
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
                Combine(2, "test", new object());

                void Combine(int a, string b, object c)
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
                Combine(10, null, new object());

                void Combine(int a, string b, object c)
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
                Combine(10, "test", null);

                void Combine(int a, string b, object c)
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
                Combine(7, 4, 15);

                void Combine(int a, int b, int c)
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
                Combine(7, 4, 15);

                void Combine(int a, int b, int c)
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
                Combine(3, 7, 15);

                void Combine(int a, int b, int c)
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
                Combine(3, 3, 7);

                void Combine(int a, int b, int c)
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
                Combine(7, 0, 15);

                void Combine(int a, int b, int c)
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
                Combine(7, 3, 0);

                void Combine(int a, int b, int c)
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
                Combine(7, 3, 0);

                void Combine(int a, int b, int c)
                {
                    Throw.IfLessThan(() => b, 2);
                    Throw.IfLessThan(() => c, 2);
                }
            });

            Assert.AreEqual("Value: '0' must not be less than: '2'. (Parameter 'c')", exception.Message);
        }
    }
}