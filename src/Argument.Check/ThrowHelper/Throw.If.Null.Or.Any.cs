using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Argument.Check.Extensions;

namespace Argument.Check
{
    public partial class Throw
    {
        [DebuggerHidden]
        public static IEnumerable<T> IfNullOrAny<T>(Func<IEnumerable<T>> argumentFunc, Func<T, bool> predicate)
        {
            Throw.IfNull(() => argumentFunc);
            Throw.IfNull(() => predicate);

            var argument = argumentFunc();
            if (!argument.Any(predicate))
            {
                return argument;
            }

            throw new ArgumentException($"The sequence must not contain any items that satisfy the given predicate: '{predicate.Method.Name}'.", argumentFunc.GetParameterName(x => x.Is<IEnumerable<T>>() && x.Cast<IEnumerable<T>>().Any(predicate)));
        }
    }
}
