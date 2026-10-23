using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Text;
using WhereIAmPage.Models;
using WhereIAmPage.Services;

namespace WhereIAmPage.ViewModels
{
    public partial class LocationViewModel : ObservableObject
    {
        private readonly IGeoService _geoService;

        public LocationViewModel(IGeoService geoService)
        {
            _geoService = geoService;
        }

        [ObservableProperty]
        private MyLocation currentLocation;

        [ObservableProperty]
        private bool isBusy;

        [ObservableProperty]
        private bool isNotBusy = true;

        [ObservableProperty]
        private bool hasLocation;

        [RelayCommand]
        private async Task GetLocationAsync()
        {
            IsBusy = true;
            IsNotBusy = false;
            HasLocation = false;
            CurrentLocation = null;

            var location = await _geoService.GetCurrentLocationAsync();

            if (location != null)
            {
                CurrentLocation = location;
                HasLocation = true;
            }
            else
            {
                await Shell.Current.DisplayAlertAsync("Ops!", "Não foi possível obter sua localização. Verifique se o GPS está ligado e se as permissões foram concedidas.", "OK");
            }

            IsBusy = false;
            IsNotBusy = true;
        }
    }
}
