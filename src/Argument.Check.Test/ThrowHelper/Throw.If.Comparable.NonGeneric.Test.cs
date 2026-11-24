namespace Argument.Check.Test.ThrowHelper
{
    /// <summary>
    /// The comparison helpers compare value types through <see cref="Comparer{T}.Default"/> to avoid boxing.
    /// These tests make sure types that only implement the non-generic <see cref="IComparable"/> keep working,
    /// and that messages, parameter names and exception types stay exactly as before.
    /// </summary>
    [TestClass]
    public class ThrowIfComparableNonGenericTest
    {
        private readonly OnlyNonGenericStruct _low = new(1);
        private readonly OnlyNonGenericStruct _mid = new(5);
        private readonly OnlyNonGenericStruct _high = new(9);

        [TestMethod]
        public void Struct_With_Only_NonGeneric_IComparable_Works_With_All_Comparison_Helpers()
        {
            Assert.AreEqual(_mid, Throw.IfOutOfRange(_mid, _low, _high));
            Assert.AreEqual(_mid, Throw.IfGreaterThan(_mid, _high));
            Assert.AreEqual(_mid, Throw.IfLessThan(_mid, _low));
            Assert.AreEqual(_mid, Throw.IfGreaterOrEqual(_mid, _high));
            Assert.AreEqual(_mid, Throw.IfLessOrEqual(_mid, _low));

            _ = Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => Throw.IfOutOfRange(_high, _low, _mid));
            _ = Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => Throw.IfGreaterThan(_high, _mid));
            _ = Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => Throw.IfLessThan(_low, _mid));
        }

        [TestMethod]
        public void Class_With_Only_NonGeneric_IComparable_Works_With_All_Comparison_Helpers()
        {
            var low = new OnlyNonGenericClass(1);
            var mid = new OnlyNonGenericClass(5);
            var high = new OnlyNonGenericClass(9);

            Assert.AreSame(mid, Throw.IfOutOfRange(mid, low, high));
            Assert.AreSame(mid, Throw.IfGreaterThan(mid, high));
            Assert.AreSame(mid, Throw.IfLessThan(mid, low));

            _ = Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => Throw.IfOutOfRange(high, low, mid));
        }

        [TestMethod]
        public void Out_Of_Range_Message_Is_Unchanged_For_A_NonGeneric_Struct()
        {
            var high = _high;
            var exception = Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => Throw.IfOutOfRange(high, _low, _mid));

            Assert.AreEqual("high", exception.ParamName);
            Assert.StartsWith("Value: 'S9' is not in expected range from 'S1' to 'S5'.", exception.Message);
        }

        [TestMethod]
        public void Swapped_Limits_Still_Throw_The_Same_Exception()
        {
            var exception = Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => Throw.IfOutOfRange(5, 9, 1));

            Assert.AreEqual("upperLimit", exception.ParamName);
            Assert.StartsWith("Value: '1' must not be less than: '9'.", exception.Message);
        }

        [TestMethod]
        public void Enum_Values_Can_Be_Compared()
        {
            Assert.AreEqual(DayOfWeek.Wednesday, Throw.IfOutOfRange(DayOfWeek.Wednesday, DayOfWeek.Monday, DayOfWeek.Friday));
            _ = Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => Throw.IfOutOfRange(DayOfWeek.Sunday, DayOfWeek.Monday, DayOfWeek.Friday));
        }

        [TestMethod]
        public void A_Null_Reference_Argument_Still_Throws_A_NullReferenceException()
        {
            string? value = null;

            _ = Assert.ThrowsExactly<NullReferenceException>(() => Throw.IfGreaterThan(value!, "a"));
        }

        private readonly struct OnlyNonGenericStruct(int value) : IComparable
        {
            private int Value { get; } = value;

            public int CompareTo(object? obj) => Value.CompareTo(((OnlyNonGenericStruct)obj!).Value);

            public override string ToString() => "S" + Value;
        }

        private sealed class OnlyNonGenericClass(int value) : IComparable
        {
            private int Value { get; } = value;

            public int CompareTo(object? obj) => Value.CompareTo(((OnlyNonGenericClass)obj!).Value);

            public override string ToString() => "C" + Value;
        }
    }
}
