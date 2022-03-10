using Microsoft.JSInterop;
using BlazorFileAccess.FileOptions;

namespace BlazorFileAccess.FileHandlers;

public class FileSystemFileHandle : FileSystemHandle
{
    internal FileSystemFileHandle(IJSObjectReference jSReference, IJSInProcessObjectReference helper) : base(jSReference, helper)
    {

    }

    public async Task<FileHandler> GetFileAsync()
    {
        var jsFile = await JSReference.InvokeAsync<IJSObjectReference>("getFile");
        return new FileHandler(jsFile,helper);
    }

    public async Task<FileSystemWritableFileStream> CreateWritableAsync(FileSystemCreateWritableOptions? fileSystemCreateWritableOptions = null)
    {
        IJSObjectReference? jSFileSystemWritableFileStream = await JSReference.InvokeAsync<IJSObjectReference>("createWritable", fileSystemCreateWritableOptions);
        return new FileSystemWritableFileStream(jSFileSystemWritableFileStream);
    }
}

