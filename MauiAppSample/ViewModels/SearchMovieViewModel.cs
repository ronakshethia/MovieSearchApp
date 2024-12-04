using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MauiAppSample.Messengers;
using MauiAppSample.Models;
using MauiAppSample.Services;
using MauiAppSample.Utility;
//using MauiAppSampleApi;
using Microsoft.Extensions.DependencyInjection;
using StrawberryShake;
using System.Collections.Generic;
using System.Diagnostics;

namespace MauiAppSample.ViewModels;

//[QueryProperty(nameof(BarcodeResult), Utility.Constants.NavigationParameterKey.BarCodeResult)]
public partial class SearchMovieViewModel : BaseViewModel, IRecipient<WeakReferenceValueMessage>
{
    #region PROPERTIES 

    [ObservableProperty]
    private string barcodeResult;

    [ObservableProperty]
    private ObservableRangeCollection<MoviesResult> movies;

    [ObservableProperty]
    private string searchText;

    [ObservableProperty]
    private bool isLoadingMoreMovies;

    [ObservableProperty]
    private bool isSearchingMovies;

    [ObservableProperty]
    private bool hasSearched;

    #endregion

    #region INTERNALS

    internal int _currentPage = 1;

    internal bool _hasMoreItems = true;

    #endregion

    #region CONSTRUCTORS


    public SearchMovieViewModel(IMovieService movieService)
    {
        _movieService = movieService;
        Movies = new ObservableRangeCollection<MoviesResult>();
    }

    #endregion

    #region READONLYS

    private readonly IMovieService _movieService;

    #endregion

    #region COMMANDS

    [RelayCommand]
    public async Task SearchMovies()
    {

        return;

        await DisplayNoInternetView();

        HasSearched = false;

        IsLoadingMoreMovies = false;

        if (string.IsNullOrWhiteSpace(SearchText))
        {
            Movies.Clear();
            return;
        }
        //TODO ADD GOOD LOGIC FOR LOADING 
        Movies.Clear();
        IsSearchingMovies = true;

        try
        {
            var result = await _movieService.SearchMoviesAsync(SearchText);
            IsSearchingMovies = false;

            if (result?.Any() == true)
            {
                Movies = new ObservableRangeCollection<MoviesResult>(result);
            }
            else
            {
                HasSearched = true;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error while searching for movies: {ex.Message}");
        }
    }

    [RelayCommand]
    private async Task RequestMoreMovies()
    {

        return;
        await DisplayNoInternetView();

        IsLoadingMoreMovies = true;
        var newItems = await _movieService.SearchMoviesAsync(SearchText,_currentPage);
        //TODO - Revisit this code for improvement
        if (newItems.Any())
        {
            foreach (var item in newItems)
            {
                Movies.Add(item);
            }
            _currentPage++;
        }
        else
        {
            _hasMoreItems = false;
        }

        IsLoadingMoreMovies = false;
    }

    [RelayCommand]
    public async Task ScanQR()
    {
        //try
        //{

        // var graphQLUri = new Uri("http://192.168.176.1:5000/graphql/");

        // IServiceCollection serviceDescriptors = new ServiceCollection();
        // serviceDescriptors.AddMauiAppSampleClient().ConfigureHttpClient(c=> c.BaseAddress = graphQLUri);

        //IServiceProvider serviceProvider = serviceDescriptors.BuildServiceProvider();

        // IMauiAppSampleClient getAllAppMasters_AllAppMenus = serviceProvider.GetRequiredService<IMauiAppSampleClient>();

        // var result = await getAllAppMasters_AllAppMenus.GetAllAppMasters.ExecuteAsync();

        // if (result.IsErrorResult())
        // {

        // }
        // else
        // {
        //     var res = result.Data;
        // }

        // }
        // catch (Exception ex)
        // {

        // }

        var services = Application.Current.Handler.MauiContext?.Services.GetService<GraphQLService>();

        var appMenu = await services.GetAppMenusAsync();
        var listA = appMenu.AppMenuItems;

        var AppMasters =  await services.GetAppsAllMastersAsync();
        var list1 = AppMasters.TicketStatusList;
        var list2 = AppMasters.ProductRepairStatusList;
        var list3 = AppMasters.ProductTypesList;


        var customerDetails = await services.GetCustomerDetailsByPhoneNumber("9870897390");


        //bool allowed = await BarcodeScanner.Mobile.Methods.AskForRequiredPermission();
        //if (allowed)
        //{
        //    await Shell.Current.GoToAsync(Constants.NavigationRoutes.Scanner);
        //}
    }

    [RelayCommand]
    private async Task SelectedMovieChanged(MoviesResult movie)
    {
        var mavParams = new Dictionary<string, object>()
        {
            { Constants.NavigationParameterKey.MovieDetail, movie}
        };
        await Shell.Current.GoToAsync(Constants.NavigationRoutes.Detail, mavParams);
    }

    #endregion

    public void Receive(WeakReferenceValueMessage message)
    {
        var value = message.Value;
        SearchText= value.ToString();
        SearchMoviesCommand.Execute(null);
    }

    #region OVERRIDES

    public override void OnAppearing()
    {
        //var services = Application.Current.Handler.MauiContext?.Services.GetService<GraphQLService>();
        //var ee = services.GetAllMasters();
    }
    public override void OnDisappearing()
    {
        base.OnDisappearing();
    }

    #endregion
}
