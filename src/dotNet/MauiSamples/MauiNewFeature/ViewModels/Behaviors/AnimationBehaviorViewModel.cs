using CommunityToolkit.Mvvm.Input;
using MauiNewFeature.ViewModels.Base;
using CommunityToolkit.Maui.Alerts;

namespace MauiNewFeature.ViewModels.Behaviors;

public partial class AnimationBehaviorViewModel : BaseViewModel
{
    [RelayCommand]
    Task OnAnimation() => Snackbar.Make($"{nameof(AnimationCommand)} is triggered.").Show();
}
