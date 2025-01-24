using CommunityToolkit.Mvvm.ComponentModel;
using ShopApp.DataAccess;
using ShopApp.Services;
using ShopApp.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ShopApp.ViewModels;

public partial class HelpSupportViewModel : ViewModelGlobal
{
    [ObservableProperty]
    private int visitasPendientes;

    [ObservableProperty]
    private ObservableCollection<Client> clients;

    [ObservableProperty]
    private Client selectedClient;

    private readonly INavigationService _navigationService;
    public HelpSupportViewModel(INavigationService navigationService)
    {
        var database = new ShopDbContext();
        Clients = new ObservableCollection<Client>(database.Clients);
        PropertyChanged += HelpSupportData_PropertyChanged;
        _navigationService = navigationService;
    }

    private async void HelpSupportData_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(SelectedClient))
        {
            var uri = $"{nameof(HelpSupportDetailsPage)}?id={SelectedClient.Id}"; 
            await _navigationService.GoToAsync(uri);
        }
    }
}
