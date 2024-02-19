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
using TrendYol.Services.Classes;
using TrendYol.Services.Interfaces;
using TrendYol.Views;

namespace TrendYol.ViewModels;
    internal class LoginViewModel : ViewModelBase
    {
    private readonly INavigationService navigationService;
    private readonly IDataService _dataService;
    private readonly IMessenger _messenger;
    private readonly TrendyolDbContext _trendyoulDB;
    private readonly SuperAdminService _superAdminService;
    private readonly UserService _userService;
    private readonly CurrentUserService _currentUserService;
    

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
    public LoginViewModel(IMessenger messenger, IDataService dataService, INavigationService navigation, TrendyolDbContext trendyoulDB, CurrentUserService currentUserService)
    {
        navigationService = navigation;
        _dataService = dataService;
        _messenger = messenger;
        _trendyoulDB = trendyoulDB;
        _superAdminService = new SuperAdminService(_trendyoulDB);
        _userService = new UserService(_trendyoulDB);
        _currentUserService = currentUserService;
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

            try
            {
                if (_superAdminService.SuperAdminLogin(TextBox1, TextBox2))
                {
                    SuperAdminWindow newWindow = new SuperAdminWindow();
                    newWindow.DataContext = App.Container.GetInstance<SuperAdminViewModel>();
                    navigationService.NavigateTo<SuperAdminViewModel>();
                    App.window.Close();

                    newWindow.ShowDialog();
                }
                else if (_userService.UserLogin(TextBox1, TextBox2))
                {
                    var user = _userService.LoginGet(TextBox1);
                    _currentUserService.UpdateUserData(user);
                    HomePageView newWindow = new HomePageView();
                    newWindow.DataContext = App.Container.GetInstance<HomePageViewModel>();
                    navigationService.NavigateTo<ShopViewModel>();
                    App.window.Close(); 
                    newWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Wrong password");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
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

    

