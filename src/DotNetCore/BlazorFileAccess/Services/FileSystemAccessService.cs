using Microsoft.JSInterop;
using BlazorFileAccess.FileHandlers;

namespace BlazorFileAccess.Services;

public class FileSystemAccessService : IAsyncDisposable
{
    private readonly Lazy<Task<IJSInProcessObjectReference>> moduleTask;
    private readonly IJSRuntime jsRuntime;

    public FileSystemAccessService(IJSRuntime jSRuntime)
    {
        moduleTask = new(() => jSRuntime.InvokeAsync<IJSInProcessObjectReference>("import", "./content/BlazorFileAccess/js/FileAccess.js").AsTask());
        this.jsRuntime = jSRuntime;
    }

    public async Task<IJSInProcessObjectReference> HelperAsync()
    {
        return await moduleTask.Value;
    }

    public async Task<FileSystemHandle>

    public ValueTask DisposeAsync()
    {
        throw new NotImplementedException();
    }
}

