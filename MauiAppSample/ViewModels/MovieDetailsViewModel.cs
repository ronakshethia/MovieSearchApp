using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using MauiAppSample.Messengers;
using MauiAppSample.Models;

namespace MauiAppSample.ViewModels;


[QueryProperty(nameof(Movie), Utility.Constants.NavigationParameterKey.MovieDetail)]
public partial class MovieDetailsViewModel : BaseViewModel, IRecipient<WeakReferenceValueMessage>
{
    [ObservableProperty]
    private MoviesResult movie;

    public override void OnAppearing()
    {
        base.OnAppearing();
        var movie = this.Movie;
    }

    public override void OnDisappearing()
    {
        base.OnDisappearing();
        var movie = this.Movie;
    }

    public void Receive(WeakReferenceValueMessage message)
    {
        var value = message.Value;
    }
}
