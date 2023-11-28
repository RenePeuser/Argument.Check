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

                static void Test(int a, int b, int c, int d)
                {
                    _ = Throw.IfLessThan(a, 2);
                    _ = Throw.IfLessThan(b, 3);
                    _ = Throw.IfLessThan(c, 4);

                    // only this condition must throw !!
                    _ = Throw.IfLessThan(d, 7);
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

                static void Test(int a, int b, int c, int d)
                {
                    _ = Throw.IfLessThan(a, 2);
                    _ = Throw.IfLessThan(b, 3);

                    // only this condition must throw !!
                    _ = Throw.IfLessThan(c, 7);

                    _ = Throw.IfLessThan(d, 6);
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

                static void Test(int a, int b, int c, int d)
                {
                    // only this condition must throw !!
                    _ = Throw.IfLessThan(a, 7);

                    _ = Throw.IfLessThan(b, 4);
                    _ = Throw.IfLessThan(c, 5);
                    _ = Throw.IfLessThan(d, 6);
                }
            });

            Assert.AreEqual("Value: '3' must not be less than: '7'. (Parameter 'a')", exception.Message);
        }

        [TestMethod]
        public void Should_Detect_Correct_Argument_Also_When_Argument_Is_Checked_With_Multiple_Different_Helpers()
        {
            var exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                _ = Combine(null);

                static string Combine(params string[]? paths)
                {
                    _ = Throw.IfNull(paths);
                    _ = Throw.IfAnyItemIsNullOrWhitespace(paths);

                    return Path.Combine(paths);
                }
            });

            Assert.AreEqual("Value cannot be null. (Parameter 'paths')", exception.Message);
        }
    }
}
