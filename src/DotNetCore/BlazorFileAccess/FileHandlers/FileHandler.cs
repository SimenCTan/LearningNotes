using Microsoft.JSInterop;

namespace BlazorFileAccess.FileHandlers;

public class FileHandler : BlobHandler
{
    public FileHandler(IJSObjectReference jSReference, IJSInProcessObjectReference helper) : base(jSReference, helper)
    {
    }

    public string Name => helper.Invoke<string>("getAttribute", JSReference, "name");

    public DateTime LastModified => DateTime.UnixEpoch.AddMilliseconds(helper.Invoke<ulong>("getAttribute", JSReference, "lastModified"));
}

