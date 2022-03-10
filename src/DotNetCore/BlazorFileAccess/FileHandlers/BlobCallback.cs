using Microsoft.JSInterop;
using System.Text.Json.Serialization;

namespace BlazorFileAccess.FileHandlers;

public class BlobCallback
{
    private IJSObjectReference? blobWrapper;
    private IJSRuntime jSRuntime;
    private IJSInProcessObjectReference helper;

    public BlobCallback(IJSRuntime jSRuntime, IJSInProcessObjectReference helper)
    {
        this.jSRuntime = jSRuntime;
        this.helper = helper;
        objRef = DotNetObjectReference.Create(this);
    }
    public DotNetObjectReference<BlobCallback> objRef { get; init; }

    [JsonIgnore]
    public Action<BlobHandler>? Callback { get; set; }

    [JSInvokable("Callback")]
    public async Task InvokeCallback()
    {
        var jsBlob = await jSRuntime.InvokeAsync<IJSObjectReference>("getAttribute", blobWrapper, "blob");
        var blobHandler = new BlobHandler(jsBlob, helper);
        Callback?.Invoke(blobHandler);
    }

    public async Task ToBlobAsync(IJSObjectReference jsCanvas)
    {
        blobWrapper = await jSRuntime.InvokeAsync<IJSObjectReference>("toBlob", jsCanvas, this);
    }
}

