using System;
using System.Diagnostics;
using Argument.Check.Extensions;

namespace Argument.Check
{
    public partial class Throw
    {
        [DebuggerHidden]
        public static T IfGreaterOrEqual<T>(Func<T> argumentFunc, T limit) where T : IComparable
        {
            IfNull(() => argumentFunc);

            var argument = argumentFunc();
            if (!argument.IsGreaterOrEqual(limit))
            {
                return argument;
            }

            throw new ArgumentOutOfRangeException(argumentFunc.GetParameterName(Predicate), $"Value: '{argument}' must not be greater than or equal to: '{limit}'.");

            bool Predicate(object arg)
            {
                return arg is T && ((T) arg).IsGreaterOrEqual(limit);
            }
        }
    }
}
