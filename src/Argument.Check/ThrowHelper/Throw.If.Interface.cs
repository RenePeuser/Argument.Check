using System;
using System.Diagnostics;
using Argument.Check.Extensions;

namespace Argument.Check
{
    public partial class Throw
    {
        [DebuggerHidden]
        public static void IfInterface<T>() where T : class
        {
            var type = typeof(T);
            if (type.IsInterface)
            {
                throw new ArgumentException($"Type: '{type}' must not be an interface.");
            }
        }

        [DebuggerHidden]
        public static T IfInterface<T>(Func<T> argumentFunc) where T : class
        {
            Throw.IfNull(() => argumentFunc);
            Throw.IfNull(argumentFunc);

            var argument = argumentFunc();
            var type = typeof(T);
            if (type.IsInterface.IsFalse())
            {
                return argument;
            }

            throw new ArgumentException($"Type: '{type}' must not be an interface.");
        }
    }
}
