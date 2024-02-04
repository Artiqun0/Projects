using System.Windows;
using SimpleInjector;
using TrendYol.Message;
using TrendYol.ViewModel;
using TrendYol.Services.Interfaces;
using TrendYol.Services.Classes;
using GalaSoft.MvvmLight.Messaging;

namespace TrendYol;
    public partial class App : Application
    {
        public static Container Container { get; set; } = new();

        public void Register()
        {
            Container.RegisterSingleton<LoginViewModel>();
            Container.RegisterSingleton<MainViewModel>();

            Container.RegisterSingleton<INavigationService, NavigationService>();

            Container.RegisterSingleton<DataMessage>();
            Container.RegisterSingleton<DataMessages>();
            Container.RegisterSingleton<IMessenger, Messenger>();

            Container.Verify();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Register();

            var window = App.Container.GetInstance<MainWindow>();
            window.DataContext = Container.GetInstance<MainViewModel>();


            window.ShowDialog();

        }
    }

