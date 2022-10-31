using Android.Widget;
using MauiNewFeature.NewFolder;

namespace MauiNewFeature.PlatformImplementations;

public class Toaster:IToast
{
    public void MakeToast(string message)
    {
        Toast.MakeText(Platform.CurrentActivity, "Internet I Have!", ToastLength.Long).Show();
    }
}
