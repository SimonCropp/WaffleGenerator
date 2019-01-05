# WaffleGenerator

Produces text which, on first glance, looks like real, ponderous, prose; replete with clichés.

**This project is supported by the community via [Patreon sponsorship](https://www.patreon.com/join/simoncropp). If you are using this project to deliver business value or build commercial software it is expected that you will provide support [via Patreon](https://www.patreon.com/join/simoncropp).**

Example content:

```
The Aesthetic Of Economico-Social Disposition

"In this regard, the underlying surrealism of the take home message should not 
divert attention from The Aesthetic Of Economico-Social Disposition"
(Humphrey Yokomoto in The Journal of the Total Entative Item (20044U))

On any rational basis, a particular factor, such as the functional baseline, the 
analogy of object, the strategic requirements or the principal overriding programming 
provides an interesting insight into the complementary functional derivation. 
This trend may dissipate due to the mensurable proficiency.
```

This output can be used in similar way to [Lorem ipsum](https://en.wikipedia.org/wiki/Lorem_ipsum) content, in that it is useful for producing text for build software and producing design mockups.

Based on the awesome work by [Andrew Clarke](https://www.red-gate.com/simple-talk/author/andrew-clarke/) outlined in [The Waffle Generator](https://www.red-gate.com/simple-talk/dotnet/net-tools/the-waffle-generator/).

Code based on [SDGGenerators - Red Gate SQL Data Generator Community Generators](https://archive.codeplex.com/?p=sdggenerators).

## Blazor App

The [Blazing Waffles](http://wafflegen.azurewebsites.net/) app allows the generation of waffle text online.

 * Azure Website: http://wafflegen.azurewebsites.net/
 * Source: https://github.com/gbiellem/BlazingWaffles


## Main Package - WaffleGenerator [![NuGet Status](http://img.shields.io/nuget/v/WaffleGenerator.svg?style=flat)](https://www.nuget.org/packages/WaffleGenerator/)

https://nuget.org/packages/WaffleGenerator/

    PM> Install-Package WaffleGenerator


### Usage

The `WaffleEngine` can be used to produce Html or text:

```csharp
var html = WaffleEngine.Html(
    paragraphs: 1,
    includeHeading: true);
Debug.WriteLine(html);
```

```csharp
var text = WaffleEngine.Text(
    paragraphs: 1,
    includeHeading: true);
Debug.WriteLine(text);
```

## WaffleGenerator.Bogus [![NuGet Status](http://img.shields.io/nuget/v/WaffleGenerator.Bogus.svg?style=flat)](https://www.nuget.org/packages/WaffleGenerator.Bogus/)

Extends [Bogus](https://github.com/bchavez/Bogus) to use WaffleGenerator.

https://nuget.org/packages/WaffleGenerator.Bogus/

    PM> Install-Package WaffleGenerator.Bogus


### Usage

The entry extension method is `WaffleHtml()` or `WaffleText()`:

```csharp
var faker = new Faker<Target>()
    .RuleFor(u => u.Title, (f, u) => f.WaffleTitle())
    .RuleFor(u => u.Property1, (f, u) => f.WaffleHtml())
    .RuleFor(u => u.Property2, (f, u) => f.WaffleHtml(paragraphs: 4, includeHeading: true))
    .RuleFor(u => u.Property3, (f, u) => f.WaffleText())
    .RuleFor(u => u.Property4, (f, u) => f.WaffleText(paragraphs: 4, includeHeading: false));

var target = faker.Generate();
Debug.WriteLine(target.Title);
Debug.WriteLine(target.Property1);
Debug.WriteLine(target.Property2);
Debug.WriteLine(target.Property3);
Debug.WriteLine(target.Property4);
```


## Icon

<a href="https://thenounproject.com/term/waffle/836862/" target="_blank">Waffle</a> designed by Made by Made from The Noun Project