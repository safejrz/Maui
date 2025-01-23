using CommunityToolkit.Mvvm.ComponentModel;
using ShopApp.DataAccess;
using System.Collections.ObjectModel;

namespace ShopApp.ViewModels
{
    public partial class ClientsViewModel : ViewModelGlobal
    {
        [ObservableProperty]
        ObservableCollection<Client> clients;

        [ObservableProperty]
        Client selectedClient;

        public ClientsViewModel()
        {
            var database = new ShopDbContext();
            Clients = new ObservableCollection<Client>(database.Clients);
        }
    }
}
