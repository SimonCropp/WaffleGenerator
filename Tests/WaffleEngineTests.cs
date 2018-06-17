using System;
using System.Diagnostics;
using System.Text;
using ApprovalTests;
using WaffleGenerator;
using Xunit;
using Xunit.Abstractions;

public class WaffleEngineTests
{
    ITestOutputHelper output;

    public WaffleEngineTests(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public void TextWaffleSample()
    {
        var waffleEngine = new WaffleEngine();
        var builder = new StringBuilder();
        waffleEngine.TextWaffle(
            paragraphs: 1,
            includeHeading: true,
            builder);
        Debug.WriteLine(builder.ToString());
    }

    [Fact]
    public void HtmlWaffleSample()
    {
        var waffleEngine = new WaffleEngine();
        var builder = new StringBuilder();
        waffleEngine.HtmlWaffle(
            paragraphs: 1,
            includeHeading: true,
            builder);
        Debug.WriteLine(builder.ToString());
    }

    [Fact]
    public void TextWaffle()
    {
        var random = new Random(0);
        var waffleEngine = new WaffleEngine(random);
        var builder = new StringBuilder();
        waffleEngine.TextWaffle(1,true,builder);
        Approvals.Verify(builder.ToString());
    }

    [Fact]
    public void HtmlWaffle()
    {
        var random = new Random(0);
        var waffleEngine = new WaffleEngine(random);
        var builder = new StringBuilder();
        waffleEngine.HtmlWaffle(1,true,builder);
        Approvals.Verify(builder.ToString());
    }
}