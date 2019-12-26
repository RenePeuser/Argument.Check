using System;
using System.Diagnostics;
using Argument.Check.Extensions;

namespace Argument.Check
{
    public partial class Throw
    {
        [DebuggerHidden]
        public static T IfOutOfRange<T>(Func<T> argumentFunc, T min, T max) where T : IComparable
        {
            IfNull(() => argumentFunc);

            var argument = argumentFunc();
            if (!argument.IsOutOfRange(min, max))
            {
                return argument;
            }

            throw new ArgumentOutOfRangeException(argumentFunc.GetParameterName(Predicate), $"Value: '{argument}' is not in expected range from '{min}' to '{max}'.");

            bool Predicate(object arg)
            {
                return arg is T && ((T) arg).IsOutOfRange(min, max);
            }
        }
    }
}
