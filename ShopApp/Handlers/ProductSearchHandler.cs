using ShopApp.DataAccess;
using ShopApp.Views;

namespace ShopApp.Handlers;

public class ProductSearchHandler : SearchHandler
{
    ShopDbContext dbContext;

    public ProductSearchHandler()
    {
        dbContext = new ShopDbContext();
    }

    protected override void OnQueryChanged(string oldValue, string newValue)
    {
        if (string.IsNullOrWhiteSpace(newValue))
        {
            ItemsSource = null;
            return;
        }

        var resultados = dbContext.Products
            .Where(p => p.Name.ToLowerInvariant()
                        .Contains(newValue.ToLowerInvariant())).ToList();



        ItemsSource = resultados;

    }



    /*
    protected async override void OnItemSelected(object item)
    {
        var product = item as Product;
        var uri = $"{nameof(ProductDetailPage)}?id={product.Id}";
        Shell.Current.CurrentItem = Shell.Current.CurrentItem.Items[0];
        await Shell.Current.GoToAsync(uri, false);
    }
    */


    protected async override void OnItemSelected(object item)
    {
        await Shell.Current.GoToAsync($"{nameof(ProductDetailsPage)}?id={((Product)item).Id}");
    }
}
