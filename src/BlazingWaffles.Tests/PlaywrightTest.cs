using Microsoft.Playwright;

public class PlaywrightTest(PlaywrightFixture fixture) :
    IClassFixture<PlaywrightFixture>
{
    IBrowser browser = fixture.Browser;

    [Fact]
    public async Task Page()
    {
        var page = await browser.NewPageAsync();
        var size = page.ViewportSize!;
        size.Height = 768;
        size.Width = 1024;
        await page.GotoAsync("https://localhost:5001");
        await page.WaitForSelectorAsync("#waffle");
        await page.EvaluateAsync(
            """
            () =>
            {
                let dom = document.querySelector('#waffle');
                dom.innerHTML = 'TheWaffle'
            }
            """);
        await Verify(page)
            .ScrubLinesContaining(">Commit<");
    }
}