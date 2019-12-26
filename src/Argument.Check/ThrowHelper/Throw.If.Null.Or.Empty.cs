using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Argument.Check
{
    public static partial class Throw
    {
        [DebuggerHidden]
        public static string IfNullOrEmpty(Func<string> argumentFunc)
        {
            Throw.IfNull(() => argumentFunc);
            Throw.IfNull(argumentFunc);
            Throw.IfEmpty(argumentFunc);

            return argumentFunc();
        }

        [DebuggerHidden]
        public static IEnumerable<T> IfNullOrEmpty<T>(Func<IEnumerable<T>> argumentFunc)
        {
            Throw.IfNull(() => argumentFunc);
            Throw.IfNull(argumentFunc);
            Throw.IfEmpty(argumentFunc);

            return argumentFunc();
        }
    }
}
