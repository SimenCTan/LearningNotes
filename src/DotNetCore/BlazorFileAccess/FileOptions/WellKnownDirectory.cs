using System.ComponentModel;
using System.Text.Json.Serialization;

namespace BlazorFileAccess.FileOptions;

[JsonConverter(typeof(EnumDescriptionConverter<WellKnownDirectory>))]
public enum WellKnownDirectory
{
    [Description("documents")]
    Documents,
    [Description("desktop")]
    Desktop,
    [Description("downloads")]
    Downloads,
    [Description("music")]
    Music,
    [Description("pictures")]
    Pictures,
    [Description("videos")]
    Videos,
}

