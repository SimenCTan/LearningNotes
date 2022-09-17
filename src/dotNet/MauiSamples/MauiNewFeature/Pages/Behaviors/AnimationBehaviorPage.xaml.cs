using CommunityToolkit.Maui.Animations;
using MauiNewFeature.Pages.Base;
using MauiNewFeature.ViewModels.Behaviors;

namespace MauiNewFeature.Pages.Behaviors;

public partial class AnimationBehaviorPage : BasePage<AnimationBehaviorViewModel>
{
    public AnimationBehaviorPage(AnimationBehaviorViewModel animationBehaviorViewModel) : base(animationBehaviorViewModel)
    {
        InitializeComponent();
    }
}

class SampleScaleAnimation : BaseAnimation
{
    public override async Task Animate(VisualElement view)
    {
        await view.ScaleTo(1.2, Length, Easing);
        await view.ScaleTo(1, Length, Easing);
    }
}
