using ShopApp.DataAccess;
using ShopApp.ViewModels;
using System.ComponentModel;

namespace ShopApp.Views;

public partial class ProductsPage : ContentPage
{
    public ProductsPage(ProductViewModel viewModel)
    {
 	InitializeComponent();
		BindingContext= viewModel;
    }
}