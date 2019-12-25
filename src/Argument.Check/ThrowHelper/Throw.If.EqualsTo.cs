using System;
using System.Diagnostics;
using Argument.Check.Extensions;

namespace Argument.Check
{
    public partial class Throw
    {
        [DebuggerHidden]
        public static void IfEqualsTo<T>(Func<T> argumentFunc, T expectedValue)
        {
            IfNull(() => argumentFunc);
            IfEqualsToInternal(argumentFunc, expectedValue);
        }

        [DebuggerHidden]
        private static void IfEqualsToInternal<T>(Func<T> argumentFunc, T expectedValue)
        {
            var argumentValue = argumentFunc();
            if (!argumentValue.EqualsTo(expectedValue))
            {
                return;
            }

            throw new ArgumentException(
                $"The argument value: '{argumentValue}' was equal to: '{expectedValue}'.", argumentFunc.GetParameterName(arg => arg.EqualsTo(expectedValue)));
        }
    }
}
