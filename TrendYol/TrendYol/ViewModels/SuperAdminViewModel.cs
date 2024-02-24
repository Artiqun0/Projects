using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendYol.Context;
using TrendYol.Models;
using TrendYol.Services.Interfaces;

namespace TrendYol.ViewModels;
    public class SuperAdminViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;
    private readonly IDataService _dataService;
    private readonly IMessenger _messenger;

    TrendyolDbContext _trendyoulDB = new TrendyolDbContext();
    public SuperAdminViewModel(IMessenger messenger, IDataService dataService, INavigationService navigationService)
    {
        _dataService = dataService;
        _messenger = messenger;
        _navigationService = navigationService;
    }

    public RelayCommand CreateUser
    {
        get => new(() =>
        {
            _navigationService.NavigateTo<CreateUserViewModel>();
        });
    }

    public RelayCommand CreateAdmin
    {
        get => new(
            () =>
            {
                _navigationService.NavigateTo<CreateAdminViewModel>();
            });
    }

    public RelayCommand Quit
    {
        get => new(
            () =>
            {
                App.Current.Shutdown();
            });
    }


}

