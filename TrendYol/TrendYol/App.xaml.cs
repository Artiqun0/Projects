using System.Windows;
using SimpleInjector;
using TrendYol.Messages;
using TrendYol.ViewModels;
using TrendYol.Services.Interfaces;
using TrendYol.Services.Classes;
using GalaSoft.MvvmLight.Messaging;
using TrendYol.Views;

namespace TrendYol;
    public partial class App : Application
    {
        public static Container Container { get; set; } = new();
        public static MainWindow window = new();


    public void Register()
        {
            Container.RegisterSingleton<LoginViewModel>();
            Container.RegisterSingleton<MainViewModel>();
            Container.RegisterSingleton<RegisterViewModel>();
            Container.RegisterSingleton<AccountViewModel>();
            Container.RegisterSingleton<ForgotPassViewModel>();
            Container.RegisterSingleton<HomePageViewModel>();
            Container.RegisterSingleton<BalanceViewModel>();
            Container.RegisterSingleton<ShopViewModel>();

        Container.RegisterSingleton<INavigationService, NavigationService>();
            Container.RegisterSingleton<IMessenger, Messenger>();
            Container.RegisterSingleton<IDataService, DataService>();



        Container.Verify();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Register();

            window.DataContext = Container.GetInstance<MainViewModel>();


            window.ShowDialog();

        }
    }

