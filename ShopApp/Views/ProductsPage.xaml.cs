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
            //container.Children.Add(new Label { Text = product.Name });

			var button = new Button { Text = product.Name };
			button.Clicked += async (s, e) =>
			{
				var uri = $"{nameof(ProductDetailPage)}?id={product.Id}";
				await Shell.Current.GoToAsync(uri);
			};

            container.Children.Add(button);
        }
    }
}