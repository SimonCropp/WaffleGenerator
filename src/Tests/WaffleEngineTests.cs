using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
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

        var link = WaffleEngine.Text(
            paragraphs: 1,
            includeHeading: true);
        Debug.WriteLine(link);

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
    public void LinkWaffleSample()
    {
        #region linkUsage

        var text = WaffleEngine.Link(
            countryTopLevel: true,
            pathLength: 2);
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

    [Fact]
    public void LinkNoCountry()
    {
        var link = WaffleEngine.Link(null);
        var uri = new Uri(link);
        var host = uri.Host.Split('.');

        Assert.Equal(3, host.Length);
        Assert.False(Constants.domainsCountry.Contains(host[0]));
    }

    [Fact]
    public void LinkCountrySubDomain()
    {
        var link = WaffleEngine.Link(false);
        var uri = new Uri(link);
        var host = uri.Host.Split('.');

        Assert.Equal(3, host.Length);
        Assert.True(Constants.domainsCountry.Contains(host[0]));
    }

    [Fact]
    public void LinkCountryTopLevelDomain()
    {
        var link = WaffleEngine.Link(true);
        var uri = new Uri(link);
        var host = uri.Host.Split('.');

        Assert.Equal(4, host.Length);
        Assert.False(Constants.domainsCountry.Contains(host[0]));
        Assert.True(Constants.domainsCountry.Contains(host[3]));
    }

    [Fact]
    public void LinkWellFormed()
    {
        var link = WaffleEngine.Link(null, 2);
        var uri = new Uri(link);
        var host = uri.Host.Split('.');
        var path = uri.PathAndQuery.Split('/');

        Assert.True(Constants.schemes.Contains(uri.Scheme));
        Assert.Equal(3, host.Length);
        Assert.True(Constants.domainsSub.Contains(host[0]));
        Assert.True(Constants.domains.Contains(host[1]));
        Assert.True(Constants.domainsTop.Contains(host[2]));
        Assert.Equal(0, path[0].Length);
        Assert.True(Constants.paths.Contains(path[1]));
        Assert.True(Constants.paths.Contains(path[2].Split('.')[0]));
        Assert.True(Constants.extensions.Contains(path[2].Split('.')[1]));
    }

    public WaffleEngineTests(ITestOutputHelper output) :
        base(output)
    {
    }
}