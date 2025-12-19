using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazingWaffles;

public class ConnectionBase : ComponentBase, IDisposable
{
    [Inject]
    public IJSRuntime JsRuntime { get; set; } = null!;

    [Parameter]
    public RenderFragment Online { get; set; } = null!;

    [Parameter]
    public RenderFragment Offline { get; set; } = null!;

    public bool IsOnline { get; set; }

    [JSInvokable("Connection.StatusChanged")]
    public void OnConnectionStatusChanged(bool isOnline)
    {
        if (IsOnline != isOnline)
        {
            IsOnline = isOnline;
        }

        StateHasChanged();
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        JsRuntime.InvokeVoidAsync("Connection.Initialize", DotNetObjectReference.Create(this));
    }

    public void Dispose() =>
        JsRuntime.InvokeVoidAsync("Connection.Dispose");
}