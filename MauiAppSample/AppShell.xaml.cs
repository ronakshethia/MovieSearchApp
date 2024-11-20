using MauiAppSample.Views;

namespace MauiAppSample;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		RegisterRoutes();
	}

	private static void RegisterRoutes()
	{
        Routing.RegisterRoute(Utility.Constants.NavigationRoutes.Detail, typeof(MovieDetailPage));
        Routing.RegisterRoute(Utility.Constants.NavigationRoutes.Home, typeof(SearchMovieView));
        Routing.RegisterRoute(Utility.Constants.NavigationRoutes.Scanner, typeof(ScannerPage));
        Routing.RegisterRoute(Utility.Constants.NavigationRoutes.NoInternet, typeof(NoInternetPage));
    }
}

