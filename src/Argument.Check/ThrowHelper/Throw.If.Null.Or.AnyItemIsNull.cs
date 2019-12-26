using System;
using System.Collections.Generic;
using System.Diagnostics;
using Argument.Check.Extensions;

namespace Argument.Check
{
    public partial class Throw
    {
        [DebuggerHidden]
        public static IEnumerable<T> IfNullOrAnyItemIsNull<T>(Func<IEnumerable<T>> argumentFunc)
        {
            Throw.IfNull(() => argumentFunc);
            Throw.IfNull(argumentFunc);

            var argument = argumentFunc();
            if (!argument.IsAnyItemNull())
            {
                return argument;
            }

            throw new ArgumentNullException(argumentFunc.GetParameterName(Predicate), $"At least one item in the enumeration '{argumentFunc()}' was null.");

            bool Predicate(object arg)
            {
                return arg.Is<IEnumerable<T>>() && arg.Cast<IEnumerable<T>>().IsAnyItemNull();
            }
        }
    }
}
