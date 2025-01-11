using ShopApp.DataAccess;
using System.ComponentModel;

namespace ShopApp.Views;

public partial class ProductsPage : ContentPage
{
	public ProductsPage()
	{
		InitializeComponent();

        var dbContext = new ShopDbContext();
        Products.ItemsSource = dbContext.Products;
    }
}