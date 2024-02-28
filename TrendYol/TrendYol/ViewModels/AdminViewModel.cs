using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

    public Models.RadioButton RadioButton
    {
        get => _radioButtons;
        set => Set(ref _radioButtons, value);
    }

    public AdminViewModel(INavigationService navigationService, TrendyolDbContext context, CurrentUserService currentUserService)
    {
        _navigationService = navigationService;
        _context = context;
        _currentUserService = currentUserService;
        _radioButtons = new Models.RadioButton();
        Order = new ObservableCollection<Order>(_context.Order);
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

    public RelayCommand Check
    {
        get => new(
            () =>
            {
                try
                {
                    if (RadioButton.OrderPlaced)
                    {
                        if (SelectedOrder.Status == "Order Placed")
                        {
                            SelectedOrder.Status = "Order Placed";
                        }
                        else
                        {
                            MessageBox.Show("Impossible to transfer the order to this stage");
                            return;
                        }
                    }
                    else if (RadioButton.ArrivedAtTheWarehouse)
                    {
                        if (SelectedOrder.Status == "Order Placed" || SelectedOrder.Status == "Arrived At The Stock")
                        {
                            SelectedOrder.Status = "Arrived At The Stock";
                        }
                        else
                        {
                            MessageBox.Show("Impossible to transfer the order to this stage");
                            return;
                        }
                    }
                    else if (RadioButton.Sent)
                    {
                        if (SelectedOrder.Status == "Arrived At The Stock" || SelectedOrder.Status == "Sent")
                        {
                            SelectedOrder.Status = "Sent";
                        }
                        else
                        {
                            MessageBox.Show("Impossible to transfer the order to this stage");
                            return;
                        }
                    }
                    else if (RadioButton.SmartCustomsCheck)
                    {
                        if (SelectedOrder.Status == "Sent" || SelectedOrder.Status == "At customs check")
                        {
                            SelectedOrder.Status = "At customs check";
                        }
                        else
                        {
                            MessageBox.Show("Impossible to transfer the order to this stage");
                            return;
                        }
                    }
                    else if (RadioButton.InFilial)
                    {
                        if (SelectedOrder.Status == "At customs check" || SelectedOrder.Status == "In Filial")
                        {
                            SelectedOrder.Status = "In Filial";
                        }
                        else
                        {
                            MessageBox.Show("Impossible to transfer the order to this stage");
                            return;
                        }
                    }
                    _context.SaveChanges();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
    }
}

