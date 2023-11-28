using BenchmarkDotNet.Attributes;

namespace Argument.Check.Benchmark
{
    public class ThrowIfNullBenchmark
    {
        [Benchmark]
        public object Throw_Expression()
        {
            return CheckNull(new object());

            static object CheckNull(object arg)
            {
                return arg ?? throw new ArgumentNullException(nameof(arg));
            }
        }

        [Benchmark]
        public object Classic_Null_Check()
        {
            return CheckNull(new object());

            static object CheckNull(object arg)
            {
                if (arg == null)
                {
                    throw new ArgumentNullException(nameof(arg));
                }

                return arg;
            }
        }

        [Benchmark]
        public object Throw_If_Null_Func()
        {
            return CheckNull(new object());

            static object CheckNull(object arg)
            {
                return Throw.IfNull(() => arg);
            }
        }

        [Benchmark]
        public object Throw_If_Null()
        {
            return CheckNull(new object());

            static object CheckNull(object arg)
            {
                return Throw.IfNull(arg);
            }
        }
    }
}