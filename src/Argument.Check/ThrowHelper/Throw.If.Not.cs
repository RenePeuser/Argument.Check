using System;
using System.Diagnostics;
using Argument.Check.Extensions;

namespace Argument.Check
{
    public partial class Throw
    {
        [DebuggerHidden]
        public static T IfNot<T>(Func<T> argumentFunc, Func<T, bool> validationPredicate)
        {
            IfNull(() => argumentFunc);
            IfNull(() => validationPredicate);

            var argument = argumentFunc();
            var isMatching = validationPredicate(argument);

            if (isMatching)
            {
                return argument;
            }

            throw new ArgumentException(string.Empty, argumentFunc.GetParameterName(arg => arg.EqualsTo(argument)));
        }

        [DebuggerHidden]
        public static T IfNot<T>(Func<T> argumentFunc, Func<T, bool> validationPredicate, string message)
        {
            IfNull(() => argumentFunc);
            IfNull(() => validationPredicate);

            var argument = argumentFunc();
            var isMatching = validationPredicate(argument);

            if (isMatching)
            {
                return argument;
            }

            throw new ArgumentException(message, argumentFunc.GetParameterName(arg => arg.EqualsTo(argument)));
        }
    }
}
