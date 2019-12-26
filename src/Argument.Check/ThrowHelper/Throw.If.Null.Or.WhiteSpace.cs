using System;
using System.Diagnostics;

namespace Argument.Check
{
    public static partial class Throw
    {
        [DebuggerHidden]
        public static string IfNullOrWhiteSpace(Func<string> argumentFunc)
        {
            Throw.IfNull(() => argumentFunc);
            Throw.IfNull(argumentFunc);
            Throw.IfEmpty(argumentFunc);
            Throw.IfWhitespace(argumentFunc);

            return argumentFunc();
        }
    }
}
