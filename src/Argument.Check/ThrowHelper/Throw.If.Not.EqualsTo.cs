using System;
using System.Diagnostics;
using Argument.Check.Extensions;

namespace Argument.Check.ThrowHelper
{
    public partial class Throw
    {
        [DebuggerHidden]
        public static void IfNotEqualsTo<T>(Func<T> argumentFunc, T expectedValue)
        {
            IfNull(() => argumentFunc);
            IfNotEqualsToInternal(argumentFunc, expectedValue);
        }

        [DebuggerHidden]
        private static void IfNotEqualsToInternal<T>(Func<T> argumentFunc, T expectedValue)
        {
            var argumentValue = argumentFunc();
            if (!argumentValue.NotEqualsTo(expectedValue))
            {
                return;
            }

            throw new ArgumentException(
                $"The argument value: '{argumentValue}' is not equal to: '{expectedValue}'.", argumentFunc.GetParameterName(arg => arg.NotEqualsTo(expectedValue)));
        }
    }
}
