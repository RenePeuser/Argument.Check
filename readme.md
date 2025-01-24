# Argument.Check

Argument.Check is a very simple library which makes it very easy to check your arguments or variables for different conditions like 'Null'.
It is super fast it is using the new [[CallerMemberNameAttribute]](https://learn.microsoft.com/de-de/dotnet/api/system.runtime.compilerservices.callermembernameattribute?view=net-7.0)

## Getting started

### Prerequisites
* [.Net 9](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)

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

### Argument must be an interface
```csharp
public MyClass(object value)
{
    Throw.IfNotInterface(value); 
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

