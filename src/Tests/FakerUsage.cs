using System.Diagnostics;
using Bogus;
using NUnit.Framework;
// ReSharper disable RedundantArgumentDefaultValue
// ReSharper disable UnusedParameter.Local

[TestFixture]
public class FakerUsage
{
    [Test]
    public void Sample()
    {
        #region BogusUsage
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
        #endregion
    }

    [Test]
    public void Run()
    {
        var faker = new Faker<Target>()
            .RuleFor(u => u.Title, (f, u) => f.WaffleTitle())
            .RuleFor(u => u.Property1, (f, u) => f.WaffleHtml())
            .RuleFor(u => u.Property2, (f, u) => f.WaffleText());

        var target = faker.Generate();
        Trace.WriteLine(target.Title);
        Trace.WriteLine(target.Property1);
        Trace.WriteLine(target.Property2);
        Assert.NotNull(target.Title);
        Assert.IsNotEmpty(target.Title);
        Assert.NotNull(target.Property1);
        Assert.IsNotEmpty(target.Property1);
        Assert.NotNull(target.Property2);
        Assert.IsNotEmpty(target.Property2);
    }

    public class Target
    {
        public string? Property1 { get; set; }
        public string? Property2 { get; set; }
        public string? Property3 { get; set; }
        public string? Property4 { get; set; }
        public string? Title { get; set; }
    }
}