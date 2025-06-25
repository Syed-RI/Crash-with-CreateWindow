using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;

namespace CrashRepro;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.Services.TryAddSingleton<AppShell>();
        builder.ConfigureLifecycleEvents(ConfigureLifeCycle);

        return builder.Build();
    }

    static void ConfigureLifeCycle(ILifecycleBuilder lcb)
    {
        lcb.AddAndroid(android => android.OnActivityResult((activity, _, _, _) =>
            {
                System.Diagnostics.Trace.WriteLine("[TRACE]: OnActivityResult is called, with activity: " +
                                                   activity?.Class?.Name);
            })
            .OnNewIntent((activity, _) =>
            {
                System.Diagnostics.Trace.WriteLine("[TRACE]: OnNewIntent is called, with activity: " +
                                                   activity?.Class?.Name);
            })
            .OnStart(activity =>
            {
                System.Diagnostics.Trace.WriteLine("[TRACE]: OnStart is called, with activity: " +
                                                   activity?.Class?.Name);
            })
            .OnResume(activity =>
            {
                System.Diagnostics.Trace.WriteLine("[TRACE]: OnResume is called, with activity: " +
                                                   activity?.Class?.Name);
            })
            .OnPostCreate((activity, _) =>
            {
                System.Diagnostics.Trace.WriteLine("[TRACE]: OnPostCreate is called, with activity: " +
                                                   activity?.Class?.Name);
            })
            .OnCreate((activity, _) =>
            {
                System.Diagnostics.Trace.WriteLine("[TRACE]: OnCreate is called, with activity: " +
                                                   activity?.Class?.Name);
            })
            .OnPause(activity =>
            {
                System.Diagnostics.Trace.WriteLine("[TRACE]: OnPause is called, with activity: " +
                                                   activity?.Class?.Name);
            })
            .OnDestroy(activity =>
            {
                System.Diagnostics.Trace.WriteLine("[TRACE]: OnDestroy is called, with activity: " +
                                                   activity?.Class?.Name);
            }));
    }
}