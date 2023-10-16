using CommunityToolkit.Mvvm.Input;
using MauiNewFeature.NewFolder;
using Plugin.LocalNotification;
using Plugin.Maui.Audio;

namespace MauiNewFeature.ViewModels;

public partial class MainViewModel
{
    private readonly IConnectivity _connectivity;
    private readonly IToast toast;
    readonly IAudioManager _audioManager;
    readonly IAudioRecorder _audioRecorder;
    public MainViewModel(IConnectivity connectivity,IToast toast,IAudioManager audioManager)
    {
#if ANDROID || IOS
        LocalNotificationCenter.Current.NotificationActionTapped += Current_NotificationActionTapped;
#endif
        _connectivity = connectivity;
        this.toast = toast;
        _audioManager = audioManager;
        _audioRecorder = _audioManager.CreateRecorder();
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

    [RelayCommand]
    async Task AudioTest()
    {
        if (await Permissions.RequestAsync<Permissions.Microphone>() != PermissionStatus.Granted)
        {
            return;
        }
        if (!_audioRecorder.IsRecording)
        {
            await _audioRecorder.StartAsync();
        }
        else
        {
            var recordAudio = await _audioRecorder.StopAsync();
            var player = AudioManager.Current.CreatePlayer(recordAudio.GetAudioStream());
            player.Play();
        }
    }
}
