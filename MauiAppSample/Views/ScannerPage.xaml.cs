namespace MauiAppSample.Views;

public partial class ScannerPage
{
	public ScannerPage()
	{
		InitializeComponent();
	}

    private void Camera_OnDetected(object sender, BarcodeScanner.Mobile.OnDetectedEventArg e)
    {

    }
}