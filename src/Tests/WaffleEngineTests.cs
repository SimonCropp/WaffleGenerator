using System;
using System.Diagnostics;
using System.Threading.Tasks;
using NUnit.Framework;
using VerifyTests;
using VerifyNUnit;
using WaffleGenerator;

[TestFixture]
public class WaffleEngineTests
{
    [Test]
    public void TextWaffleSample()
    {
        #region textUsage

        var text = WaffleEngine.Text(
            paragraphs: 1,
            includeHeading: true);
        Debug.WriteLine(text);

        #endregion
    }

    [Test]
    public void MarkdownWaffleSample()
    {
        #region markdownUsage

        var markdown = WaffleEngine.Markdown(
            paragraphs: 1,
            includeHeading: true);
        Debug.WriteLine(markdown);

        #endregion
    }

    [Test]
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

    [Test]
    public Task TextWaffleSingle()
    {
        var random = new Random(0);
        var text = WaffleEngine.Text(random, 1, true);
        return Verifier.Verify(text);
    }

    [Test]
    public Task MarkdownWaffleSingle()
    {
        var random = new Random(0);
        var text = WaffleEngine.Markdown(random, 1, true);
        var settings = new VerifySettings();
        settings.UseExtension("md");
        return Verifier.Verify(text, settings);
    }

    [Test]
    public Task Title()
    {
        var random = new Random(0);
        var title = WaffleEngine.Title(random);
        return Verifier.Verify(title);
    }

    [Test]
    public Task HtmlWaffleSingle()
    {
        var random = new Random(0);
        var html = WaffleEngine.Html(random, 1, true, false);
        return Verifier.Verify(html);
    }

    [Test]
    public Task HtmlWaffleSingleWithHeadAndBody()
    {
        var random = new Random(0);
        var html = WaffleEngine.Html(random, 1, true, true);
        return Verifier.Verify(html);
    }

    [Test]
    public Task TextWaffleMultiple()
    {
        var random = new Random(0);
        var text = WaffleEngine.Text(random, 11, true);
        return Verifier.Verify(text);
    }

    [Test]
    public Task MarkdownWaffleMultiple()
    {
        var random = new Random(0);
        var text = WaffleEngine.Markdown(random, 11, true);
        var settings = new VerifySettings();
        settings.UseExtension("md");
        return Verifier.Verify(text, settings);
    }

    [Test]
    public Task HtmlWaffleMultiple()
    {
        var random = new Random(0);
        var html = WaffleEngine.Html(random, 11, true, false);
        return Verifier.Verify(html);
    }

    [Test]
    public Task HtmlWaffleMultipleWithHeadAndBody()
    {
        var random = new Random(0);
        var html = WaffleEngine.Html(random, 11, true, true);
        return Verifier.Verify(html);
    }

    [Test]
    public Task TextWaffleNoHeading()
    {
        var random = new Random(0);
        var text = WaffleEngine.Text(random, 1, false);
        return Verifier.Verify(text);
    }

    [Test]
    public Task MarkdownWaffleNoHeading()
    {
        var random = new Random(0);
        var text = WaffleEngine.Markdown(random, 1, false);
        var settings = new VerifySettings();
        settings.UseExtension("md");
        return Verifier.Verify(text, settings);
    }

    [Test]
    public Task HtmlWaffleNoHeading()
    {
        var random = new Random(0);
        var html = WaffleEngine.Html(random, 1, true, false);
        return Verifier.Verify(html);
    }

    [Test]
    public Task HtmlWaffleNoHeadingWithHeadAndBody()
    {
        var random = new Random(0);
        var html = WaffleEngine.Html(random, 1, true, true);
        return Verifier.Verify(html);
    }
}