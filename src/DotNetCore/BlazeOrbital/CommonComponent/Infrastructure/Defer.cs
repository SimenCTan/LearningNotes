using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace CommonComponent.Infrastructure
{
    public class Defer : ComponentBase
    {
        [Parameter]
        public RenderFragment? ChildContent {get;set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.AddContent(0,ChildContent);
        }
    }

}
