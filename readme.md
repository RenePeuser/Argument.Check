# Argument.Check

[![Build](https://github.com/RenePeuser/Argument.Check/actions/workflows/build-and-publish.yml/badge.svg)](https://github.com/RenePeuser/Argument.Check/actions/workflows/build-and-publish.yml)
[![NuGet](https://img.shields.io/nuget/v/Argument.Check.svg)](https://www.nuget.org/packages/Argument.Check/)
[![Downloads](https://img.shields.io/nuget/dt/Argument.Check.svg)](https://www.nuget.org/packages/Argument.Check/)
Argument.Check is a very simple library which makes it very easy to check your arguments or variables for different conditions like 'Null'.
It is super fast, because it uses the [CallerArgumentExpressionAttribute](https://learn.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.callerargumentexpressionattribute): the compiler passes the argument's name as a string literal, so there is no delegate, no expression tree and no reflection involved.

## Getting started

### Supported platforms
The package targets `netstandard2.0`, `netstandard2.1`, `net6.0` and `net8.0`, so it runs on
* .NET 6 and newer
* .NET Framework 4.6.1 and newer, Unity, Xamarin and everything else that supports .NET Standard 2.0

### Prerequisites
* A C# 10 (or newer) compiler, which any current .NET SDK and Visual Studio 2022 provide. It is needed for `CallerArgumentExpression`, which fills in the argument name for you.

### Install the package

```dotnetcli
dotnet add package Argument.Check
```

## Performance

Guard clauses run on every call, so they have to be cheap. Since version 5.0.8, Argument.Check
allocates nothing on the happy path and is in the same league as the built-in .NET throw helpers.

Measured side by side in one BenchmarkDotNet run (0.15.8, Intel Core i9-13980HX, happy path, each
check in its own non-inlined method):

| Check | Built-in, .NET 10 | Argument.Check, .NET 10 | Built-in, .NET 9 | Argument.Check, .NET 9 |
| --- | ---: | ---: | ---: | ---: |
| Null | 1.49 ns | 1.26 ns | 1.47 ns | 1.25 ns |
| String null or whitespace | 0.52 ns | 0.92 ns | 2.42 ns | 1.96 ns |
| Greater than 100 | 1.06 ns | 1.13 ns | 0.35 ns | 0.77 ns |
| Range 1–100 | 0.11 ns (two calls) | 1.32 ns | 0.46 ns (two calls) | 1.32 ns |
| Allocated | 0 B | 0 B | 0 B | 0 B |

Everything is below 2.5 ns, and the standard deviation is 0.3–0.9 ns, so most rows are a tie. The
built-in range check stays about a nanosecond ahead, because two comparisons against constants are
almost free for the JIT. On .NET Framework, where the built-in helpers don't exist, the
`netstandard2.0` build is allocation-free as well.

The full story, including what changed in 5.0.8, is on the blog:
[What a guard clause costs](https://renepeuser.github.io/blog/2026-argument-check-what-a-guard-costs/)
and [Argument.Check vs. ThrowIfNull and friends](https://renepeuser.github.io/blog/2026-argument-check-vs-built-in-guards/).

## Samples

Each Throw helper could also be used like a "Throw Expression".

### Null check
```csharp
public MyClass(object arg)
{
    Throw.IfNull(arg);
}
```

### Null check, like 'Throw Expressions'
```csharp
public MyClass(IService service)
{
    _service = Throw.IfNull(service);
}
```

### Null check on a stack variable
```csharp
public MyClass(IService service)
{
    Throw.IfNull(service);

    var result = service.GetSomething();
    Throw.IfNull(result);
}
```

### File exists
```csharp
public MyClass(FileInfo fileInfo)
{
    Throw.IfExists(fileInfo);
}
```

### Directory exists
```csharp
public MyClass(DirectoryInfo directoryInfo)
{
    Throw.IfExists(directoryInfo);
}
```

### Value is greater than
```csharp
public MyClass(int value)
{
    Throw.IfGreaterThan(value, 10);
}
```

### Value is less than
```csharp
public MyClass(int value)
{
    Throw.IfLessThan(value, 10);
}
```

### Value is out of range
```csharp
public MyClass(int value)
{
    Throw.IfOutOfRange(value, 10, 100);
}
```

### Custom expression
```csharp
public MyClass(string value)
{
    Throw.If(value, v => v.Length > 10 && v.Contains("abc"), "The given string length must not be longer than 10, and must not contain 'abc'");
}
```

### Argument must implement an interface
```csharp
public MyClass(object value)
{
    Throw.IfNotInterface<IMyService>(value);
}
```

### Argument must be equal to any expectation
```csharp
public MyClass(object value)
{
    Throw.IfNotEqualsTo(value, new object());
}
```

### And many more.

```csharp
public MyClass(object value)
{    
    Throw.If(...)
    Throw.IfNot(...)

    Throw.IfNull(...)

    Throw.IfEmpty(...)
    Throw.IfNotEmpty(...)

    Throw.IfTypeIs(...)
    Throw.IfTypeIsNot(...)

    Throw.IfEqualsTo(...)
    Throw.IfNotEqualsTo(...)

    Throw.IfExists(...)
    Throw.IfNotExists(...)

    Throw.IfGreaterOrEqual(...)
    Throw.IfGreaterThan(...)

    Throw.IfLessOrEqual(...)
    Throw.IfLessThan(...)

    Throw.IfInterface(...)
    Throw.IfNotInterface(...)
    
    Throw.IfLengthIs(...)
    Throw.IfLengthIsNot(...)
    
    Throw.IfContains(...)
    Throw.IfNotContains(...)
            
    Throw.IfNullOrAny(...)
    Throw.IfNullOrAnyItemIsNull(...)    
    Throw.IfNullOrEmpty(...)
    Throw.IfNullOrWhiteSpace(...)

    Throw.IfOutOfRange(...)
    Throw.IfWhitespace(...)   
    Throw.IfAnyItemIsNullOrWhitespace(...)
}
```

