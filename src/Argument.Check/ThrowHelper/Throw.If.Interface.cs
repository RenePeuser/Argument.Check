using System;
using System.Diagnostics;

namespace Argument.Check.ThrowHelper
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
    }
}
