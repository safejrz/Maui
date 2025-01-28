using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShopApp.DataAccess;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ShopApp.ViewModels;

public partial class HelpSupportDetailsViewModel : ViewModelGlobal, IQueryAttributable
{
    [ObservableProperty]
    private ObservableCollection<ShopCart> _compras = new ObservableCollection<ShopCart>();

    [ObservableProperty]
    private int clientId;

    [ObservableProperty]
    private ObservableCollection<Product> products;

    [ObservableProperty]
    private Product selectedProduct;

    [ObservableProperty]
    private int quantity;

    public HelpSupportDetailsViewModel()
    {
        var database = new ShopDbContext();
        Products = new ObservableCollection<Product>(database.Products);
        AddCommand = new Command(() =>
        {
            var compra = new ShopCart(ClientId, SelectedProduct.Id, Quantity,
                SelectedProduct.Name,
                SelectedProduct.Price,
                SelectedProduct.Price * Quantity
                );
            Compras.Add(compra);
        },
        () => true
        );
    }

    public ICommand AddCommand { get; set; }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var clientId = int.Parse(query["id"].ToString());
        ClientId = clientId;
    }

    [RelayCommand]
    private void DeleteShopCart(ShopCart shopCart)
    {
        Compras.Remove(shopCart);
    }
}
