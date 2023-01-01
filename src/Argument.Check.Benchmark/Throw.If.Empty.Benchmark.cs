using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace Argument.Check.Benchmark
{
    public class ThrowIfEmptyBenchmark
    {
        [Benchmark]
        public object Throw_Expression()
        {
            return ThrowIfEmpty(new List<string>() { "a" });

            static IEnumerable<string> ThrowIfEmpty(IEnumerable<string> arg)
            {
                var items = arg ?? throw new ArgumentNullException(nameof(arg));
                if (!items.Any())
                {
                    throw new ArgumentException($"The given sequence must not be empty", nameof(arg));
                }

                return items;
            }
        }

        [Benchmark]
        public object Classic_Null_Check()
        {
            return ThrowIfEmpty(new List<string> { "a" });

            static IEnumerable<string> ThrowIfEmpty(IEnumerable<string> arg)
            {
                if (arg == null)
                {
                    throw new ArgumentNullException(nameof(arg));
                }

                if (!arg.Any())
                {
                    throw new ArgumentException($"The given sequence must not be empty", nameof(arg));
                }

                return arg;
            }
        }

        [Benchmark]
        public object Throw_If_Null()
        {
            return ThrowIfEmpty(new List<string> { "a" });

            static IEnumerable<string> ThrowIfEmpty(IEnumerable<string> arg)
            {
                return Throw.IfEmpty(arg);
            }
        }
    }
}
