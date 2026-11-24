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

