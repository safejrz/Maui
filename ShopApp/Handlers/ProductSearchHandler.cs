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
        if (string.IsNullOrEmpty(newValue))
        {
            ItemsSource = null;
            return;
        }

        ItemsSource = dbContext.Products
            .Where(p => p.Name.ToLowerInvariant()
                .Contains(newValue.ToLowerInvariant()));
    }

    protected async override void OnItemSelected(object item)
    {
        await Shell.Current.GoToAsync($"{nameof(ProductDetailPage)}?id={((Product)item).Id}");
    }
}
