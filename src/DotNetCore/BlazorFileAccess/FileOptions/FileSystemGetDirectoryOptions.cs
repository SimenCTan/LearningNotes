using System.Text.Json.Serialization;

namespace BlazorFileAccess.FileOptions;

public class FileSystemGetDirectoryOptions
{
    [JsonPropertyName("create")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool Create { get; set; }
}

