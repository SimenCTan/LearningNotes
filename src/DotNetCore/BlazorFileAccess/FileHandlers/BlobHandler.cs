﻿using Microsoft.JSInterop;

namespace BlazorFileAccess.FileHandlers;

public class BlobHandler
{
    public readonly IJSObjectReference JSReference;
    protected readonly IJSInProcessObjectReference helper;

    public BlobHandler(IJSObjectReference jSReference, IJSInProcessObjectReference helper)
    {
        this.JSReference = jSReference;
        this.helper = helper;
    }

    public ulong Size => helper.Invoke<ulong>("getAttribute", JSReference, "size");

    public string Type => helper.Invoke<string>("getAttribute", JSReference, "type");

    public async Task<string> TextAsync()
    {
        return await JSReference.InvokeAsync<string>("text");
    }
}

