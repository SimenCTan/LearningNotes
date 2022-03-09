using AnyOfTypes;
using BlazorFileAccess.FileHandlers;
using System.Dynamic;

namespace BlazorFileAccess.FileOptions;

public class FilePickerOptions
{
    public FilePickerAcceptType[]? Types { get; set; }

    public bool ExcludeAcceptAllOption { get; set; }
    public string? Id { get; set; }

    public AnyOf<WellKnownDirectory, FileSystemHandle> StartIn { get; set; }

    internal ExpandoObject Serializable()
    {
        dynamic res = new ExpandoObject();
        if (Types != null)
        {
            res.types = Types;
        }

        if (!ExcludeAcceptAllOption)
        {
            res.excludeAcceptAlloption = ExcludeAcceptAllOption;
        }

        if (Id != null)
        {
            res.id = Id;
        }
        if (!StartIn.IsUndefined)
        {
            res.startIn = StartIn.CurrentValue;
        }
        return res;
    }
}
