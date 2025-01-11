using ShopApp.DataAccess;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ShopApp.Views;

public partial class HelpSupportPage : ContentPage
{
    public HelpSupportPage()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var dataObject = Resources["data"] as HelpSupportData;
        dataObject.VisitasPendientes = 30;
    }
}

public class HelpSupportData : BindingUtilityObject
{
    public HelpSupportData()
    {
        var database = new ShopDbContext();
        Clients = new ObservableCollection<Client>(database.Clients);
        PropertyChanged += HelpSupportData_PropertyChanged;
    }

    private async void HelpSupportData_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if(e.PropertyName == nameof(SelectedClient))
        {
            var uri =$"{nameof(HelpSupportDetailPage)}?id={SelectedClient.Id}";
            await Shell.Current.GoToAsync(uri);
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