using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Argument.Check.Extensions
{
    internal static class FuncFieldInfoExtractor
    {
        [DebuggerHidden]
        internal static FieldInfo GetFieldInfo<T>(this Func<T> func, Func<object, bool> predicate)
        {
            Throw.IfNull(() => func);
            Throw.IfNull(() => predicate);

            var fields = func.Target.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            var fieldInfo = fields.FirstOrDefault(f => predicate(f.GetValue(func.Target)));
            if (fieldInfo == null)
            {
                throw new ArgumentException("Expected field info for given predicate was not found, check your predicate !");
            }

            return fieldInfo;
        }

        [DebuggerHidden]
        internal static string GetParameterName<T>(this Func<T> func, Func<object, bool> predicate)
        {
            Throw.IfNull(() => func);
            Throw.IfNull(() => predicate);

            var result = GetFieldInfo(func, predicate);
            return result.Name;
        }
    }
}
