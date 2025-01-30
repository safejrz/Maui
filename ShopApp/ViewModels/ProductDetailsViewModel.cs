using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using ShopApp.DataAccess;

namespace ShopApp.ViewModels;

public partial class ProductDetailsViewModel : ViewModelGlobal, IQueryAttributable
{
    [ObservableProperty]
    string name;

    [ObservableProperty]
    string description;

    [ObservableProperty]
    decimal price;

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var dbContext = new ShopDbContext();
        var id = int.Parse(query["id"]?.ToString());        
        var product = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

        Name = product.Name;
        Description = product.Description;
        Price = product.Price;        
    }
}
