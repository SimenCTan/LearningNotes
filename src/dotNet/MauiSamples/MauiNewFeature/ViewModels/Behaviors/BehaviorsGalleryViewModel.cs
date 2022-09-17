using CommunityToolkit.Maui.Behaviors;
using MauiNewFeature.Models;
using MauiNewFeature.ViewModels.Base;

namespace MauiNewFeature.ViewModels.Behaviors;

public class BehaviorsGalleryViewModel : BaseGalleryViewModel
{
    public BehaviorsGalleryViewModel()
        : base(new[]
        {
            SectionModel.Create<AnimationBehaviorViewModel>(nameof(AnimationBehavior), "Perform animation when a specified UI element event is triggered")
        })
    {

    }
}
