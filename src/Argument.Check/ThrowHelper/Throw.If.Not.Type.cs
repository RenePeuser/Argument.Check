using System;
using System.Diagnostics;
using Argument.Check.Extensions;

namespace Argument.Check
{
    public partial class Throw
    {
        [DebuggerHidden]
        public static object IfNotType<T>(Func<object> argumentFunc) where T : class
        {
            IfNull(() => argumentFunc);
            IfNull(argumentFunc);

            var argument = argumentFunc();
            if (!argument.IsNotTypeOf<T>())
            {
                return argument;
            }

            throw new ArgumentException($"The given type: '{argument.GetType()}' is not the expected type: '{typeof(T)}'.", argumentFunc.GetParameterName(arg => arg.EqualsTo(argument) && arg.IsNotTypeOf<T>()));
        }
    }
}
