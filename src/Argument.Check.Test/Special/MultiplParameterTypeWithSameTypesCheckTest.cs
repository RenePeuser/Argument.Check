using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.Special
{
    [TestClass]
    public class MultipleParameterTypeWithSameTypesCheckTest
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

        [TestMethod]
        public void Should_Detect_Correct_Argument_Also_When_Argument_Is_Checked_With_Multiple_Different_Helpers()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                Combine(null);

                string Combine(params string[] paths)
                {
                    Throw.IfNull(() => paths);
                    Throw.IfAnyItemIsNullOrWhitespace(() => paths);

                    return Path.Combine(paths);
                }
            });

            Assert.AreEqual("Value cannot be null. (Parameter 'paths')", exception.Message);
        }
    }

    [TestClass]
    public class MultipleArgumentChecksWithSameArgumentTest
    {
        [TestMethod]
        public void Should_Detect_Argument_Also_When_Argument_Is_Checked_With_Multiple_Different_Helpers()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                Combine(null);

                string Combine(params string[] paths)
                {
                    // This should throw only.
                    Throw.IfNull(() => paths);
                    Throw.IfAnyItemIsNullOrWhitespace(() => paths);

                    return Path.Combine(paths);
                }
            });

            Assert.AreEqual("Value cannot be null. (Parameter 'paths')", exception.Message);
        }

        [TestMethod]
        public void Should_Detect_Correct_Argument_Also_When_Argument_Is_Checked_With_Multiple_Different_Helpers_1()
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
        public void Should_Detect_Correct_Argument_Also_When_Argument_Is_Checked_With_Multiple_Different_Helpers_2()
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
        public void Should_Detect_Correct_Argument_Also_When_Argument_Is_Checked_With_Multiple_Different_Helpers_3()
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
        public void Should_Detect_Correct_Argument_Also_When_Argument_Is_Checked_With_Multiple_Different_Helpers_4()
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
        public void Should_Detect_Correct_Argument_Also_When_Argument_Is_Checked_With_Multiple_Different_Helpers_5()
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
        public void Should_Detect_Correct_Argument_Also_When_Argument_Is_Checked_With_Multiple_Different_Helpers_6()
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

        // ToDo: Fix it soon.
        [Ignore]
        [TestMethod]
        public void Should_Detect_Correct_Argument_Also_When_Argument_Is_Checked_With_Multiple_Different_Helpers_7()
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
        public void Should_Detect_Correct_Argument_Also_When_Argument_Is_Checked_With_Multiple_Different_Helpers_8()
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

            Assert.AreEqual("The string must not be only whitespace. (Parameter 'b')", exception.Message);
        }

        [TestMethod]
        public void Should_Detect_Correct_Argument_Also_When_Argument_Is_Checked_With_Multiple_Different_Helpers_9()
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
        public void Should_Detect_Correct_Argument_Also_When_Argument_Is_Checked_With_Multiple_Different_Helpers_10()
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
        public void Should_Detect_Correct_Argument_Also_When_Argument_Is_Checked_With_Multiple_Different_Helpers_11()
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
    }
}