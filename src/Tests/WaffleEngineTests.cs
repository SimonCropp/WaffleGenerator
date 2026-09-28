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
    public async Task EndsWith()
    {
        await Assert.That(new StringBuilder("a").EndsWith('a')).IsTrue();
        await Assert.That(new StringBuilder("ba").EndsWith('a')).IsTrue();
        await Assert.That(new StringBuilder("ba").EndsWith('b', 'a')).IsTrue();
        await Assert.That(new StringBuilder("a ").EndsWith('a')).IsTrue();
        await Assert.That(new StringBuilder("ba ").EndsWith('a')).IsTrue();
        await Assert.That(new StringBuilder("ba ").EndsWith('b', 'a')).IsTrue();
        await Assert.That(new StringBuilder("a	").EndsWith('a')).IsTrue();
        await Assert.That(new StringBuilder("ba	").EndsWith('a')).IsTrue();
        await Assert.That(new StringBuilder("ba	").EndsWith('b', 'a')).IsTrue();

        await Assert.That(new StringBuilder("a").EndsWith('c')).IsFalse();
        await Assert.That(new StringBuilder("ba").EndsWith('c')).IsFalse();
        await Assert.That(new StringBuilder("ba").EndsWith('c', 'd')).IsFalse();
        await Assert.That(new StringBuilder("a ").EndsWith('c')).IsFalse();
        await Assert.That(new StringBuilder("ba ").EndsWith('c')).IsFalse();
        await Assert.That(new StringBuilder("ba ").EndsWith('c', 'd')).IsFalse();
        await Assert.That(new StringBuilder("a	").EndsWith('c')).IsFalse();
        await Assert.That(new StringBuilder("ba	").EndsWith('c')).IsFalse();
        await Assert.That(new StringBuilder("ba	").EndsWith('c', 'd')).IsFalse();
        await Assert.That(new StringBuilder(" ").EndsWith('c')).IsFalse();
        await Assert.That(new StringBuilder("	").EndsWith('c')).IsFalse();
        await Assert.That(new StringBuilder("").EndsWith('c')).IsFalse();
        await Assert.That(new StringBuilder("").EndsWith('c')).IsFalse();
    }

    [Test]
    public async Task MultiTextShouldNotDuplicate()
    {
        var text1 = WaffleEngine.Text(1, true);
        var text2 = WaffleEngine.Text(1, true);
        await Assert.That(text2).IsNotEqualTo(text1);
    }

    [Test]
    public async Task MultiHtmlShouldNotDuplicate()
    {
        var text1 = WaffleEngine.Html(1, true, true);
        var text2 = WaffleEngine.Html(1, true, true);
        await Assert.That(text2).IsNotEqualTo(text1);
    }

    [Test]
    public async Task MultiMarkdownShouldNotDuplicate()
    {
        var text1 = WaffleEngine.Markdown(1, true);
        var text2 = WaffleEngine.Markdown(1, true);
        await Assert.That(text2).IsNotEqualTo(text1);
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