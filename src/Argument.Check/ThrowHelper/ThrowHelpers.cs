#if !DEBUG
using System.Diagnostics;
#endif
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

#pragma warning disable IDE0130 // Same namespace as Throw, which lives in the same folder.
namespace Argument.Check
#pragma warning restore IDE0130
{
    /// <summary>
    /// The cold paths of the <see cref="Throw"/> helpers. Creating the exception and formatting its message
    /// lives here, so the public checks stay small enough for the JIT to inline them.
    /// The messages must stay exactly as they are; they are part of the observable behaviour.
    /// </summary>
    internal static class ThrowHelpers
    {
#if !DEBUG
        [DebuggerHidden]
#endif
        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static void ArgumentNull(string argumentName)
        {
            throw new ArgumentNullException(argumentName);
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static void ArgumentNull(string argumentName, string message)
        {
            throw new ArgumentNullException(argumentName, message);
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static void Argument(string message, string argumentName)
        {
            throw new ArgumentException(message, argumentName);
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static void NullOrEmpty(string? argument, string argumentName)
        {
            if (argument is null)
            {
                throw new ArgumentNullException(argumentName);
            }

            throw new ArgumentException("The string must not be empty.", argumentName);
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static void NullOrWhiteSpace(string? argument, string argumentName)
        {
            if (argument is null)
            {
                throw new ArgumentNullException(argumentName);
            }

            if (argument.Length == 0)
            {
                throw new ArgumentException("The string must not be empty.", argumentName);
            }

            throw new ArgumentException("The string must not be only whitespace.", argumentName);
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static void GreaterThan<T>(T argument, T limit, string argumentName)
        {
            throw new ArgumentOutOfRangeException(argumentName, $"Value: '{argument}' must not be greater than: '{limit}'.");
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static void GreaterOrEqual<T>(T argument, T limit, string argumentName)
        {
            throw new ArgumentOutOfRangeException(argumentName, $"Value: '{argument}' must not be greater than or equal to: '{limit}'.");
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static void LessThan<T>(T argument, T limit, string argumentName)
        {
            throw new ArgumentOutOfRangeException(argumentName, $"Value: '{argument}' must not be less than: '{limit}'.");
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static void LessOrEqual<T>(T argument, T limit, string argumentName)
        {
            throw new ArgumentOutOfRangeException(argumentName, $"Value: '{argument}' must not be less than or equal to: '{limit}'.");
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static void OutOfRange<T>(T argument, T min, T max, string argumentName)
        {
            throw new ArgumentOutOfRangeException(argumentName, $"Value: '{argument}' is not in expected range from '{min}' to '{max}'.");
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static void EqualsTo<T>(T argument, T expectedValue, string argumentName)
        {
            throw new ArgumentException($"The argument value: '{argument}' was equal to: '{expectedValue}'.", argumentName);
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static void NotEqualsTo<T>(T? argument, T? expectedValue, string argumentName)
        {
            throw new ArgumentException($"The argument value: '{argument}' is not equal to: '{expectedValue}'.", argumentName);
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static void Contains<T>(T argument, string argumentName)
        {
            throw new ArgumentException($"The argument '{argument}' is contained in the enumeration.", argumentName);
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static void NotContains<T>(T argument, string argumentName)
        {
            throw new ArgumentException($"The argument '{argument}' is not contained in the enumeration.", argumentName);
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static void LengthIs(string argument, int length, string argumentName)
        {
            throw new ArgumentOutOfRangeException(argumentName, $"String length: '{argument}' must not be equals to to a length of: '{length}'.");
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static void LengthIsNot(string argument, int length, string argumentName)
        {
            throw new ArgumentOutOfRangeException(argumentName, $"String length: '{argument}' is not as expected. Expected value: '{length}'.");
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static void TypeIs<T>(object argument, string argumentName)
        {
            throw new ArgumentException($"The given type: '{argument.GetType()}' is the expected type: '{typeof(T)}'.", argumentName);
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static void TypeIsNot<T>(object argument, string argumentName)
        {
            throw new ArgumentException($"The given type: '{argument.GetType()}' is not the expected type: '{typeof(T)}'.", argumentName);
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static void AnyItemIsNullOrWhitespace(IEnumerable<string?> argument, string argumentName)
        {
            throw new ArgumentException($"At least one string in the enumeration '{string.Join(",", argument)}' was null or a whitespace.", argumentName);
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static void NullOrAny<T>(Func<T?, bool> predicate, string argumentName)
        {
            throw new ArgumentException($"The sequence must not contain any items that satisfy the given predicate: '{predicate.Method.Name}'.", argumentName);
        }

#if !DEBUG
        [DebuggerHidden]
#endif
        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static void AnyItemIsNull(string argumentName)
        {
            throw new ArgumentNullException(argumentName, $"At least one item in the enumeration '{argumentName}' was null.");
        }
    }
}
