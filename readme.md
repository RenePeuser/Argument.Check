# Argument.Check

A library to check your arguments in a simple comfort way. This library do not use 'Expression' or 'nameof(arg)'. 
It is based on Func<T>. So no performance issue during positive argument check.

## Install

You can install this package over your NugetPack-Manager in your Visual Studio

![](./assets/nuget-pack-manager.png)

or use the .NET-CLI

```bash
dotnet add package Argument.Check --version 1.0.1
```

## Configure Resharper (Optional)

If you use this package you can configure your default null check with a custom expression in your
Resharper settings.

![](./assets/resharper-settings.png)

This setting has following effect:

![](./assets/resharper-agrument-null-check.gif)


## The debugger will break where the exception happened
![](./assets/exception-breaks.png)


## Samples

Each Throw helper could also be used like a "Throw Expression".

### Null check
```csharp
public MyClass(object arg)
{
    Throw.IfNull(() =>  arg);
}
```

### Null check, like 'Throw Expressions'
```csharp
public MyClass(IService service)
{
    _service = Throw.IfNull(() =>  service);
}
```

### File exists
```csharp
public MyClass(FileInfo fileInfo)
{
    Throw.IfExists(() =>  fileInfo);
}
```

### Directory exists
```csharp
public MyClass(DirectoryInfo directoryInfo)
{
    Throw.IfExists(() => directoryInfo);
}
```

### Value is greater than
```csharp
public MyClass(int value)
{
    Throw.IfGreaterThan(() => value, 10);
}
```

### Value is less than
```csharp
public MyClass(int value)
{
    Throw.IfLessThan(() => value, 10);
}
```

### Value is out of range
```csharp
public MyClass(int value)
{
    Throw.IfOutOfRange(() => value, 10, 100);
}
```

### Custom expression
```csharp
public MyClass(string value)
{
    Throw.If(() => value, v => v.Length > 10 && v.Contains("abc"), "The given string length must not be longer than 10, and must not contain 'abc'");
}
```

### Argument must be an interface
```csharp
public MyClass(object value)
{
    Throw.IfNotInterface(() => value); 
}
```

### Argument must be equal to any expectation
```csharp
public MyClass(object value)
{
    Throw.IfNotEqualsTo(() => value, new object()); 
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

