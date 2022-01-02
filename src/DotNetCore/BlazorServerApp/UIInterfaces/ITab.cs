using Microsoft.AspNetCore.Components;

public interface ITab
{
    RenderFragment ChildContent { get; }
}
