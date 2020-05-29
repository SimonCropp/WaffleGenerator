# <img src="/src/icon.png" height="30px"> WaffleGenerator

[![Build status](https://ci.appveyor.com/api/projects/status/bv3erhc4d2pegpba/branch/master?svg=true)](https://ci.appveyor.com/project/SimonCropp/WaffleGenerator)
[![NuGet Status](https://img.shields.io/nuget/v/WaffleGenerator.svg?label=WaffleGenerator&cacheSeconds=86400)](https://www.nuget.org/packages/WaffleGenerator/)
[![NuGet Status](https://img.shields.io/nuget/v/WaffleGenerator.Bogus.svg?label=WaffleGenerator.Bogus&cacheSeconds=86400)](https://www.nuget.org/packages/WaffleGenerator.Bogus/)

Produces text which, on first glance, looks like real, ponderous, prose; replete with clichés.

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

Support is available via a [Tidelift Subscription](https://tidelift.com/subscription/pkg/nuget-wafflegenerator?utm_source=nuget-wafflegenerator&utm_medium=referral&utm_campaign=enterprise).

toc


## Blazor App

The [Blazing Waffles](http://wafflegen.azurewebsites.net/) app allows the generation of waffle text online.

 * Azure Website: http://wafflegen.azurewebsites.net/
 * Source: https://github.com/gbiellem/BlazingWaffles


## Main Package - WaffleGenerator

https://nuget.org/packages/WaffleGenerator/


### Usage

The `WaffleEngine` can be used to produce Html or text:

snippet: htmlUsage

snippet: textUsage

snippet: markdownUsage


## WaffleGenerator.Bogus

Extends [Bogus](https://github.com/bchavez/Bogus) to use WaffleGenerator.

https://nuget.org/packages/WaffleGenerator.Bogus/


### Usage

The entry extension method is `WaffleHtml()` or `WaffleText()` or `WaffleMarkdown()`:

snippet: BogusUsage


## Security contact information

To report a security vulnerability, use the [Tidelift security contact](https://tidelift.com/security). Tidelift will coordinate the fix and disclosure.


## Icon

[Waffle](https://thenounproject.com/term/waffle/836862/) designed by Made by Made from [The Noun Project](https://thenounproject.com/)