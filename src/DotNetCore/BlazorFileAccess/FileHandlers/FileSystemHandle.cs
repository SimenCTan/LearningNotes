using Microsoft.JSInterop;
using BlazorFileAccess.FileOptions;

namespace BlazorFileAccess.FileHandlers;

public class FileSystemHandle
{
    public readonly IJSObjectReference JSReference;
    public readonly IJSInProcessObjectReference helper;

    public FileSystemHandle(IJSObjectReference jSObjectReference,IJSInProcessObjectReference processObjectReference)
    {
        this.JSReference = jSObjectReference;
        helper = processObjectReference;
    }

    public string Name => helper.Invoke<string>("getAttribute", JSReference, "name");

    public FileSystemHandleKind Kind => helper.Invoke<FileSystemHandleKind>("getAttribute", JSReference, "kind");

    public async Task<bool> IsSameEntryAsync(FileSystemHandle other)
    {
        return await JSReference.InvokeAsync<bool>("isSameEntry", other.JSReference);
    }
}

