namespace CrashRepro;

public partial class App
{
    private readonly AppShell _appShell;

    public App(AppShell appShell)
    {
        _appShell = appShell;
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var window = new Window(_appShell);

        window.Created += (_, _) => { System.Diagnostics.Trace.WriteLine("[TRACE]: Window created"); };

        window.Deactivated += (_, _) => { System.Diagnostics.Trace.WriteLine("[TRACE]: Window deactivated"); };
        window.Stopped += (_, _) => { System.Diagnostics.Trace.WriteLine("[TRACE]: Window stopped"); };

        return window;
    }
}