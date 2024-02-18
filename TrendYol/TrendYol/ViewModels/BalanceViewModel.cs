﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TrendYol.Context;
using TrendYol.Models;

namespace TrendYol.ViewModels;
    public class BalanceViewModel : ViewModelBase
    {
    TrendyolDbContext _trendyoulDB = new TrendyolDbContext();

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
    //public BalanceViewModel(User currentUser)
    //{
    //    _currentUser = currentUser;
    //}


    //public string BalanceInfo => _currentUser.Balance.ToString();


    //public RelayCommand AddToBalance
    //{
    //    get => new(() =>
    //    {
    //        if (float.TryParse(AddToBalanceTextBox, out float amountToAdd))
    //        {
    //            _currentUser.Balance += amountToAdd;


    //            var user = _trendyoulDB.User.FirstOrDefault(u => u.Username == _currentUser.Username);
    //            if (user != null)
    //            {
    //                user.Balance = _currentUser.Balance;
    //                _trendyoulDB.SaveChanges();
    //            }
    //            RaisePropertyChanged(nameof(BalanceInfo));
    //        }
    //        else
    //        {
    //            MessageBox.Show("Incorrect value for replenishing the balance.");
    //        }
    //        TextBox1 = string.Empty;
    //    });
    //}

}
    

