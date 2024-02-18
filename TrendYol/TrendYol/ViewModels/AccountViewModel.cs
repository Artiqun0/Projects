using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendYol.Models;
using TrendYol.Services.Interfaces;

namespace TrendYol.ViewModels;
    public class AccountViewModel : ViewModelBase
    {
    private readonly INavigationService navigationService;
    private readonly IDataService _dataService;
    private readonly IMessenger _messenger;



    public AccountViewModel(IMessenger messenger, IDataService dataService, INavigationService navigation)
    {
        navigationService = navigation;
        _dataService = dataService;
        _messenger = messenger;
    }

}

