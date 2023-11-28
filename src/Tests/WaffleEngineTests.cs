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
        return Verify(text);
    }

    [Test]
    public void EndsWith()
    {
        True(new StringBuilder("a").EndsWith('a'));
        True(new StringBuilder("ba").EndsWith('a'));
        True(new StringBuilder("ba").EndsWith('b', 'a'));
        True(new StringBuilder("a ").EndsWith('a'));
        True(new StringBuilder("ba ").EndsWith('a'));
        True(new StringBuilder("ba ").EndsWith('b', 'a'));
        True(new StringBuilder("a	").EndsWith('a'));
        True(new StringBuilder("ba	").EndsWith('a'));
        True(new StringBuilder("ba	").EndsWith('b', 'a'));

        False(new StringBuilder("a").EndsWith('c'));
        False(new StringBuilder("ba").EndsWith('c'));
        False(new StringBuilder("ba").EndsWith('c', 'd'));
        False(new StringBuilder("a ").EndsWith('c'));
        False(new StringBuilder("ba ").EndsWith('c'));
        False(new StringBuilder("ba ").EndsWith('c', 'd'));
        False(new StringBuilder("a	").EndsWith('c'));
        False(new StringBuilder("ba	").EndsWith('c'));
        False(new StringBuilder("ba	").EndsWith('c', 'd'));
        False(new StringBuilder(" ").EndsWith('c'));
        False(new StringBuilder("	").EndsWith('c'));
        False(new StringBuilder("").EndsWith('c'));
        False(new StringBuilder("").EndsWith('c'));
    }

    [Test]
    public void MultiTextShouldNotDuplicate()
    {
        var text1 = WaffleEngine.Text(1, true);
        var text2 = WaffleEngine.Text(1, true);
        AreNotEqual(text1, text2);
    }

    [Test]
    public void MultiHtmlShouldNotDuplicate()
    {
        var text1 = WaffleEngine.Html(1, true, true);
        var text2 = WaffleEngine.Html(1, true, true);
        AreNotEqual(text1, text2);
    }

    [Test]
    public void MultiMarkdownShouldNotDuplicate()
    {
        var text1 = WaffleEngine.Markdown(1, true);
        var text2 = WaffleEngine.Markdown(1, true);
        AreNotEqual(text1, text2);
    }

    [Test]
    public Task MarkdownWaffleSingle()
    {
        var random = new Random(0);
        var text = WaffleEngine.Markdown(random, 1, true);
        return Verify(text, "md");
    }

    [Test]
    public Task Title()
    {
        var random = new Random(0);
        var title = WaffleEngine.Title(random);
        return Verify(title);
    }

    [Test]
    public Task HtmlWaffleSingle()
    {
        var random = new Random(0);
        var html = WaffleEngine.Html(random, 1, true, false);
        return Verify(html);
    }

    [Test]
    public Task HtmlWaffleSingleWithHeadAndBody()
    {
        var random = new Random(0);
        var html = WaffleEngine.Html(random, 1, true, true);
        return Verify(html);
    }

    [Test]
    public Task TextWaffleMultiple()
    {
        var random = new Random(0);
        var text = WaffleEngine.Text(random, 11, true);
        return Verify(text);
    }

    [Test]
    public Task MarkdownWaffleMultiple()
    {
        var random = new Random(0);
        var text = WaffleEngine.Markdown(random, 11, true);
        return Verify(text, "md");
    }

    [Test]
    public Task HtmlWaffleMultiple()
    {
        var random = new Random(0);
        var html = WaffleEngine.Html(random, 11, true, false);
        return Verify(html);
    }

    [Test]
    public Task HtmlWaffleMultipleWithHeadAndBody()
    {
        var random = new Random(0);
        var html = WaffleEngine.Html(random, 11, true, true);
        return Verify(html);
    }

    [Test]
    public Task TextWaffleNoHeading()
    {
        var random = new Random(0);
        var text = WaffleEngine.Text(random, 1, false);
        return Verify(text);
    }

    [Test]
    public Task MarkdownWaffleNoHeading()
    {
        var random = new Random(0);
        var text = WaffleEngine.Markdown(random, 1, false);
        return Verify(text, "md");
    }

    [Test]
    public Task HtmlWaffleNoHeading()
    {
        var random = new Random(0);
        var html = WaffleEngine.Html(random, 1, true, false);
        return Verify(html);
    }

    [Test]
    public Task HtmlWaffleNoHeadingWithHeadAndBody()
    {
        var random = new Random(0);
        var html = WaffleEngine.Html(random, 1, true, true);
        return Verify(html);
    }
}