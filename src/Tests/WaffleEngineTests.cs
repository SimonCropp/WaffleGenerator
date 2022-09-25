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
        Random random = new(0);
        var text = WaffleEngine.Text(random, 1, true);
        return Verify(text);
    }

    [Test]
    public void EndsWith()
    {
        Assert.True(new StringBuilder("a").EndsWith('a'));
        Assert.True(new StringBuilder("ba").EndsWith('a'));
        Assert.True(new StringBuilder("ba").EndsWith('b', 'a'));
        Assert.True(new StringBuilder("a ").EndsWith('a'));
        Assert.True(new StringBuilder("ba ").EndsWith('a'));
        Assert.True(new StringBuilder("ba ").EndsWith('b', 'a'));
        Assert.True(new StringBuilder("a	").EndsWith('a'));
        Assert.True(new StringBuilder("ba	").EndsWith('a'));
        Assert.True(new StringBuilder("ba	").EndsWith('b', 'a'));

        Assert.False(new StringBuilder("a").EndsWith('c'));
        Assert.False(new StringBuilder("ba").EndsWith('c'));
        Assert.False(new StringBuilder("ba").EndsWith('c', 'd'));
        Assert.False(new StringBuilder("a ").EndsWith('c'));
        Assert.False(new StringBuilder("ba ").EndsWith('c'));
        Assert.False(new StringBuilder("ba ").EndsWith('c', 'd'));
        Assert.False(new StringBuilder("a	").EndsWith('c'));
        Assert.False(new StringBuilder("ba	").EndsWith('c'));
        Assert.False(new StringBuilder("ba	").EndsWith('c', 'd'));
        Assert.False(new StringBuilder(" ").EndsWith('c'));
        Assert.False(new StringBuilder("	").EndsWith('c'));
        Assert.False(new StringBuilder("").EndsWith('c'));
        Assert.False(new StringBuilder("").EndsWith('c'));
    }

    [Test]
    public void MultiTextShouldNotDuplicate()
    {
        var text1 = WaffleEngine.Text(1, true);
        var text2 = WaffleEngine.Text(1, true);
        Assert.AreNotEqual(text1, text2);
    }

    [Test]
    public void MultiHtmlShouldNotDuplicate()
    {
        var text1 = WaffleEngine.Html(1, true, true);
        var text2 = WaffleEngine.Html(1, true, true);
        Assert.AreNotEqual(text1, text2);
    }

    [Test]
    public void MultiMarkdownShouldNotDuplicate()
    {
        var text1 = WaffleEngine.Markdown(1, true);
        var text2 = WaffleEngine.Markdown(1, true);
        Assert.AreNotEqual(text1, text2);
    }

    [Test]
    public Task MarkdownWaffleSingle()
    {
        Random random = new(0);
        var text = WaffleEngine.Markdown(random, 1, true);
        return Verify(text, "md");
    }

    [Test]
    public Task Title()
    {
        Random random = new(0);
        var title = WaffleEngine.Title(random);
        return Verify(title);
    }

    [Test]
    public Task HtmlWaffleSingle()
    {
        Random random = new(0);
        var html = WaffleEngine.Html(random, 1, true, false);
        return Verify(html);
    }

    [Test]
    public Task HtmlWaffleSingleWithHeadAndBody()
    {
        Random random = new(0);
        var html = WaffleEngine.Html(random, 1, true, true);
        return Verify(html);
    }

    [Test]
    public Task TextWaffleMultiple()
    {
        Random random = new(0);
        var text = WaffleEngine.Text(random, 11, true);
        return Verify(text);
    }

    [Test]
    public Task MarkdownWaffleMultiple()
    {
        Random random = new(0);
        var text = WaffleEngine.Markdown(random, 11, true);
        return Verify(text, "md");
    }

    [Test]
    public Task HtmlWaffleMultiple()
    {
        Random random = new(0);
        var html = WaffleEngine.Html(random, 11, true, false);
        return Verify(html);
    }

    [Test]
    public Task HtmlWaffleMultipleWithHeadAndBody()
    {
        Random random = new(0);
        var html = WaffleEngine.Html(random, 11, true, true);
        return Verify(html);
    }

    [Test]
    public Task TextWaffleNoHeading()
    {
        Random random = new(0);
        var text = WaffleEngine.Text(random, 1, false);
        return Verify(text);
    }

    [Test]
    public Task MarkdownWaffleNoHeading()
    {
        Random random = new(0);
        var text = WaffleEngine.Markdown(random, 1, false);
        return Verify(text, "md");
    }

    [Test]
    public Task HtmlWaffleNoHeading()
    {
        Random random = new(0);
        var html = WaffleEngine.Html(random, 1, true, false);
        return Verify(html);
    }

    [Test]
    public Task HtmlWaffleNoHeadingWithHeadAndBody()
    {
        Random random = new(0);
        var html = WaffleEngine.Html(random, 1, true, true);
        return Verify(html);
    }
}