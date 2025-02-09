﻿using CommunityToolkit.Mvvm.ComponentModel;
using ShopApp.Models.Backend.Inmueble;
using ShopApp.Services;
using ShopApp.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ShopApp.ViewModels;

public partial class BookmarkViewModel : ViewModelGlobal
{
    [ObservableProperty]
    ObservableCollection<InmuebleResponse> inmuebles;

    [ObservableProperty]
    private InmuebleResponse inmuebleSeleccionado;

    private readonly INavegacionService _navegacionService;

    private readonly InmuebleService _inmuebleService;

    public Command GetInmueblesCommand { get; }

    public BookmarkViewModel(INavegacionService navegacionService, InmuebleService inmuebleService)
    {
        _navegacionService = navegacionService;
        _inmuebleService = inmuebleService;
        GetInmueblesCommand = new Command(async () => await LoadDataAsync());
        PropertyChanged += BookmarkViewModel_PropertyChanged;        
    }

    private async void BookmarkViewModel_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(InmuebleSeleccionado))
        {
            var uri = $"{nameof(InmuebleDetailPage)}?id={inmuebleSeleccionado.Id}";
            await _navegacionService.GoToAsync(uri);
        }
    }

    public async Task LoadDataAsync()
    {
        if (IsBusy)
            return;
        try
        {
            IsBusy = true;
            Inmuebles = new ObservableCollection<InmuebleResponse>(await _inmuebleService.GetBookmarks());
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

