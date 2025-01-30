using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShopApp.DataAccess;
using ShopApp.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ShopApp.ViewModels;

public partial class HelpSupportDetailsViewModel : ViewModelGlobal, IQueryAttributable
{
    private readonly IConnectivity _connectivity;

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

    public ICommand AddCommand { get; set; }

    private CompraService _compraService;

    private readonly ShopOutDbContext _outDbContext;

    public HelpSupportDetailsViewModel(IConnectivity connectivity, CompraService compraService, ShopOutDbContext outDbContext)
    {
        var database = new ShopDbContext();
        Products = new ObservableCollection<Product>(database.Products);
        Quantity = Quantity == 0 ? 1 : Quantity;
        if (selectedProduct == null)
        {
            selectedProduct = Products[0];
        }
        AddCommand = new Command(() =>
        {
            var compra = new ShopCart(
                ClientId,
                SelectedProduct.Id,
                Quantity,
                SelectedProduct.Name,
                SelectedProduct.Price,
                SelectedProduct.Price * Quantity
                );
            Compras.Add(compra);
        },
        () => true
        );
        _connectivity = connectivity;
        _compraService = compraService;
        _connectivity.ConnectivityChanged += _connectivity_ConnectivityChanged;
        _outDbContext = outDbContext;
    }

    [RelayCommand(CanExecute = nameof(StatusConnection))]
    private async Task EnviarCompra()
    {
        // Code to send the cart to the backend server
        //var result = await _compraService.EnviarData(Compras);
        //if (result)
        //{
        //    await Shell.Current.DisplayAlert("Mensaje", "Se enviaron las compras al servidor backend", "Aceptar");
        //}

        //Code to save the cart in the local database
        _outDbContext.Database.EnsureCreated();
        foreach (var item in Compras)
        {
            _outDbContext.Compras.Add(new CompraItem(
                item.ClientId,
                item.ProductId,
                item.Quantity,
                item.ProductPrice
                ));
        }

        await _outDbContext.SaveChangesAsync();

        await Shell.Current.DisplayAlert("Mensaje", "Se almacenaron las compras en la base de datos local", "Aceptar");
    }

    private void _connectivity_ConnectivityChanged(object? sender, ConnectivityChangedEventArgs e)
    {
        EnviarCompraCommand.NotifyCanExecuteChanged();
    }

    private bool StatusConnection()
    {
        return _connectivity.NetworkAccess == NetworkAccess.Internet ? true : false;
    }

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
