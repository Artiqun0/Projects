using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendYol.Message;
using TrendYol.Models;
using TrendYol.Services.Interfaces;

namespace TrendYol.ViewModels;
public class AccountViewModel : ViewModelBase
{
    private readonly INavigationService navigationService;
    private readonly IDataService _dataService;
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

    public AccountViewModel(IMessenger messenger, IDataService dataService, INavigationService navigation)
    {
        navigationService = navigation;
        _dataService = dataService;
        _messenger = messenger;

        _messenger.Register<DataMessage>(this, message =>
        {
            if (message.Data as User != null)
            {
                CurentUser = message.Data as User;

            }


        });

    }

}

