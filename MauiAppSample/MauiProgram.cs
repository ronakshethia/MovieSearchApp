using System.Net;
using BarcodeScanner.Mobile;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Markup;
using MauiAppSample.Services;
using MauiAppSample.ViewModels;
using MauiAppSample.Views;
using Microsoft.Extensions.Http.Resilience;
using Polly;

namespace MauiAppSample;

public static partial class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        //var graphQLUri = new Uri("http://192.168.176.1:5001/graphql/");
        //var graphQLUri = new Uri("http://localhost:5001/graphql/");
        var graphQLUri = new Uri("http://192.168.100.142:5000/graphql/");

        var builder = MauiApp.CreateBuilder()
                        .UseMauiApp<App>()
                        .UseMauiCommunityToolkit()
                        .UseMauiCommunityToolkitMarkup()
                        .RegisterServices()
            .RegisterViewModels()
            .RegisterViews()
                        .ConfigureFonts(fonts =>
                        {
                            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                        })
                        .ConfigureMauiHandlers(handlers =>
                        {
                            // Add the handlers
                            handlers.AddBarcodeScannerHandler();
                        });

        // Add Services
        builder.Services.AddSingleton<GraphQLService>();

        builder.Services.AddMauiAppSampleClient()
                        .ConfigureHttpClient(client => client.BaseAddress = graphQLUri,
                                                clientBuilder => clientBuilder.ConfigurePrimaryHttpMessageHandler(GetHttpMessageHandler)
                                                    .AddStandardResilienceHandler(options => options.Retry = new MobileHttpRetryStrategyOptions()));
                        //.ConfigureWebSocketClient(client => client.Uri = GetGraphQLStreamingUri(graphQLUri));

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
    static DecompressionMethods GetDecompressionMethods() => DecompressionMethods.Deflate | DecompressionMethods.GZip;

    private static partial Uri GetGraphQLUri(in Uri uri);
    private static partial Uri GetGraphQLStreamingUri(in Uri uri);
    private static partial HttpMessageHandler GetHttpMessageHandler();

    sealed class MobileHttpRetryStrategyOptions : HttpRetryStrategyOptions
    {
        public MobileHttpRetryStrategyOptions()
        {
            BackoffType = DelayBackoffType.Exponential;
            MaxRetryAttempts = 3;
            UseJitter = true;
            Delay = TimeSpan.FromSeconds(2);
        }
    }
}

