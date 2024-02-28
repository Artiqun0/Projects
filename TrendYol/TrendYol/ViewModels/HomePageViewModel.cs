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
using System.Windows;
using TrendYol.Views;
using MaterialDesignThemes.Wpf;
using System.Collections.ObjectModel;
using TrendYol.Models;
using TrendYol.Context;

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
    private readonly TrendyolDbContext _context;
    private ObservableCollection<Order> _order;
    private Order _selectedOrder;

    public ObservableCollection<Order> Orders
    {
        get => _order;
        set => Set(ref _order, value);

    }

    public Order SelectedOrders
    {
        get => _selectedOrder;
        set => Set(ref _selectedOrder, value);
    }

    public HomePageViewModel(TrendyolDbContext context, IMessenger _messenger, INavigationService navigation)
    {

        navigationService = navigation;
        _context = context;
        CurrentView = App.Container.GetInstance<RegisterViewModel>();

        _messenger.Register<NavigationMessage>(this, message =>
        {
            CurrentView = message.ViewModelType;
        });
        Orders = new ObservableCollection<Order>(_context.Order);
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

    public RelayCommand Shop
    {
        get => new(() =>
        {
            navigationService.NavigateTo<ShopViewModel>();
        });
    }

    public RelayCommand Quit
    {
        get => new(
            () =>
            {
                navigationService.NavigateTo<LoginViewModel>();

            });
    }



}


