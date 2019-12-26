using System;
using System.Diagnostics;
using Argument.Check.Extensions;

namespace Argument.Check
{
    public partial class Throw
    {
        [DebuggerHidden]
        public static T IfNotEqualsTo<T>(Func<T> argumentFunc, T expectedValue)
        {
            IfNull(() => argumentFunc);
            
            var argument = argumentFunc();
            if (!argument.NotEqualsTo(expectedValue))
            {
                return argument;
            }

            throw new ArgumentException(
                $"The argument value: '{argument}' is not equal to: '{expectedValue}'.", argumentFunc.GetParameterName(arg => arg.NotEqualsTo(expectedValue)));
        }
    }
}
