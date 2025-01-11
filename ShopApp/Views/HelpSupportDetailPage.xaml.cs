
using ShopApp.DataAccess;
using System.Collections.ObjectModel;

namespace ShopApp.Views;

public partial class HelpSupportDetailPage : ContentPage, IQueryAttributable
{
    public HelpSupportDetailPage()
    {
        InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Title = $"Client: {query["id"]}";
    }
}

public class HelpSupportDetailData : BindingUtilityObject
{
    public HelpSupportDetailData()
    {
        var database = new ShopDbContext();
        Products = new ObservableCollection<Product>(database.Products);
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