using Microsoft.JSInterop;
using BlazorFileAccess.FileHandlers;
using BlazorFileAccess.FileOptions;

namespace BlazorFileAccess.Services;

public class FileSystemAccessService : IAsyncDisposable
{
    private readonly Lazy<Task<IJSInProcessObjectReference>> moduleTask;
    private readonly IJSRuntime jsRuntime;

    public FileSystemAccessService(IJSRuntime jSRuntime)
    {
        moduleTask = new(() => jSRuntime.InvokeAsync<IJSInProcessObjectReference>("import", "./js/fileAccess.js").AsTask());
        this.jsRuntime = jSRuntime;
    }

    public async Task<IJSInProcessObjectReference> HelperAsync()
    {
        return await moduleTask.Value;
    }

    public async Task<FileSystemFileHandle[]> ShowOpenFilePickerAsync(OpenFilePickerOptions? openFilePickerOptions = null)
    {
        IJSInProcessObjectReference helper = await moduleTask.Value;
        IJSObjectReference jSFileHandles = await jsRuntime.InvokeAsync<IJSObjectReference>("window.showOpenFilePicker",
            openFilePickerOptions?.Serializable());
        var length = await helper.InvokeAsync<int>("size", jSFileHandles);
        return await Task
            .WhenAll(Enumerable.Range(0, length)
            .Select(async i => new FileSystemFileHandle
            (await jSFileHandles.InvokeAsync<IJSObjectReference>("at", i), helper)
            ).ToArray());
    }

    public async Task<FileSystemFileHandle> ShowSaveFilePickerAsync(SaveFilePickerOptions? saveFilePickerOptions = null)
    {
        IJSInProcessObjectReference? helper = await moduleTask.Value;
        IJSObjectReference? jSFileHandle = await jsRuntime.InvokeAsync<IJSObjectReference>("window.showSaveFilePicker",
            saveFilePickerOptions?.Serializable());
        return new FileSystemFileHandle(jSFileHandle, helper);
    }

    public async ValueTask DisposeAsync()
    {
        if (moduleTask.IsValueCreated)
        {
            IJSInProcessObjectReference? module = await moduleTask.Value;
            await module.DisposeAsync();
        }
        GC.SuppressFinalize(this);
    }
}

