using BarcodeScanner.Mobile;
using MauiAppSample.Services;
using MauiAppSample.ViewModels;
using MauiAppSample.Views;

namespace MauiAppSample;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .RegisterServices()
            .RegisterViewModels()
            .RegisterViews()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            }).ConfigureMauiHandlers(handlers =>
            {
                // Add the handlers
                handlers.AddBarcodeScannerHandler();
            }); ;
        return builder.Build();
    }

    public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<IHttpClientService, HttpClientService>();
        mauiAppBuilder.Services.AddTransient<IMovieService, MovieService>();
        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddTransient<SearchMovieViewModel>();
        mauiAppBuilder.Services.AddTransient<MovieDetailsViewModel>();
        mauiAppBuilder.Services.AddTransient<ScannerViewModel>();
        mauiAppBuilder.Services.AddTransient<NoInternetPage>();
        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddTransient<SearchMovieView>();
        mauiAppBuilder.Services.AddTransient<MovieDetailPage>();
        mauiAppBuilder.Services.AddTransient<ScannerPage>();
        mauiAppBuilder.Services.AddTransient<NoInternetViewModel>();
        return mauiAppBuilder;
    }
}

