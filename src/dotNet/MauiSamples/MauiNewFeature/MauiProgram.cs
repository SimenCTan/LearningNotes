using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Markup;
using MauiNewFeature.Pages.Base;
using MauiNewFeature.Pages.Behaviors;
using MauiNewFeature.ViewModels.Base;
using MauiNewFeature.ViewModels.Behaviors;

namespace MauiNewFeature;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseMauiCommunityToolkitMarkup()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        RegisterViewsAndViewModels(builder.Services);
        RegisterEssentials(builder.Services);
        return builder.Build();
    }

    static void RegisterEssentials(this IServiceCollection services)
    {
        services.AddSingleton<IDeviceInfo>(DeviceInfo.Current);
    }

    static void RegisterViewsAndViewModels(in IServiceCollection services)
    {
        // Add Behaviors Pages + ViewModels
        services.AddTransientWithShellRoute<AnimationBehaviorPage, AnimationBehaviorViewModel>();
    }

    static IServiceCollection AddTransientWithShellRoute<TPage, TViewModel>(this IServiceCollection services) where TPage : BasePage<TViewModel>
                                                                                                                where TViewModel : BaseViewModel
    {
        return services.AddTransientWithShellRoute<TPage, TViewModel>(AppShell.GetPageRoute<TViewModel>());
    }
}
