using CommunityToolkit.Mvvm.Input;
using MauiNewFeature.NewFolder;
using Plugin.LocalNotification;

namespace MauiNewFeature.ViewModels;

public partial class MainViewModel
{
    private readonly IConnectivity _connectivity;
    private readonly IToast toast;
    public MainViewModel(IConnectivity connectivity,IToast toast)
    {
        LocalNotificationCenter.Current.NotificationActionTapped += Current_NotificationActionTapped;
        _connectivity = connectivity;
        this.toast = toast;
    }

    private void Current_NotificationActionTapped(Plugin.LocalNotification.EventArgs.NotificationActionEventArgs e)
    {
        if (e.IsDismissed)
        { }
        else if (e.IsTapped) { }
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

    [RelayCommand]
    void LocalNotify()
    {
        var notifyRequest = new NotificationRequest
        {
            NotificationId = new Random().Next(1000, 9999),
            Title = "Subscribe to my channel",
            Subtitle = "Hello",
            Description = "It's me",
            BadgeNumber = 42,
            Schedule = new NotificationRequestSchedule
            {
                NotifyTime = DateTime.Now.AddSeconds(1),
                NotifyRepeatInterval = TimeSpan.FromDays(1),
            }
        };
        LocalNotificationCenter.Current.Show(notifyRequest);
    }
}
