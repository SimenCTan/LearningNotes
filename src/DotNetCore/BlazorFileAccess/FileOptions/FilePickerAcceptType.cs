using System.Text.Json.Serialization;

namespace BlazorFileAccess.FileOptions;

public class FilePickerAcceptType
{
    [JsonPropertyName("description")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Description { get; set; }

    [JsonPropertyName("accept")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string,string[]>? Accept { get; set; }
}

