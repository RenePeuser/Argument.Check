using System;
using System.Diagnostics;
using Argument.Check.Extensions;

namespace Argument.Check
{
    public partial class Throw
    {
        [DebuggerHidden]
        public static T IfEqualsTo<T>(Func<T> argumentFunc, T expectedValue)
        {
            IfNull(() => argumentFunc);
            
            var argument = argumentFunc();
            if (!argument.EqualsTo(expectedValue))
            {
                return argument;
            }

            throw new ArgumentException($"The argument value: '{argument}' was equal to: '{expectedValue}'.", argumentFunc.GetParameterName(arg => arg.EqualsTo(expectedValue)));
        }
    }
}
