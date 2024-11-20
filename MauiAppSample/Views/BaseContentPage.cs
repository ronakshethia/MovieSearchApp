using MauiAppSample.ViewModels;

namespace MauiAppSample.Views;

public class BaseContentPage<T> : ContentPage where T : BaseViewModel
{
    readonly T viewModel;

	public BaseContentPage() 
	{
        viewModel = Application.Current.Handler.MauiContext?.Services.GetService<T>();
        this.BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel?.OnAppearing();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        viewModel.OnDisappearing();
    }

    protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
        base.OnNavigatedFrom(args);
        viewModel?.OnNavigatedFrom(args);
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        viewModel?.OnNavigatedTo(args);
    }
}