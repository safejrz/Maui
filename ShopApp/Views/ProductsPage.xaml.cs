using ShopApp.DataAccess;
using System.ComponentModel;

namespace ShopApp.Views;

public partial class ProductsPage : ContentPage
{
	public ProductsPage()
	{
		InitializeComponent();

		var dbContext = new ShopDbContext();

		foreach (var product in dbContext.Products)
		{
            container.Children.Add(new Label { Text = product.Name });
        }
    }
}