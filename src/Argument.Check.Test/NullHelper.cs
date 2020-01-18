namespace Argument.Check.Test
{
    public static class NullHelper
    {
        public static T GetNullOf<T>()
        {
            return default(T);
        }
    }
}
