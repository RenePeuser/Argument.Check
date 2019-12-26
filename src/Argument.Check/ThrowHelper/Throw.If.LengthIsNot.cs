using System;
using System.Diagnostics;
using Argument.Check.Extensions;

namespace Argument.Check
{
    public static partial class Throw
    {
        [DebuggerHidden]
        public static string IfLengthIsNot(Func<string> argumentFunc, int length)
        {
            IfNull(() => argumentFunc);
            IfNull(argumentFunc);

            var argument = argumentFunc();
            if (!argument.Length.NotEqualsTo(length))
            {
                return argument;
            }

            throw new ArgumentOutOfRangeException(argumentFunc.GetParameterName(Predicate), $"String length: '{argument}' is not as expected. Expected value: '{length}'.");

            bool Predicate(object arg)
            {
                return arg.Is<string>() && arg.Cast<string>().Length.NotEqualsTo(length);
            }
        }
    }
}
