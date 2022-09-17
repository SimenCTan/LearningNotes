using MauiNewFeature.Pages.Base;
using MauiNewFeature.ViewModels.Behaviors;

namespace MauiNewFeature.Pages.Behaviors;

public class BehaviorsGalleryPage : BaseGalleryPage<BehaviorsGalleryViewModel>
{
    public BehaviorsGalleryPage(IDeviceInfo deviceInfo, BehaviorsGalleryViewModel behaviorsGalleryViewModel)
        : base("Behaviors", deviceInfo, behaviorsGalleryViewModel)
    {

    }
}
