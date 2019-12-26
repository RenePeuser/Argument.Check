# Argument.Check

A library to check your arguments in a simple comfort way. This library do not use 'Expression' or 'nameof(arg)'. 
It is based on Func<T>. So no performance issue during positive argument check.

## Install

You can install this package over your NugetPack-Manager in your Visual Studio

![](./assets/nuget-pack-manager.png)

or use the .NET-CLI

```bash
dotnet add package Argument.Check
```

## Configure Resharper (Optional)

If you use this package you can configure your default null check with a custom expression in your
Resharper settings.

![](./assets/resharper-settings.png)

This setting has follwing effect:

![](./assets/resharper-agrument-null-check.gif)


## Samples

### Null check
```csharp
public MyClass(object arg)
{
    Throw.IfNull(() =>  arg);
}
```

### Null check, like 'Throw Expressions'
```csharp
public MyClass(object service)
{
    _service = Throw.IfNull(() =>  arg);
}
```

### File exists
```csharp
public MyClass(FileInfo fileInfo)
{
    Throw.IfExists(() =>  arg);
}
```

### Directory exists
```csharp
public MyClass(DirectoryInfo directoryInfo)
{
    Throw.IfExists(() =>  arg);
}
```

