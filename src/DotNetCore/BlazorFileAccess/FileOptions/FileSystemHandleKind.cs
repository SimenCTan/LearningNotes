using System.ComponentModel;
using System.Text.Json.Serialization;

namespace BlazorFileAccess.FileOptions;

[JsonConverter(typeof(EnumDescriptionConverter<FileSystemHandleKind>))]
public enum FileSystemHandleKind
{
    [Description("file")]
    File,
    [Description("directory")]
    Directory,
}

