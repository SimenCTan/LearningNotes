using System;
using System.Collections.Generic;

public class ComponentMetadata
{
    public string Name { get; set; } = default!;
    public Dictionary<string, object>? Parameters { get; set; }
}
