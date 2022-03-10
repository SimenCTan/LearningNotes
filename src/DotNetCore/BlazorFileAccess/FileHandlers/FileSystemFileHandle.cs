using Microsoft.JSInterop;

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


}

