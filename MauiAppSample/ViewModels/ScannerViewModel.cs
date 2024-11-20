using BarcodeScanner.Mobile;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MauiAppSample.Messengers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiAppSample.ViewModels
{
    public partial class ScannerViewModel : BaseViewModel
    {
        [ObservableProperty]
        private bool isScanning;

        public ScannerViewModel()
        {
            OnDetectCommand = new RelayCommand<OnDetectedEventArg>(ExecuteOnDetectedCommand);
        }

        private async void ExecuteOnDetectedCommand(OnDetectedEventArg arg)
        {
            var mavParams = new Dictionary<string, string>()
            {
                { Utility.Constants.NavigationParameterKey.BarCodeResult, arg.BarcodeResults.FirstOrDefault().DisplayValue}
            };

            var data = new WeakReferenceValueMessage(arg.BarcodeResults.FirstOrDefault().DisplayValue);
            WeakReferenceMessenger.Default.Send<WeakReferenceValueMessage>(data);

            await Shell.Current.GoToAsync($"..?{mavParams}");

        }

        public override void OnAppearing()
        {
            base.OnAppearing();
            IsScanning = true;
        }

        public override void OnDisappearing()
        {
            base.OnDisappearing();
            IsScanning = false;
        }

        public ICommand OnDetectCommand { get; }
    }
}
