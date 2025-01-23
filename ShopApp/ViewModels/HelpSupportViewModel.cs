using ShopApp.DataAccess;
using ShopApp.Services;
using ShopApp.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ShopApp.ViewModels;

public class HelpSupportViewModel : BindingUtilityObject
{
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
            var uri = $"{nameof(HelpSupportDetailPage)}?id={SelectedClient.Id}"; 
            await _navigationService.GoToAsync(uri);
        }
    }

    private int _visitasPendientes;

    public int VisitasPendientes
    {
        get
        {
            return _visitasPendientes;
        }
        set
        {
            if (_visitasPendientes != value)
            {
                _visitasPendientes = value;
                RaisePropertyChanged();
            }
        }
    }

    private ObservableCollection<Client> _client;

    public ObservableCollection<Client> Clients
    {
        get
        {
            return _client;
        }
        set
        {
            if (_client != value)
            {
                _client = value;
                RaisePropertyChanged();
            }
        }
    }

    private Client _selectedClient;

    public Client SelectedClient
    {
        get { return _selectedClient; }
        set
        {
            if (_selectedClient != value)
                _selectedClient = value;
            RaisePropertyChanged();
        }
    }

}
