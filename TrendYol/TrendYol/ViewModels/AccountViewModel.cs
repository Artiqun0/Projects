using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendYol.Message;
using TrendYol.Models;
using TrendYol.Services.Classes;
using TrendYol.Services.Interfaces;

namespace TrendYol.ViewModels;
public class AccountViewModel : ViewModelBase
{
    private readonly INavigationService navigationService;
    private readonly IDataService _dataService;
    private readonly IMessenger _messenger;
    private readonly CurrentUserService _currentUserService;
    private readonly User user = new();

    private string _username;
    private string _email;
    private string _secretWorld;

    public string Username
    {
        get { return _username; }
        set { _username = value; }
    }

    public string Email
    {
        get { return _email; }
        set { _email = value; }
    }

    public string SecretWorld
    {
        get { return _secretWorld; }
        set { _secretWorld = value; }
    }

    public User _currentUser = new();
    public User CurentUser
    {
        get => _currentUser;
        set
        {
            Set(ref _currentUser, value);
        }
    }

    public AccountViewModel(IMessenger messenger, IDataService dataService, INavigationService navigation, CurrentUserService currentUserService)
    {
        navigationService = navigation;
        _dataService = dataService;
        _messenger = messenger;
        _currentUserService = currentUserService;
        _currentUserService.PropertyChanged += (sender, args) =>
        {
            if (args.PropertyName == nameof(CurrentUserService.Email))
            {
                Email = _currentUserService.Email;
            }
            else if (args.PropertyName == nameof(CurrentUserService.Login))
            {
                Username = _currentUserService.Login;
            }
            else if (args.PropertyName == nameof(CurrentUserService.Secret))
            {
                SecretWorld = _currentUserService.Secret;
            }
        };

        _currentUserService.UpdateUserData(user);

        _messenger.Register<DataMessage>(this, message =>
        {
            if (message.Data as User != null)
            {
                CurentUser = message.Data as User;

            }


        });

    }

    public RelayCommand Back
    {
        get => new(
            () =>
            {
                navigationService.NavigateTo<HomePageViewModel>();
            });
    }

}

