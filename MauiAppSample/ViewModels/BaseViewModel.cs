using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using MauiAppSample.Utility;

namespace MauiAppSample.ViewModels;

public partial class BaseViewModel: ObservableObject
{
    [ObservableProperty]
    private bool isInternetAvailable;
    
	public BaseViewModel()
	{
		WeakReferenceMessenger.Default.RegisterAll(this);
		IsInternetAvailable = Connectivity.NetworkAccess == NetworkAccess.Internet;
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

	public async Task DisplayNoInternetView()
	{
		if (!IsInternetAvailable)
		{
			await Shell.Current.GoToAsync(Constants.NavigationRoutes.NoInternet);
		}
    }
}