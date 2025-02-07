using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShopApp.DataAccess;
using ShopApp.Services;
using ShopApp.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ShopApp.ViewModels;

public partial class ProductViewModel : ViewModelGlobal
{
    private readonly INavegacionService _navigationService;

    [ObservableProperty]
    ObservableCollection<Product> products;

    [ObservableProperty]
    Product selectedProduct;

    [ObservableProperty]
    bool isRefreshing;

    public ProductViewModel(INavegacionService navigationService)
    {
        this._navigationService = navigationService;
        LoadProductsList();
        PropertyChanged += ProductViewModel_PropertyChanged;
    }

    [RelayCommand]
    private async void Refresh()
    {
        LoadProductsList();
        await Task.Delay(1000);
        IsRefreshing = false;
    }

    private async void ProductViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(SelectedProduct))
        {
            var uri = $"{nameof(ProductDetailsPage)}?id={SelectedProduct.Id}";
            await _navigationService.GoToAsync(uri);
        }
    }

    private void LoadProductsList()
    {
        var database = new ShopDbContext();
        Products = new ObservableCollection<Product>(database.Products);
        database.Dispose();
    }
}
