using System;
using System.Diagnostics;
using Argument.Check.Extensions;

namespace Argument.Check
{
    public static partial class Throw
    {
        [DebuggerHidden]
        public static string IfWhitespace(Func<string> argumentFunc)
        {
            Throw.IfNull(() => argumentFunc);
            Throw.IfNull(argumentFunc);

            var argument = argumentFunc();

            if (!argument.IsNullOrWhiteSpace())
            {
                return argument;
            }

            throw new ArgumentException("The string must not be only whitespace.", argumentFunc.GetParameterName(arg => arg.Is<string>() && arg.Cast<string>().IsWhitespace()));
        }
    }
}
