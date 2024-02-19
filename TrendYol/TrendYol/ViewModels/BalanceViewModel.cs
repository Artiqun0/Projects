using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TrendYol.Context;
using TrendYol.Message;
using TrendYol.Models;
using TrendYol.Services.Classes;
using TrendYol.Services.Interfaces;

namespace TrendYol.ViewModels;
    public class BalanceViewModel : ViewModelBase
    {
    private readonly TrendyolDbContext _trendyoulDB;
    private readonly CurrentUserService _currentUserService;
    private readonly IMessenger _messenger;
    private readonly INavigationService _navigation;
    public User _currentUser = new();
    private double _balance;

    public double Balance
    {
        get { return _balance; }
        set { _balance = value; }
    }
    public User CurentUser
    {
        get => _currentUser;
        set
        {
            Set(ref _currentUser, value);
        }
    }

    private string AddToBalanceTextBox;

    public string TextBox1
    {
        get => AddToBalanceTextBox;
        set
        {
            if (AddToBalanceTextBox != value)
            {
                AddToBalanceTextBox = value;
                RaisePropertyChanged(nameof(TextBox1));
            }
        }
    }
    public BalanceViewModel(INavigationService navigation ,IMessenger messenger, TrendyolDbContext context, CurrentUserService currentUserService)
    {
        _messenger = messenger;
        _trendyoulDB = context;
        _navigation = navigation;
        _currentUserService = currentUserService;
        _currentUserService.PropertyChanged += (sender, args) =>
        {
             Balance = _currentUserService.Balance;
        };
        _currentUserService.UpdateUserData(_currentUser);
        _messenger.Register<DataMessage>(this, message =>
        {
            if (message.Data as User != null)
            {
                CurentUser = message.Data as User;

            }
        });
    }


    public string BalanceInfo => _currentUser.Balance.ToString();


    public RelayCommand AddToBalance
    {
        get => new(() =>
        {
            if (float.TryParse(AddToBalanceTextBox, out float amountToAdd))
            {
                _currentUserService.Balance += amountToAdd;


                var user = _trendyoulDB.User.FirstOrDefault(u => u.Username == _currentUserService.Login);
                if (user != null)
                {
                    user.Balance = _currentUserService.Balance;
                    _trendyoulDB.SaveChanges();
                    MessageBox.Show("Successful Pay!");
                    _navigation.NavigateTo<ShopViewModel>();
                    TextBox1 = string.Empty;
                }
                
                RaisePropertyChanged(nameof(BalanceInfo));
            }
            else
            {
                MessageBox.Show("Incorrect value for replenishing the balance.");
            }
            TextBox1 = string.Empty;
        });
    }

    public RelayCommand Back
    {
        get => new(
            () =>
            {
                _navigation.NavigateTo<HomePageViewModel>();
            });
    }

}
    

