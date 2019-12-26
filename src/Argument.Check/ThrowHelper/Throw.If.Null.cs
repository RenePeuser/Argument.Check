using System;
using System.Diagnostics;
using Argument.Check.Extensions;

namespace Argument.Check
{
    public partial class Throw
    {
        [DebuggerHidden]
        public static T IfNull<T>(Func<T> argumentFunc) where T : class
        {
            if (argumentFunc == null)
            {
                throw new ArgumentNullException(nameof(argumentFunc));
            }

            var argument = argumentFunc();
            if (argument.IsNotNull())
            {
                return argument;
            }

            throw new ArgumentNullException(argumentFunc.GetParameterName(arg => arg == null));
        }
    }
}
