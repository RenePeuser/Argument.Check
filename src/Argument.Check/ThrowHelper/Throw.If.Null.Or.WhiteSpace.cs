using System;
using System.Diagnostics;

namespace Argument.Check
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
