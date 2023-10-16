using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Markup;
using MauiNewFeature.NewFolder;
using MauiNewFeature.Pages.Base;
using MauiNewFeature.Pages.Behaviors;
using MauiNewFeature.PlatformImplementations;
using MauiNewFeature.ViewModels;
using MauiNewFeature.ViewModels.Base;
using MauiNewFeature.ViewModels.Behaviors;
using Plugin.LocalNotification;
using Plugin.Maui.Audio;

namespace MauiNewFeature;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
#if ANDROID || IOS
            .UseLocalNotification()
#endif
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
        services.AddSingleton<IToast>(e => new Toaster());
        services.AddSingleton<IDeviceInfo>(DeviceInfo.Current);
        services.AddSingleton<IConnectivity>(e => Connectivity.Current);
        services.AddSingleton(AudioManager.Current);
    }

    static void RegisterViewsAndViewModels(in IServiceCollection services)
    {
        services.AddSingleton<MainViewModel>();
        services.AddSingleton<MainPage>();

        // Add Gallery Pages + ViewModels
        services.AddTransient<BehaviorsGalleryPage, BehaviorsGalleryViewModel>();

        // Add Behaviors Pages + ViewModels
        services.AddTransientWithShellRoute<AnimationBehaviorPage, AnimationBehaviorViewModel>();
    }

    static IServiceCollection AddTransientWithShellRoute<TPage, TViewModel>(this IServiceCollection services) where TPage : BasePage<TViewModel>
                                                                                                                where TViewModel : BaseViewModel
    {
        return services.AddTransientWithShellRoute<TPage, TViewModel>(AppShell.GetPageRoute<TViewModel>());
    }
}
