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
    private ObservableCollection<User> _users;
    private ObservableCollection<Admin> _admins;

    public ObservableCollection<User> Users
    {
        get => _users;
        set => Set(ref _users, value);
    }

    public ObservableCollection<Admin> Admins
    {
        get => _admins;
        set => Set(ref _admins, value);
    }

    TrendyolDbContext _trendyoulDB = new TrendyolDbContext();
    public SuperAdminViewModel(IMessenger messenger, IDataService dataService, INavigationService navigationService)
    {
        _dataService = dataService;
        _messenger = messenger;
        _navigationService = navigationService;
        Users = new ObservableCollection<User>(_trendyoulDB.User);
        Admins = new ObservableCollection<Admin>(_trendyoulDB.Admin);
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
                _navigationService.NavigateTo<LoginViewModel>();
            });
    }


}

