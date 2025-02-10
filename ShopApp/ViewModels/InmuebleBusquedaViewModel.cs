using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShopApp.Models.Backend.Inmueble;
using ShopApp.Services;
using ShopApp.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ShopApp.ViewModels;

public partial class InmuebleBusquedaViewModel : ViewModelGlobal
{
    [ObservableProperty]
    ObservableCollection<InmuebleResponse> inmuebles;

    [ObservableProperty]
    private InmuebleResponse inmuebleSeleccionado;

    [ObservableProperty]
    private string searchText;

    private readonly INavegacionService _navegacionService;

    private readonly InmuebleService _inmuebleService;

    [RelayCommand]
    async Task GetBackEvent()
    {
        await _navegacionService.GoToAsync("..");
    }

    public ICommand EjecutarBusqueda => new Command(async () =>
    {
            var inmueblesList = await _inmuebleService.GetBusquedaInmuebles(SearchText);
            Inmuebles = new ObservableCollection<InmuebleResponse>(inmueblesList);        
    });

    public InmuebleBusquedaViewModel(INavegacionService navegacionService, InmuebleService inmuebleService)
    {
        _navegacionService = navegacionService;
        _inmuebleService = inmuebleService;
        PropertyChanged += InmuebleBusquedaViewModel_PropertyChanged;
    }

    private async void InmuebleBusquedaViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if(e.PropertyName == nameof(InmuebleSeleccionado))
        {
            var uri = $"{nameof(InmuebleDetailPage)}?id={InmuebleSeleccionado.Id}";
            await _navegacionService.GoToAsync(uri);
        }
    }
}
