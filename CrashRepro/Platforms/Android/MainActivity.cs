using Android.App;
using Android.Content.PM;
using Android.OS;

namespace CrashRepro;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, Name = "com.CrashRepro.MainActivity",
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode |
                           ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density,
    ScreenOrientation = ScreenOrientation.Portrait)]
public class MainActivity : MauiAppCompatActivity
{
}