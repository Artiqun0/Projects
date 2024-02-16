using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendYol.Messages;
using TrendYol.Services.Interfaces;

namespace TrendYol.ViewModels;
    public class HomePageViewModel : ViewModelBase
    {
    private ViewModelBase _currentView;
    public ViewModelBase CurrentView
    {
        get => _currentView;
        set
        {
            Set(ref _currentView, value);
        }
    }

    private readonly INavigationService navigationService;
    private readonly IDataService _dataService;
    private readonly IMessenger _messenger;

    public HomePageViewModel(IMessenger _messenger, INavigationService navigation)
    {

        navigationService = navigation;

        CurrentView = App.Container.GetInstance<RegisterViewModel>();

        _messenger.Register<NavigationMessage>(this, message =>
        {
            CurrentView = message.ViewModelType;
        });
    }

    public RelayCommand GoToAccountInfo
    {
        get => new(() =>
        {
            navigationService.NavigateTo<AccountViewModel>();
        });
    }

    public RelayCommand GoToBalance
    {
        get => new(() =>
        {
            navigationService.NavigateTo<BalanceViewModel>();
        });
    }

    public RelayCommand GoToShop
    {
        get => new(() =>
        {
            navigationService.NavigateTo<ShopViewModel>();
        });
    }
}
    

