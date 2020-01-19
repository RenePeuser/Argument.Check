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

            var targetType = func.Target.GetType();
            var fields = targetType.GetFields();
            

            var rebuildIlMethods = func.Rebuild(fields, predicate);
            var checkArgumentFieldInfo = rebuildIlMethods.First(m => m.MethodInfo.EqualsTo(func.Method));
            return checkArgumentFieldInfo.ReturnValue;
        }

        [DebuggerHidden]
        internal static string GetParameterName<T>(this Func<T> func, Func<object, bool> predicate)
        {
            Throw.IfNull(() => func);

            var result = GetFieldInfo(func, predicate);
            return result.Name;
        }
    }
}
