using System;
using System.Diagnostics;

namespace Argument.Check
{
    public partial class Throw
    {
        [DebuggerHidden]
        public static void IfNotInterface<T>() where T : class
        {
            var type = typeof(T);
            if (!type.IsInterface)
            {
                throw new ArgumentException($"Type: '{type}' must be an interface.");
            }
        }

        [DebuggerHidden]
        public static T IfNotInterface<T>(Func<T> argumentFunc) where T : class
        {
            Throw.IfNull(() => argumentFunc);
            Throw.IfNull(argumentFunc);

            var argument = argumentFunc();
            var type = typeof(T);
            if (type.IsInterface)
            {
                return argument;
            }

            throw new ArgumentException($"Type: '{type}' must be an interface.");
        }
    }
}
