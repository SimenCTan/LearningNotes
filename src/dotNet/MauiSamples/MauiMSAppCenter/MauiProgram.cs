using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
namespace MauiMSAppCenter;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        AppCenter.Start("windowsdesktop=f05a7743-44e7-40f7-89e3-981ac5a1a46f;" +
                "android={Your Android App secret here};" +
                "ios={Your iOS App secret here};" +
                "macos={Your macOS App secret here};",
                typeof(Analytics), typeof(Crashes));

        return builder.Build();
	}
}
