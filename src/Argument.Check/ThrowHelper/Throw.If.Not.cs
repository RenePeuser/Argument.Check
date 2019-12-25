using System;
using System.Diagnostics;
using Argument.Check.Extensions;

namespace Argument.Check
{
    public partial class Throw
    {
        [DebuggerHidden]
        public static void IfNot<T>(Func<T> argumentFunc, Func<T, bool> validationPredicate)
        {
            IfNull(() => argumentFunc);
            IfNull(() => validationPredicate);

            IfInternal(argumentFunc, validationPredicate, b => b.IsFalse(), string.Empty);
        }

        [DebuggerHidden]
        public static void IfNot<T>(Func<T> argumentFunc, Func<T, bool> validationPredicate, string message)
        {
            IfNull(() => argumentFunc);
            IfNull(() => validationPredicate);

            IfInternal(argumentFunc, validationPredicate, b => b.IsFalse(), message);
        }
    }
}
