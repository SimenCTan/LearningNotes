using System.Text.Json.Serialization;

namespace BlazorFileAccess.FileOptions;

public class FileSystemCreateWritableOptions
{
    public FileSystemCreateWritableOptions(bool keepExistingData)
    {
        KeepExistingData = keepExistingData;
    }

    [JsonPropertyName("keepExistingData")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool KeepExistingData { get; set; }
}

