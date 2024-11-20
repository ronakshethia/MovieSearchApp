using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace MauiAppSample.ViewModels;

public partial class BaseViewModel: ObservableObject
{
    [ObservableProperty]
    private bool isInternetAvailable;
    
	public BaseViewModel()
	{
		WeakReferenceMessenger.Default.RegisterAll(this);
        Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
    }

	void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
	{
		IsInternetAvailable = e.NetworkAccess == NetworkAccess.Internet;
	}

    public virtual void OnAppearing()
	{

	}

	public virtual void OnDisappearing()
	{

	}

	public virtual void OnNavigatedFrom(NavigatedFromEventArgs args)
	{

	}

	public virtual void OnNavigatedTo(NavigatedToEventArgs args)
	{

	}
}