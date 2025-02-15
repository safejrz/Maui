﻿using CommunityToolkit.Mvvm.ComponentModel;
using ShopApp.DataAccess;
using ShopApp.Services;
using ShopApp.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace ShopApp.ViewModels;


public partial class HelpSupportViewModel : ViewModelGlobal
{
    [ObservableProperty]
    private int visitasPendientes;

    [ObservableProperty]
    private ObservableCollection<Client> clients;

    [ObservableProperty]
    private Client selectedClient;

    private readonly INavegacionService _navigationService;
    public HelpSupportViewModel(INavegacionService navigationService)
    {
        var database = new ShopDbContext();
        Clients = new ObservableCollection<Client>(database.Clients);
        PropertyChanged += HelpSupportData_PropertyChanged;
        _navigationService = navigationService;
    }

    private async void HelpSupportData_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(SelectedClient))
        {
            var uri = $"{nameof(HelpSupportDetailPage)}?id={SelectedClient.Id}"; 
            await _navigationService.GoToAsync(uri);
        }
    }

    

}


