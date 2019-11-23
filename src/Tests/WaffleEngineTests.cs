using System;
using System.Diagnostics;
using System.Threading.Tasks;
using VerifyXunit;
using WaffleGenerator;
using Xunit;
using Xunit.Abstractions;

public class WaffleEngineTests :
    VerifyBase
{
    [Fact]
    public void TextWaffleSample()
    {
        #region textUsage

        var text = WaffleEngine.Text(
            paragraphs: 1,
            includeHeading: true);
        Debug.WriteLine(text);

        #endregion
    }

    [Fact]
    public void HtmlWaffleSample()
    {
        #region htmlUsage

        var text = WaffleEngine.Html(
            paragraphs: 2,
            includeHeading: true,
            includeHeadAndBody: true);
        Debug.WriteLine(text);

        #endregion
    }

    [Fact]
    public Task TextWaffleSingle()
    {
        var random = new Random(0);
        var text = WaffleEngine.Text(random, 1, true);
        return Verify(text);
    }

    [Fact]
    public Task Title()
    {
        var random = new Random(0);
        var title = WaffleEngine.Title(random);
        return Verify(title);
    }

    [Fact]
    public Task HtmlWaffleSingle()
    {
        var random = new Random(0);
        var html = WaffleEngine.Html(random, 1, true, false);
        return Verify(html);
    }

    [Fact]
    public Task HtmlWaffleSingleWithHeadAndBody()
    {
        var random = new Random(0);
        var html = WaffleEngine.Html(random, 1, true, true);
        return Verify(html);
    }

    [Fact]
    public Task TextWaffleMultiple()
    {
        var random = new Random(0);
        var text = WaffleEngine.Text(random, 11, true);
        return Verify(text);
    }

    [Fact]
    public Task HtmlWaffleMultiple()
    {
        var random = new Random(0);
        var html = WaffleEngine.Html(random, 11, true, false);
        return Verify(html);
    }

    [Fact]
    public Task HtmlWaffleMultipleWithHeadAndBody()
    {
        var random = new Random(0);
        var html = WaffleEngine.Html(random, 11, true, true);
        return Verify(html);
    }

    [Fact]
    public Task TextWaffleNoHeading()
    {
        var random = new Random(0);
        var text = WaffleEngine.Text(random, 1, false);
        return Verify(text);
    }

    [Fact]
    public Task HtmlWaffleNoHeading()
    {
        var random = new Random(0);
        var html = WaffleEngine.Html(random, 1, true, false);
        return Verify(html);
    }

    [Fact]
    public Task HtmlWaffleNoHeadingWithHeadAndBody()
    {
        var random = new Random(0);
        var html = WaffleEngine.Html(random, 1, true, true);
        return Verify(html);
    }

    public WaffleEngineTests(ITestOutputHelper output) :
        base(output)
    {
    }
}