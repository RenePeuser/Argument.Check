namespace Argument.Check.Test.Special
{
    [TestClass]
    public class MultipleNonArgumentCheckFuncTests
    {
        [TestMethod]
        public void Should_Detect_Correct_Argument_Also_With_Pre_Func_Usage()
        {
            var exception = Assert.ThrowsExactly<ArgumentNullException>(() =>
            {
                Test(null);

                static void Test(object? songoku)
                {
                    static object ReturnSomething()
                    {
                        return "Hello";
                    }

                    Assert.AreEqual("Hello", ReturnSomething());

                    _ = Throw.IfNull(songoku);
                }
            });

            Assert.AreEqual("Value cannot be null. (Parameter 'songoku')", exception.Message);
        }
    }
}
