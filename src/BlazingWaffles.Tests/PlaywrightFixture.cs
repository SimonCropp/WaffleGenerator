using System.Diagnostics;
using Microsoft.Playwright;

public class PlaywrightFixture :
    IAsyncLifetime
{
    Process? process;
    IPlaywright? playwright;
    IBrowser? browser;

    public IBrowser Browser => browser!;

    public async Task InitializeAsync()
    {
        StartBlazorApp();

        await StartDriver();
        await WaitForServerReady();
    }

    async Task WaitForServerReady()
    {
        using var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (_, _, _, _) => true
        };
        using var client = new HttpClient(handler);

        for (var i = 0; i < 30; i++)
        {
            try
            {
                var response = await client.GetAsync("https://localhost:5001");
                if (response.IsSuccessStatusCode)
                {
                    return;
                }
            }
            catch
            {
                // Server not ready yet
            }
            await Task.Delay(1000);
        }

        throw new Exception("Server failed to start within 30 seconds");
    }

    void StartBlazorApp()
    {
        var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        var binPath = baseDirectory.Replace(".Tests","");
        var projectDir = Path.GetFullPath(Path.Combine(binPath, "../../"));
        var startInfo = new ProcessStartInfo("dotnet", "run --no-build --no-restore")
        {
            WorkingDirectory = projectDir
        };
        process = Process.Start(startInfo);
    }

    async Task StartDriver()
    {
        playwright = await Playwright.CreateAsync();
        browser = await playwright.Chromium.LaunchAsync();
    }

    public async Task DisposeAsync()
    {
        if (browser is not null)
        {
            await browser.DisposeAsync();
        }

        playwright?.Dispose();

        if (process is not null)
        {
            process.Kill();
            process.Dispose();
        }
    }
}