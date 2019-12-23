using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Argument.Check.Extensions;

namespace Argument.Check.ThrowHelper
{
    public static partial class Throw
    {
        [DebuggerHidden]
        public static void IfEmpty(Func<string> argumentFunc)
        {
            IfNull(() => argumentFunc);
            IfNull(argumentFunc);


            if (!argumentFunc().IsEmpty())
            {
                return;
            }

            throw new ArgumentException("The string must not be empty.", argumentFunc.GetParameterName(arg => arg.Is<string>() && arg.Cast<string>().IsEmpty()));
        }

        [DebuggerHidden]
        public static void IfEmpty<T>(Func<IEnumerable<T>> argumentFunc)
        {
            IfNull(() => argumentFunc);
            IfNull(argumentFunc);

            if (argumentFunc().Any())
            {
                return;
            }

            throw new ArgumentException("The enumerable must not be empty.", argumentFunc.GetParameterName(arg => arg.Is<IEnumerable<T>>() && arg.Cast<IEnumerable<T>>().IsEmpty()));
        }
    }
}
