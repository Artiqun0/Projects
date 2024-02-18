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

namespace TrendYol.ViewModels;
    public class BalanceViewModel : ViewModelBase
    {
    TrendyolDbContext _trendyoulDB = new TrendyolDbContext();
    private readonly IMessenger _messenger;
    public User _currentUser = new();
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
    public BalanceViewModel(IMessenger messenger)
    {
        _messenger = messenger;
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
                CurentUser.Balance += amountToAdd;


                var user = _trendyoulDB.User.FirstOrDefault(u => u.Username == _currentUser.Username);
                if (user != null)
                {
                    user.Balance = _currentUser.Balance;
                    _trendyoulDB.SaveChanges();
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

}
    

