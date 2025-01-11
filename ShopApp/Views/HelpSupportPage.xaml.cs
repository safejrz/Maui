using ShopApp.DataAccess;
using System.Collections.ObjectModel;

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
}