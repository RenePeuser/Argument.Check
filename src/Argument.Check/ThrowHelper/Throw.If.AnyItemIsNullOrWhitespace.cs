using System;
using System.Collections.Generic;
using System.Diagnostics;
using Argument.Check.Extensions;

namespace Argument.Check
{
    public partial class Throw
    {
        [DebuggerHidden]
        public static IEnumerable<string> IfAnyItemIsNullOrWhitespace(Func<IEnumerable<string>> argumentFunc)
        {
            IfNull(() => argumentFunc);
            IfNull(argumentFunc);

            var argument = argumentFunc();
            if (!argument.IsAnyItemNullOrWhitespace())
            {
                return argument;
            }

            throw new ArgumentException($"At least one string in the enumeration '{string.Join(",", argument)}' was null or a whitespace.", argumentFunc.GetParameterName(Predicate));

            bool Predicate(object arg)
            {
                return arg.Is<IEnumerable<string>>() && arg.Cast<IEnumerable<string>>().IsAnyItemNullOrWhitespace();
            }
        }
    }
}
