using System;
using System.Diagnostics;

namespace Argument.Check.ThrowHelper
{
    public static partial class Throw
    {
        [DebuggerHidden]
        public static void IfNullOrWhiteSpace(Func<string> argumentFunc)
        {
            IfNull(() => argumentFunc);
            IfNullInternal(argumentFunc);
            IfEmpty(argumentFunc);
            IfWhitespace(argumentFunc);
        }
    }
}
