using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Argument.Check.Extensions;

namespace Argument.Check.ThrowHelper
{
    public partial class Throw
    {
        [DebuggerHidden]
        public static void IfNullOrAny<T>(Func<IEnumerable<T>> argumentFunc, Func<T, bool> predicate)
        {
            IfNull(() => argumentFunc);
            IfNull(() => predicate);
            IfNullInternal(argumentFunc);

            if (!argumentFunc().Any(predicate))
            {
                return;
            }

            throw new ArgumentException($"The sequence must not contain any items that satisfy the given predicate: '{predicate.Method.Name}'.", argumentFunc.GetParameterName(x => x.Is<IEnumerable<T>>() && x.Cast<IEnumerable<T>>().Any(predicate)));
        }
    }
}
