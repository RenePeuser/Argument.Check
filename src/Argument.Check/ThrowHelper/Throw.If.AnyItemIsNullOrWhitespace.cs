using System;
using System.Collections.Generic;
using System.Diagnostics;
using Argument.Check.Extensions;

namespace Argument.Check.ThrowHelper
{
    public partial class Throw
    {
        [DebuggerHidden]
        public static void IfAnyItemIsNullOrWhitespace(Func<IEnumerable<string>> argumentFunc)
        {
            IfNull(() => argumentFunc);
            IfNull(argumentFunc);

            if (!argumentFunc().IsAnyItemNullOrWhitespace())
            {
                return;
            }

            ThrowIsAnyItemNullOrWhiteSpaceException(
                argumentFunc,
                arg => arg.Is<IEnumerable<string>>() && arg.Cast<IEnumerable<string>>().IsAnyItemNullOrWhitespace());
        }

        [DebuggerHidden]
        private static void ThrowIsAnyItemNullOrWhiteSpaceException(
            Func<IEnumerable<string>> argumentFunc,
            Func<object, bool> predicate)
        {
            throw new ArgumentException($"At least one string in the enumeration '{string.Join(",", argumentFunc())}' was null or a whitespace.", argumentFunc.GetParameterName(predicate));
        }
    }
}
