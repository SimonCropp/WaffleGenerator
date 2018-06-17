# WaffleGenerator


### Code sourced  from
 
https://archive.codeplex.com/?p=sdggenerators

Provides a strong typed .NET API for [big-list-of-naughty-strings](https://github.com/minimaxir/big-list-of-naughty-strings)

### Original Article

Title: The Waffle Generator
Author: Andrew Clarke

The article about this generator and how it was created can be found at:

http://www.simple-talk.com/dotnet/.net-tools/the-waffle-generator/


## WaffleGenerator


### The NuGet packages [![NuGet Status](http://img.shields.io/nuget/v/WaffleGenerator.svg?style=flat)](https://www.nuget.org/packages/WaffleGenerator/)

https://nuget.org/packages/WaffleGenerator/

    PM> Install-Package WaffleGenerator


### Usage

The entry type is a static class `TheNaughtyStrings`. It exposes all strings via `TheNaughtyStrings.All` and individual categories by name:

```csharp
var items = TheNaughtyStrings.All.Take(10);
var emoji = TheNaughtyStrings.Emoji.Take(10);
```

## WaffleGenerator.Bogus

Extends [Bogus](https://github.com/bchavez/Bogus) to use Naughty Strings.


### WaffleGenerator.Bogus [![NuGet Status](http://img.shields.io/nuget/v/WaffleGenerator.Bogus.svg?style=flat)](https://www.nuget.org/packages/WaffleGenerator.Bogus/)

https://nuget.org/packages/WaffleGenerator.Bogus/

    PM> Install-Package WaffleGenerator.Bogus


### Usage

The entry extension method is `Naughty()`. It exposes all strings via `.String()` and individual categories by name:

```csharp
var faker = new Faker<Target>()
    .RuleFor(u => u.Property1, (f, u) => f.Naughty().String())
    .RuleFor(u => u.Property2, (f, u) => f.Naughty().Emoji());

var target = faker.Generate();
Debug.WriteLine(target.Property1);
Debug.WriteLine(target.Property2);
```


## Icon


<a href="https://thenounproject.com/term/naughty/1777956/" target="_blank">Naughty</a> designed by <a href="https://thenounproject.com/AomAm/" target="_blank">AomAm</a> from The Noun Project

Lock by from the Noun Project

