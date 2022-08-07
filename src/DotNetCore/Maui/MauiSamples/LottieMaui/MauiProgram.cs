using SkiaSharp.Views.Maui.Controls.Hosting;
namespace LottieMaui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseSkiaSharp()
            .UseSentry(option =>
            {
                option.Dsn = "https://2a60899887ef420485bb8c1a85636f64@o1349834.ingest.sentry.io/6629605";
                option.Debug = true;
                option.TracesSampleRate = 1.0;
            })
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		return builder.Build();
	}
}
