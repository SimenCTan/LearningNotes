using Microsoft.Maui.LifecycleEvents;

namespace MauiDoc.XamlSample
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                })
                .ConfigureLifecycleEvents(events => {
#if ANDROID
                    events.AddAndroid(android => android.OnActivityResult((activity, requestCode, resultCode, data) => LogEvent("OnActivityResult", requestCode.ToString()))
                    .OnStart(activity => LogEvent("OnStart"))
                    .OnCreate((activity, bundle) => LogEvent("OnCreate"))
                    .OnStop((activity) => LogEvent("OnStop"))
                    );
#elif IOS
                    events.AddiOS(ios => ios
                        .OnActivated((app) => LogEvent("OnActivated"))
                        .OnResignActivation((app) => LogEvent("OnResignActivation"))
                        .DidEnterBackground((app) => LogEvent("DidEnterBackground"))
                        .WillTerminate((app) => LogEvent("WillTerminate")));
#endif
                    static void LogEvent(string eventName, string type = null)
                    {
                        System.Diagnostics.Debug.WriteLine($"Lifecycle event: {eventName}{(type == null ? string.Empty : $" ({type})")}");
                    }
                });

            return builder.Build();
        }
    }
}