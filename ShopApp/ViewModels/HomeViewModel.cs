﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ShopApp.Models.Backend.Inmueble;
using ShopApp.Services;
using ShopApp.Views;
using System.Collections.ObjectModel;

namespace ShopApp.ViewModels;

public partial class HomeViewModel : ViewModelGlobal
{
    [ObservableProperty]
    string nombreUsuario;

    [ObservableProperty]
    CategoryResponse categoriaSeleccionada;

    [ObservableProperty]
    ObservableCollection<CategoryResponse> categories;
    [ObservableProperty]
    ObservableCollection<InmuebleResponse> favoriteInmuebles;

    public Command GetDataCommand { get; }

    private readonly InmuebleService _inmuebleService;

    private readonly INavegacionService _navegacionService;

    public HomeViewModel(InmuebleService inmuebleService, INavegacionService navegacionService)
    {
        _inmuebleService = inmuebleService;
        NombreUsuario = Preferences.Get("nombre", string.Empty);
        GetDataCommand = new Command(async () => await LoadDataAsync());
        GetDataCommand.Execute(this);
        _navegacionService = navegacionService;
    }

    public async Task LoadDataAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;
            var listCategories = await _inmuebleService.GetCategories();
            Categories = new ObservableCollection<CategoryResponse>(listCategories);
            var listInmuebles = await _inmuebleService.GetInmueblesFavoritos();
            
            FavoriteInmuebles = new ObservableCollection<InmuebleResponse>(listInmuebles);
            Categories = new ObservableCollection<CategoryResponse>(listCategories);
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


    [RelayCommand]
    async Task CategoryEventSelected()
    {
        var uri = $"{nameof(InmuebleListPage)}?id={CategoriaSeleccionada.Id}";
        await _navegacionService.GoToAsync(uri);
    }


    [RelayCommand]
    async Task TapBusquedaInmuebles()
    {
        var uri = $"{nameof(InmuebleBusquedaPage)}";
        await _navegacionService.GoToAsync(uri);
    }
}

