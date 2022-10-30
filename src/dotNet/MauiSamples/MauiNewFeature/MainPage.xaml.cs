using CommunityToolkit.Maui.Views;
using MauiNewFeature.Views;
namespace MauiNewFeature;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        //Android.Manifest.Permission.ReadExternalStorage
        //var result = await FilePicker.Default.PickAsync(new PickOptions
        //{
        //    FileTypes = FilePickerFileType.Images,
        //    PickerTitle = "Pick image please!"
        //});
        //if (result == null) return;
        //var stream=await result.OpenReadAsync();
        //myImage.Source = ImageSource.FromStream(() => stream);

        // popup
        var popup = new PopupSimple();
        popup.Anchor = CounterBtn;
        this.ShowPopup(popup);
    }
}

