using CommunityToolkit.Mvvm.Input;
using MauiNewFeature.NewFolder;

namespace MauiNewFeature.ViewModels;

public partial class MainViewModel
{
    private readonly IConnectivity _connectivity;
    private readonly IToast toast;
    public MainViewModel(IConnectivity connectivity,IToast toast)
    {
        _connectivity = connectivity;
        this.toast = toast;
    }

    [RelayCommand]
    async Task CheckInternet()
    {
        var accessType = _connectivity.NetworkAccess;
        if (accessType == NetworkAccess.Internet)
        {
            toast.MakeToast("Internet I Have!");

#if WINDOWS
            await Shell.Current.DisplayAlert("You have internet", "Congrats", "Ok");
#endif
        }
        else
        {
            toast.MakeToast("Internet I Have!");
            await Shell.Current.DisplayAlert("Check internet", $"Current status:{accessType}", "Ok");
        }
    }
}
