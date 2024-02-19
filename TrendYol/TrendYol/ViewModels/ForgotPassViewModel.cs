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
        _firmPasswordService = new ForgotPasswordService(_trendyoulDb);



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
    

