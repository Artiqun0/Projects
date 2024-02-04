using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendYol.Messages;

namespace TrendYol.ViewModels;
class MainViewModel : ViewModelBase
{
    private ViewModelBase _currentView;
    private readonly IMessenger _messenger;

    public ViewModelBase CurrentView
    {
        get => _currentView;
        set
        {
            Set(ref _currentView, value);
        }
    }

    public MainViewModel(IMessenger messenger)
    {
        _messenger = messenger;
        CurrentView = App.Container.GetInstance<LoginViewModel>();

        _messenger.Register<NavigationMessage>(this, message =>
        {
            if (message != null)
            {
                CurrentView = message.ViewModelType;
            }
        });

    }
}

