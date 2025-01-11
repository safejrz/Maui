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
}