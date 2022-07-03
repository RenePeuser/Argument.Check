using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace Argument.Check.Benchmark
{
    public class ThrowIfContainsBenchmark
    {
        [Benchmark]
        public object Throw_Expression()
        {
            return ThrowIfContains("z", new List<string>() { "a" });

            static string ThrowIfContains(string argument, IEnumerable<string> sequence)
            {
                var argumentChecked = argument ?? throw new ArgumentNullException(nameof(argument));
                var sequenceChecked = sequence ?? throw new ArgumentNullException(nameof(sequence));
                if (sequenceChecked.Contains(argumentChecked))
                {
                    throw new ArgumentException($"The given sequence must not contains '{argument}'", nameof(argument));
                }

                return argumentChecked;
            }
        }

        [Benchmark]
        public object Classic_Null_Check()
        {
            return ThrowIfContains("z", new List<string> { "a" });

            static string ThrowIfContains(string argument, IEnumerable<string> sequence)
            {
                if (argument == null)
                {
                    throw new ArgumentNullException(nameof(argument));
                }

                if (sequence == null)
                {
                    throw new ArgumentNullException(nameof(sequence));
                }

                if (sequence.Contains(argument))
                {
                    throw new ArgumentException($"The given sequence must not contains '{argument}'", nameof(sequence));
                }


                return argument;
            }
        }

        [Benchmark]
        public object Throw_If_Null_Func()
        {
            return ThrowIfContains("z", new List<string> { "a" });

            static string ThrowIfContains(string argument, IEnumerable<string> sequence)
            {
                return Throw.IfContains(() => argument, sequence);
            }
        }

        [Benchmark]
        public object Throw_If_Null()
        {
            return ThrowIfContains("z", new List<string> { "a" });

            static string ThrowIfContains(string value, IEnumerable<string> sequence)
            {
                return Throw.IfContains(value, sequence);
            }
        }
    }
}
