using System;
using System.Collections.Generic;
using System.Diagnostics;
using Argument.Check.Extensions;

namespace Argument.Check.ThrowHelper
{
    public partial class Throw
    {
        [DebuggerHidden]
        public static void IfNullOrAnyItemIsNull<T>(Func<IEnumerable<T>> argumentFunc)
        {
            IfNull(() => argumentFunc);
            IfNull(argumentFunc);

            if (!argumentFunc().IsAnyItemNull())
            {
                return;
            }

            ThrowIsAnyItemNullException(argumentFunc, arg => arg.Is<IEnumerable<T>>() && arg.Cast<IEnumerable<T>>().IsAnyItemNull());
        }

        [DebuggerHidden]
        private static void ThrowIsAnyItemNullException<T>(
            Func<IEnumerable<T>> argumentFunc,
            Func<object, bool> predicate)
        {
            throw new ArgumentNullException(argumentFunc.GetParameterName(predicate), $"At least one item in the enumeration '{argumentFunc()}' was null.");
        }
    }
}
