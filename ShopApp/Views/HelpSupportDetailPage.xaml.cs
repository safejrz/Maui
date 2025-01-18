using ShopApp.ViewModels;

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
        var clientId = int.Parse(query["id"].ToString());
        (BindingContext as HelpSupportDetailViewModel).ClientID = clientId;
    }
}

