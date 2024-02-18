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
using TrendYol.Models;
using TrendYol.Services.Interfaces;
using TrendYol.Views;

namespace TrendYol.ViewModels;
    internal class LoginViewModel : ViewModelBase
    {
    private readonly INavigationService navigationService;
    private readonly IDataService _dataService;
    private readonly IMessenger _messenger;

    TrendyolDbContext _trendyoulDB = new TrendyolDbContext();

    private string usernameTextBox;
    private string passwordTextBox;

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
        get => passwordTextBox;
        set
        {
            if (passwordTextBox != value)
            {
                passwordTextBox = value;
                RaisePropertyChanged(nameof(TextBox2));
            }
        }
    }
    public LoginViewModel(IMessenger messenger, IDataService dataService, INavigationService navigation)
    {
        navigationService = navigation;
        _dataService = dataService;
        _messenger = messenger;
        
    }
    public RelayCommand DoRegistration
    {
        get => new(() =>
        {
            navigationService.NavigateTo<RegisterViewModel>();
        });
    }

    public RelayCommand CompleteLogin
    {
        get => new(() =>
        {
            var user = _trendyoulDB.User.FirstOrDefault(u => u.Username == TextBox1);

            if (user != null)
            {
                if (BCrypt.Net.BCrypt.Verify(TextBox2, user.Password))
                {

                    //_currentUser.Username = user.Username;
                    //_currentUser.Email = user.Email;
                    //_currentUser.Balance = user.Balance;
                    //_currentUser.Position = user.Position;

                    HomePageView newWindow = new HomePageView();
                    newWindow.DataContext = App.Container.GetInstance<AccountViewModel>();
                    navigationService.NavigateTo<ShopViewModel>();

                    App.window.Close();

                    newWindow.ShowDialog();
                }


            }
            else
            {
                MessageBox.Show("User not found.");
            }



        });
    }

    public RelayCommand ForgotPassword
    {
        get => new(() =>
        {
            navigationService.NavigateTo<ForgotPassViewModel>();
        });
    }

    public void UsersChecking()
    {

    }

}

    

