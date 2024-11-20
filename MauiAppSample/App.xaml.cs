using CommunityToolkit.Mvvm.Messaging;
using MauiAppSample.Messengers;

namespace MauiAppSample;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		MainPage = new AppShell();
	}

    protected override Window CreateWindow(IActivationState activationState)
    {
        Window window = base.CreateWindow(activationState);

        window.Deactivated += (s, e) =>
        {
            // Custom logic
            //var data = new WeakReferenceValueMessage("Some string value");
            //WeakReferenceMessenger.Default.Send<WeakReferenceValueMessage>(data);
        };
        
        return window;
    }
}