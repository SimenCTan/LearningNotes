using Microsoft.JSInterop;

namespace BlazorFileAccess.FileHandlers;

public class FileSystemDirectoryHandle : FileSystemHandle
{
    public FileSystemDirectoryHandle(IJSObjectReference jSObjectReference, IJSInProcessObjectReference processObjectReference) : base(jSObjectReference, processObjectReference)
    {
    }

    public async Task<FileSystemHandle[]> ValuesAsync()
    {
        IJSObjectReference? jSValues = await JSReference.InvokeAsync<IJSObjectReference>("values");
        IJSObjectReference? jSEntries = await helper.InvokeAsync<IJSObjectReference>("arrayFrom", jSValues);
        int length = await helper.InvokeAsync<int>("size", jSEntries);
        return await Task.WhenAll(
            Enumerable
                .Range(0, length)
                .Select(async i =>
                    new FileSystemHandle(await jSEntries.InvokeAsync<IJSObjectReference>("at", i), helper)
                )
                .ToArray()
        );
    }


}

