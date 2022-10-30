using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
namespace MauiMSAppCenter;

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

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";
        Analytics.TrackEvent("count", new Dictionary<string, string> { { "count", count.ToString() } });
        //Crashes.GenerateTestCrash();
		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

