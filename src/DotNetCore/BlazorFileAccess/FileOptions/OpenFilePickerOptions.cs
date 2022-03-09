using System.Dynamic;

namespace BlazorFileAccess.FileOptions;

public class OpenFilePickerOptions:FilePickerOptions
{
    public bool Multiple { get; set; }

    internal new ExpandoObject Serializable()
    {
        dynamic res = base.Serializable();
        if (!Multiple)
        {
            res.multiple = Multiple;
        }
        return res;
    }
}

