using ShopApp.DataAccess;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ShopApp.ViewModels;

public class HelpSupportDetailViewModel : BindingUtilityObject
{
    public HelpSupportDetailViewModel()
    {
        var database = new ShopDbContext();
        Products = new ObservableCollection<Product>(database.Products);
        AddCommand = new Command(() =>
        {
            var compra = new ShopCart(ClientID, SelectedProduct.Id, Quantity);
            Compras.Add(compra);
        },
        () => true
        );
    }

    public ICommand AddCommand { get; set; }

    private ObservableCollection<ShopCart> _compras = new ObservableCollection<ShopCart>();

    public ObservableCollection<ShopCart> Compras
    {
        get { return _compras; }
        set
        {
            if (Compras != value)
            {
                _compras = value;
                RaisePropertyChanged();
            }
        }
    }

    private int _clientId;

    public int ClientID
    {
        get { return _clientId; }
        set { _clientId = value; }
    }

    private ObservableCollection<Product> _products;

    public ObservableCollection<Product> Products
    {
        get { return _products; }
        set
        {
            if (_products != value)
            {
                _products = value;
                RaisePropertyChanged();
            }
        }
    }

    private Product _selectedProduct;

    public Product SelectedProduct
    {
        get { return _selectedProduct; }
        set
        {
            if (_selectedProduct != value)
            {
                _selectedProduct = value;
                RaisePropertyChanged();
            }
        }
    }

    private int _quantity;

    public int Quantity
    {
        get { return _quantity; }
        set
        {
            if (_quantity != value)
            {
                _quantity = value;
                RaisePropertyChanged();
            }
        }
    }

}
