using ShopApp.DataAccess;
using ShopApp.ViewModels;

namespace ShopApp.Views;

public partial class ClientsPage : ContentPage
{
    public ClientsPage(ClientsViewModel clientsViewModel)
    {
        InitializeComponent();

        BindingContext = clientsViewModel;
    }
}