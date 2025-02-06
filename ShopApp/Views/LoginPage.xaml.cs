

using ShopApp.ViewModels;

namespace ShopApp.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;

        viewModel.Email = "vaxi.drez.social@gmail.com";
        viewModel.Password = "PasswordVxidrez123$";
    }
}