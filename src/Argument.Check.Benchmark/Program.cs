using BenchmarkDotNet.Running;

namespace Argument.Check.Benchmark
{
    public static class Program
    {
        public static void Main(string[] _)
        {
            BenchmarkRunner.Run<ThrowIfAnyItemIsNullOrWhitespaceBenchmark>();
            BenchmarkRunner.Run<ThrowIfContainsBenchmark>();
            BenchmarkRunner.Run<ThrowIfEmptyBenchmark>();
            BenchmarkRunner.Run<ThrowIfNullBenchmark>();
            Console.ReadLine();
        }
    }
}
