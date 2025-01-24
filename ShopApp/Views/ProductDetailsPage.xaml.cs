using ShopApp.ViewModels;

namespace ShopApp.Views;

public partial class ProductDetailsPage : ContentPage
{
    public ProductDetailsPage(ProductDetailsViewModel productDetailsViewModel)
    {
        InitializeComponent();
        BindingContext = productDetailsViewModel;
    }
}