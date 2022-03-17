namespace FileUpload.Configurations;

public record AzureStorageOption
{
    public string StorageConnectionString { get; set; } = default!;

    public string ContainerName { get; set; } = default!;

    public string Format { get; set; } = default!;
}

