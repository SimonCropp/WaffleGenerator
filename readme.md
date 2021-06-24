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


## Blazor App

The [Blazing Waffles](http://wafflegen.azurewebsites.net/) app allows the generation of waffle text online.

 * Azure Website: http://wafflegen.azurewebsites.net/
 * Source: https://github.com/gbiellem/BlazingWaffles


## Main Package - WaffleGenerator

https://nuget.org/packages/WaffleGenerator/


### Usage

The `WaffleEngine` can be used to produce Html, text or Markdown:


#### Html

<!-- snippet: htmlUsage -->
<a id='snippet-htmlusage'></a>
```cs
var text = WaffleEngine.Html(
    paragraphs: 2,
    includeHeading: true,
    includeHeadAndBody: true);
Debug.WriteLine(text);
```
<sup><a href='/src/Tests/WaffleEngineTests.cs#L41-L49' title='Snippet source file'>snippet source</a> | <a href='#snippet-htmlusage' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


#### Text

<!-- snippet: textUsage -->
<a id='snippet-textusage'></a>
```cs
var text = WaffleEngine.Text(
    paragraphs: 1,
    includeHeading: true);
Debug.WriteLine(text);
```
<sup><a href='/src/Tests/WaffleEngineTests.cs#L15-L22' title='Snippet source file'>snippet source</a> | <a href='#snippet-textusage' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


#### Markdown

<!-- snippet: markdownUsage -->
<a id='snippet-markdownusage'></a>
```cs
var markdown = WaffleEngine.Markdown(
    paragraphs: 1,
    includeHeading: true);
Debug.WriteLine(markdown);
```
<sup><a href='/src/Tests/WaffleEngineTests.cs#L28-L35' title='Snippet source file'>snippet source</a> | <a href='#snippet-markdownusage' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


## WaffleGenerator.Bogus

Extends [Bogus](https://github.com/bchavez/Bogus) to use WaffleGenerator.

https://nuget.org/packages/WaffleGenerator.Bogus/


### Usage

The entry extension method is `WaffleHtml()` or `WaffleText()` or `WaffleMarkdown()`:

<!-- snippet: BogusUsage -->
<a id='snippet-bogususage'></a>
```cs
var faker = new Faker<Target>()
    .RuleFor(
        property: u => u.Title,
        setter: (f, u) => f.WaffleTitle())
    .RuleFor(
        property: u => u.Property1,
        setter: (f, u) => f.WaffleHtml())
    .RuleFor(
        property: u => u.Property2,
        setter: (f, u) => f.WaffleHtml(
            paragraphs: 4,
            includeHeading: true))
    .RuleFor(
        property: u => u.Property3,
        setter: (f, u) => f.WaffleText())
    .RuleFor(
        property: u => u.Property4,
        setter: (f, u) => f.WaffleText(
            paragraphs: 4,
            includeHeading: false));

var target = faker.Generate();
Debug.WriteLine(target.Title);
Debug.WriteLine(target.Property1);
Debug.WriteLine(target.Property2);
Debug.WriteLine(target.Property3);
Debug.WriteLine(target.Property4);
```
<sup><a href='/src/Tests/FakerUsage.cs#L13-L41' title='Snippet source file'>snippet source</a> | <a href='#snippet-bogususage' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


## Icon

[Waffle](https://thenounproject.com/term/waffle/836862/) designed by Made by Made from [The Noun Project](https://thenounproject.com/)
