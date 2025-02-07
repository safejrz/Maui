using CommunityToolkit.Mvvm.ComponentModel;
using ShopApp.Models.Backend.Inmueble;
using ShopApp.Services;
using System.Collections.ObjectModel;

namespace ShopApp.ViewModels;

public partial class InmuebleListViewModel : ViewModelGlobal, IQueryAttributable
{
    private readonly INavegacionService _navigationService;

    [ObservableProperty]
    private ObservableCollection<InmuebleResponse> inmuebles;

    private readonly InmuebleService _inmuebleService;

    public InmuebleListViewModel(INavegacionService navigationService, InmuebleService inmuebleService)
    {
        _navigationService = navigationService;
        _inmuebleService = inmuebleService;
    }

    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var id = int.Parse(query["id"].ToString());
        await LoadDataAsync(id);
    }

    public async Task LoadDataAsync(int categoryId)
    {
        if (IsBusy)
            return;
        try
        {
            IsBusy = true;
            var listInmuebles = await _inmuebleService.GetInmueblesByCategory(categoryId);
            Inmuebles = new ObservableCollection<InmuebleResponse>(listInmuebles);
        }
        catch (Exception e)
        {
            await Application.Current.MainPage.DisplayAlert("Error", e.Message, "Aceptar");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
