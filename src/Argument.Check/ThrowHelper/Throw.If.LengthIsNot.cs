using System;
using System.Diagnostics;
using Argument.Check.Extensions;

namespace Argument.Check
{
    public static partial class Throw
    {
        [DebuggerHidden]
        public static void IfLengthIsNot(Func<string> argumentFunc, int length)
        {
            IfNull(() => argumentFunc);
            IfNull(argumentFunc);

            if (!argumentFunc().Length.NotEqualsTo(length))
            {
                return;
            }

            ThrowStringLengthIsNotException(argumentFunc, length, arg => arg.Is<string>() && arg.Cast<string>().Length.NotEqualsTo(length));
        }

        [DebuggerHidden]
        private static void ThrowStringLengthIsNotException(
            Func<string> argumentFunc,
            int length,
            Func<object, bool> predicate)
        {
            throw new ArgumentOutOfRangeException(argumentFunc.GetParameterName(predicate), $"String length: '{argumentFunc()}' is not as expected. Expected value: '{length}'.");
        }
    }
}
