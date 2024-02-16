﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TrendYol.Context;
using TrendYol.Services.Interfaces;

namespace TrendYol.ViewModels;
    public class ForgotPassViewModel : ViewModelBase
    {
    private readonly INavigationService navigationService;
    private readonly IDataService _dataService;
    private readonly IMessenger _messenger;

    TrendyolDbContext _trendyoulDb = new TrendyolDbContext();


    private string usernameTextBox;
    private string secetWordTextBox;
    private string newPasswordTextBox;
    private string confirmNewPasswordTextBox;

    public string TextBox1
    {
        get => usernameTextBox;
        set
        {
            if (usernameTextBox != value)
            {
                usernameTextBox = value;
                RaisePropertyChanged(nameof(TextBox1));
            }
        }
    }
    public string TextBox2
    {
        get => secetWordTextBox;
        set
        {
            if (secetWordTextBox != value)
            {
                secetWordTextBox = value;
                RaisePropertyChanged(nameof(TextBox2));
            }
        }
    }
    public string TextBox3
    {
        get => newPasswordTextBox;
        set
        {
            if (newPasswordTextBox != value)
            {
                newPasswordTextBox = value;
                RaisePropertyChanged(nameof(TextBox3));
            }
        }
    }
    public string TextBox4
    {
        get => confirmNewPasswordTextBox;
        set
        {
            if (confirmNewPasswordTextBox != value)
            {
                confirmNewPasswordTextBox = value;
                RaisePropertyChanged(nameof(TextBox4));
            }
        }
    }

    public ForgotPassViewModel(IMessenger messenger, IDataService dataService, INavigationService navigation)
    {
        navigationService = navigation;
        _dataService = dataService;
        _messenger = messenger;



    }
    public RelayCommand BackToLogin
    {
        get => new(() =>
        {
            navigationService.NavigateTo<LoginViewModel>();
        });
    }

    string passwordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()\-_=+\\|[\]{};:'"",.<>/?]).{8,20}$";


    public RelayCommand ResetPassword
    {
        get => new(() =>
        {
            var user = _trendyoulDb.User.FirstOrDefault(u => u.Username == TextBox1 && u.SecretWord == TextBox2);

            if (user != null && System.Text.RegularExpressions.Regex.IsMatch(TextBox3, passwordRegex) && TextBox3 == TextBox4)
            {
                BCrypt.Net.BCrypt.HashPassword(TextBox3);
                _trendyoulDb.SaveChanges();

                MessageBox.Show("The password was successfully changed!");
                navigationService.NavigateTo<LoginViewModel>();
            }
        });
    }
}
    

