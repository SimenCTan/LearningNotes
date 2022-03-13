using BlazorFileAccess.FileOptions;

namespace BlazorFileAccess.Models;

public class DictoryModel
{
    public DictoryModel(FileSystemHandleKind Kind, string Name)
    {
        this.Kind = Kind;
        this.Name = Name;
        Children = new();
    }
    public FileSystemHandleKind Kind { get; set; }
    public string Name { get; set; }
    public ulong Size { get; set; }
    public List<DictoryModel> Children { get; set; }
}

