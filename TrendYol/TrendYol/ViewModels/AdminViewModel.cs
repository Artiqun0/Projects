using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;
using TrendYol.Context;
using TrendYol.Models;
using TrendYol.Services.Classes;
using TrendYol.Services.Interfaces;

namespace TrendYol.ViewModels;

    public class AdminViewModel : ViewModelBase
    {
    private readonly INavigationService _navigationService;
    private readonly TrendyolDbContext _context;
    private readonly CurrentUserService _currentUserService;
    private ObservableCollection<Order> _order;
    private Order _selectedOrder;
    private Models.RadioButton _radioButtons;

    public ObservableCollection<Order> Order
    {
        get => _order;
        set => Set(ref _order, value);
    }

    public Order SelectedOrder
    {
        get => _selectedOrder;
        set => Set(ref _selectedOrder, value);
    }

    public AdminViewModel(INavigationService navigationService, TrendyolDbContext context, CurrentUserService currentUserService)
    {
        _navigationService = navigationService;
        _context = context;
        _currentUserService = currentUserService;
        Order = new ObservableCollection<Order>(_context.Order.ToList());
    }
    public RelayCommand BackToLogin
    {
        get => new(() =>
        {
            _navigationService.NavigateTo<LoginViewModel>();
        });
    }
    public RelayCommand Add
    {
        get => new(
            () =>
            {
                _navigationService.NavigateTo<AddProductViewModel>();
            });
    }
}

