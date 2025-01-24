using ShopApp.ViewModels;

namespace ShopApp.Views;

public partial class HelpSupportDetailsPage : ContentPage
{
    public HelpSupportDetailsPage(HelpSupportDetailsViewModel helpSupportDetailViewModel)
    {
        InitializeComponent();
        BindingContext = helpSupportDetailViewModel;
    }
}

