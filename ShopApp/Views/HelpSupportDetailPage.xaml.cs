using ShopApp.ViewModels;

namespace ShopApp.Views;

public partial class HelpSupportDetailPage : ContentPage
{
    public HelpSupportDetailPage(HelpSupportDetailViewModel helpSupportDetailViewModel)
    {
        InitializeComponent();
        BindingContext = helpSupportDetailViewModel;
    }
}

