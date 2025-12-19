using BlazingWaffles;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TextCopy;

var builder = WebAssemblyHostBuilder.CreateDefault();
builder.Services.InjectClipboard();
builder.RootComponents.Add<App>("app");
builder.RootComponents.Add<HeadOutlet>("head::after");
await builder.Build().RunAsync();