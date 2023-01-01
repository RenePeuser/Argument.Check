using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using Extensions.Pack;

namespace Argument.Check.Benchmark
{
    public class ThrowIfAnyItemIsNullOrWhitespaceBenchmark
    {
        [Benchmark]
        public object Throw_Expression()
        {
            return IfAnyItemIsNullOrWhitespace(new List<string>() { "a" });

            static IEnumerable<string> IfAnyItemIsNullOrWhitespace(IEnumerable<string> arg)
            {
                var items = arg ?? throw new ArgumentNullException(nameof(arg));
                if (items.Any(string.IsNullOrWhiteSpace))
                {
                    throw new ArgumentException($"The given list contains some elements which are null, empty or whitespace: {items.Flatten(",")}", nameof(arg));
                }

                return items;
            }
        }

        [Benchmark]
        public object Classic_Null_Check()
        {
            return IfAnyItemIsNullOrWhitespace(new List<string> { "a" });

            static IEnumerable<string> IfAnyItemIsNullOrWhitespace(IEnumerable<string> arg)
            {
                if (arg == null)
                {
                    throw new ArgumentNullException(nameof(arg));
                }

                if (arg.Any(string.IsNullOrWhiteSpace))
                {
                    throw new ArgumentException($"The given list contains some elements which are null, empty or whitespace: {arg.Flatten(",")}", nameof(arg));
                }

                return arg;
            }
        }

        [Benchmark]
        public object Throw_If_Null()
        {
            return IfAnyItemIsNullOrWhitespace(new List<string> { "a" });

            static IEnumerable<string> IfAnyItemIsNullOrWhitespace(IEnumerable<string> arg)
            {
                return Throw.IfAnyItemIsNullOrWhitespace(arg);
            }
        }
    }
}
