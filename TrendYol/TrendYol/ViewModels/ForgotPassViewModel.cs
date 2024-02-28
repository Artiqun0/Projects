using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using TrendYol.Context;
using TrendYol.Services.Classes;
using TrendYol.Services.Interfaces;

namespace TrendYol.ViewModels;
    public class ForgotPassViewModel : ViewModelBase
    {
    private readonly INavigationService navigationService;
    private readonly IDataService _dataService;
    private readonly IMessenger _messenger;
    private readonly ForgotPasswordService _firmPasswordService;

    TrendyolDbContext _trendyoulDb = new TrendyolDbContext();


    private string usernameTextBox;
    private string emailTextBox;
    private string newPasswordTextBox;
    private string confirmNewPasswordTextBox;

    public string TextBox1
    {
        get => usernameTextBox;
        set
        {
            if (Regex.IsMatch(value, @"^(?=[a-zA-Z0-9_]{3,16}$)(?![_0-9])[a-zA-Z0-9_]+$") || string.IsNullOrEmpty(value))
            {
                Set(ref usernameTextBox, value);
            }
            else
            {
                MessageBox.Show("Enter the correct username");
                return;
            }
        }
    }
    public string TextBox2
    {
        get => emailTextBox;
        set
        {
            if (Regex.IsMatch(value, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$") || string.IsNullOrEmpty(value))
            {
                Set(ref emailTextBox, value);
            }
            else
            {
                MessageBox.Show("Enter the correct e-mail");
                return;
            }
        }
    }
    public string TextBox3
    {
        get => newPasswordTextBox;
        set
        {
            if (Regex.IsMatch(value, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()\-_=+\\|[\]{};:'"",.<>/?]).{8,20}$") || string.IsNullOrEmpty(value))
            {
                Set(ref newPasswordTextBox, value);
            }
            else
            {
                MessageBox.Show("Enter the correct password");
                return;
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
        _firmPasswordService = new ForgotPasswordService(_trendyoulDb);



    }
    public RelayCommand BackToLogin
    {
        get => new(() =>
        {
            navigationService.NavigateTo<LoginViewModel>();
        });
    }


    public RelayCommand ResetPassword
    {
        get => new(() =>
        {
            try
            {
                if (!_trendyoulDb.User.Any(u => u.Username == TextBox1 && u.Email == TextBox2))
                {
                    MessageBox.Show("User not found");
                    return;
                }
                else if (TextBox4 != TextBox3)
                {
                    MessageBox.Show("Password mismatch!");
                    TextBox4 = "";
                    TextBox3 = "";
                    return;
                }
                else
                {
                    _firmPasswordService.ForgotPassword(TextBox1, TextBox2, TextBox3);
                    _trendyoulDb.SaveChanges();
                    MessageBox.Show("Password upgrated succestful");
                    TextBox1 = "";
                    TextBox2 = "";
                    TextBox3 = "";
                    navigationService.NavigateTo<LoginViewModel>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        });
    }
}
    

