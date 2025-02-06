namespace ShopApp.Views;

public partial class AboutPage : ContentPage
{
	public AboutPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        var accesstoken = Preferences.Get("accesstoken", string.Empty);
        if (string.IsNullOrEmpty(accesstoken))
        {
            var pagename = $"{nameof(LoginPage)}";
            await Shell.Current.GoToAsync(pagename);
        }
    }
}