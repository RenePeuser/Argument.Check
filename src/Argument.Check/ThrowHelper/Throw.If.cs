using System;
using System.Diagnostics;
using Argument.Check.Extensions;

namespace Argument.Check.ThrowHelper
{
    public partial class Throw
    {
        [DebuggerHidden]
        public static void If<T>(Func<T> argumentFunc, Func<T, bool> validationPredicate)
        {
            IfNull(() => argumentFunc);
            IfNull(() => validationPredicate);

            IfInternal(argumentFunc, validationPredicate, b => b, string.Empty);
        }

        [DebuggerHidden]
        public static void If<T>(Func<T> argumentFunc, Func<T, bool> validationPredicate, string message)
        {
            IfNull(() => argumentFunc);
            IfNull(() => validationPredicate);

            IfInternal(argumentFunc, validationPredicate, b => b, message);
        }

        [DebuggerHidden]
        private static void IfInternal<T>(
            Func<T> argumentFunc,
            Func<T, bool> validationPredicate,
            Func<bool, bool> isValidFunc,
            string message)
        {
            var argument = argumentFunc();
            var isValid = validationPredicate(argument);

            if (isValidFunc(isValid))
            {
                throw new ArgumentException(message, argumentFunc.GetParameterName(arg => arg.EqualsTo(argument)));
            }
        }
    }
}
