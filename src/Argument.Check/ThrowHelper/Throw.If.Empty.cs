using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Argument.Check.Extensions;

namespace Argument.Check
{
    public static partial class Throw
    {
        [DebuggerHidden]
        public static string IfEmpty(Func<string> argumentFunc)
        {
            IfNull(() => argumentFunc);
            IfNull(argumentFunc);


            var argument = argumentFunc();
            if (!argument.IsEmpty())
            {
                return argument;
            }

            throw new ArgumentException("The string must not be empty.", argumentFunc.GetParameterName(arg => arg.Is<string>() && arg.Cast<string>().IsEmpty()));
        }

        [DebuggerHidden]
        public static IEnumerable<T> IfEmpty<T>(Func<IEnumerable<T>> argumentFunc)
        {
            IfNull(() => argumentFunc);
            IfNull(argumentFunc);

            var argument = argumentFunc();
            if (argument.Any())
            {
                return argument;
            }

            throw new ArgumentException("The enumerable must not be empty.", argumentFunc.GetParameterName(arg => arg.Is<IEnumerable<T>>() && arg.Cast<IEnumerable<T>>().IsEmpty()));
        }
    }
}
