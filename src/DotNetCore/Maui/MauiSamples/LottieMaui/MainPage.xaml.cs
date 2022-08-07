using Sentry;

namespace LottieMaui;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
        
    }

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;
        var sentryId = SentrySdk.CaptureMessage("Hello Sentry");
        if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
        throw new Exception("Hi sentry");
	}
}

