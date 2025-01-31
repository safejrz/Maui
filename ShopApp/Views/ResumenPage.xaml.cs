using ShopApp.ViewModels;

namespace ShopApp.Views;

public partial class ResumenPage : ContentPage
{
	public ResumenPage(ResumenViewModel resumenViewModel)
	{
		InitializeComponent();
        BindingContext = resumenViewModel;
    }
}