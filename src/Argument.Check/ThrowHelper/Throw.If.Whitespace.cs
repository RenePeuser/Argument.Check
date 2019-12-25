using System;
using System.Diagnostics;
using Argument.Check.Extensions;

namespace Argument.Check
{
    public static partial class Throw
    {
        [DebuggerHidden]
        public static void IfWhitespace(Func<string> argument)
        {
            IfNull(() => argument);
            IfNullInternal(argument);

            if (!argument().IsNullOrWhiteSpace())
            {
                return;
            }

            throw new ArgumentException("The string must not be only whitespace.", argument.GetParameterName(arg => arg.Is<string>() && arg.Cast<string>().IsWhitespace()));
        }
    }
}
