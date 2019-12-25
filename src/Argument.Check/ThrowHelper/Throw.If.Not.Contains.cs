using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Argument.Check.Extensions;

namespace Argument.Check
{
    public partial class Throw
    {
        [DebuggerHidden]
        public static void IfNotContains<T>(Func<T> argumentFunc, IEnumerable<T> source)
        {
            IfNull(() => source);
            IfNull(() => argumentFunc);

            var argument = argumentFunc();
            if (source.Contains(argument))
            {
                return;
            }

            throw new ArgumentException(
                $"The argument '{argument}' is not contained in the enumeration.", argumentFunc.GetParameterName(arg => arg.EqualsTo(argument) && !source.Contains(argument)));
        }
    }
}
