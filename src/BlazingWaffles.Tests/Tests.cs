using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using TextCopy;
using VerifyTests.Blazor;
using Index = BlazingWaffles.Pages.Index;

#region Tests

public class Tests
{
    [Fact]
    public Task Component()
    {
        var services = new ServiceCollection();
        services.AddSingleton<IJSRuntime>(new MockJSRuntime());
        services.InjectMockClipboard();
        using var provider = services.BuildServiceProvider();
        var target = Render.Component<Index>(
            provider,
            template: new()
            {
                Waffle = "The Waffle",
                Sha = "TheSha"
            });
        return Verify(target);
    }
}

#endregion