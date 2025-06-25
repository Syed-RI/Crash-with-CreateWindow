using Android.App;
using Android.Content.PM;
using Android.OS;

namespace MauiApp1;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, Name = "com.MauiApp1.MainActivity",
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode |
                           ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density,
    ScreenOrientation = ScreenOrientation.Portrait)]
public class MainActivity : MauiAppCompatActivity
{
}