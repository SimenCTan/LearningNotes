using Microsoft.JSInterop;

namespace BlazorFileAccess.FileHandlers;

public class FileSystemWritableFileStream
{
    public readonly IJSObjectReference JSReference;
    internal FileSystemWritableFileStream(IJSObjectReference jSReference)
    {
        this.JSReference = jSReference;
    }

    public async Task WriteAsync(BlobHandler blobHandler)
    {
        await JSReference.InvokeVoidAsync("write", blobHandler.JSReference);
    }

    public async Task CloseAsync()
    {
        await JSReference.InvokeVoidAsync("close");
    }
}

