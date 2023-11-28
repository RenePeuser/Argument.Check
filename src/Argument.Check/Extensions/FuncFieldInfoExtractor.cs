#if !DEBUG
using System.Diagnostics;
#endif
using System.Reflection;

namespace Argument.Check.Extensions
{
    internal static class FuncFieldInfoExtractor
    {
#if !DEBUG
        [DebuggerHidden]
#endif
        internal static FieldInfo GetFieldInfo<T>(this Func<T> func, Func<object, bool> predicate)
        {
            Throw.IfNull(func);

            if (func.Target.IsNull())
            {
                throw new ArgumentException("The target of the given argument check is null, please check that you are not checking constant values !");
            }

            var targetType = func.Target.GetType();
            var fields = targetType.GetFields();
            var rebuildIlMethods = func.Rebuild(fields, predicate);
            var checkArgumentFieldInfo = rebuildIlMethods.First(m => m.MethodInfo.EqualsTo(func.Method));
            return checkArgumentFieldInfo.ReturnValue;
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        internal static string GetParameterName<T>(this Func<T> func, Func<object, bool> predicate)
        {
            Throw.IfNull(func);
            Throw.IfNull(predicate);

            var result = GetFieldInfo(func, predicate);
            return result.Name;
        }
    }
}
