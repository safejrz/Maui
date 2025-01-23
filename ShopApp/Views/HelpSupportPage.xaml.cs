using ShopApp.ViewModels;

namespace ShopApp.Views;

public partial class HelpSupportPage : ContentPage
{
    public HelpSupportPage(HelpSupportViewModel helpSupportViewModel)
    {
        InitializeComponent();
        BindingContext = helpSupportViewModel;
    }
}

