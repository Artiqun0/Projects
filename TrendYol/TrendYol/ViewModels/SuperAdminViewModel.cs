using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendYol.Context;
using TrendYol.Services.Interfaces;

namespace TrendYol.ViewModels;
    public class SuperAdminViewModel : ViewModelBase
{
    private readonly INavigationService navigationService;
    private readonly IDataService _dataService;
    private readonly IMessenger _messenger;

    TrendyolDbContext _trendyoulDB = new TrendyolDbContext();
    public SuperAdminViewModel(IMessenger messenger, IDataService dataService)
    {
        _dataService = dataService;
        _messenger = messenger;
    }

    public RelayCommand MakeUserAdmin
    {
        get => new(() =>
        {
            navigationService.NavigateTo<RegisterViewModel>();
        });
    }


}

