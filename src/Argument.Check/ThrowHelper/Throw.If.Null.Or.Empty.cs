using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Argument.Check.ThrowHelper
{
    public static partial class Throw
    {
        [DebuggerHidden]
        public static void IfNullOrEmpty(Func<string> argumentFunc)
        {
            IfNull(() => argumentFunc);
            IfNullInternal(argumentFunc);
            IfEmpty(argumentFunc);
        }

        [DebuggerHidden]
        public static void IfNullOrEmpty<T>(Func<IEnumerable<T>> argumentFunc)
        {
            IfNull(() => argumentFunc);
            IfNullInternal(argumentFunc);
            IfEmpty(argumentFunc);
        }
    }
}
