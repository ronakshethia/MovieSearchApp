using System;
namespace MauiAppSample.Utility;

public static class Constants
{
	public static class NavigationRoutes
	{
		public const string Home = "//"+ nameof(Home);
        public const string Detail = Home + nameof(Detail);
        public const string Scanner = Home + nameof(Scanner);
        public const string NoInternet = nameof(NoInternet);
    }

	public static class NavigationParameterKey
	{
		public const string MovieDetail = nameof(MovieDetail);
        public const string BarCodeResult = nameof(BarCodeResult);
    }

    public static class ServicesUrl
    {
		public const string BaseUrl = "https://api.themoviedb.org/3/";
    }
}

