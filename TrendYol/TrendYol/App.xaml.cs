using System.Windows;
using SimpleInjector;
using TrendYol.Messages;
using TrendYol.ViewModels;
using TrendYol.Services.Interfaces;
using TrendYol.Services.Classes;
using GalaSoft.MvvmLight.Messaging;
using TrendYol.Views;
using TrendYol.Context;

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
            Container.Register<HomePageViewModel>();
            Container.RegisterSingleton<BalanceViewModel>();
            Container.Register<ShopViewModel>();
            Container.Register<SuperAdminViewModel>();
            Container.Register<AdminViewModel>();
            Container.RegisterSingleton<CreateUserViewModel>();
            Container.RegisterSingleton<CreateAdminViewModel>();
            Container.RegisterSingleton<AddProductViewModel>();
            Container.RegisterSingleton<CountViewModel>();


            Container.RegisterSingleton<INavigationService, NavigationService>();
            Container.RegisterSingleton<IMessenger, Messenger>();
            Container.RegisterSingleton<IDataService, DataService>();
            Container.RegisterSingleton<TrendyolDbContext>();
            Container.RegisterSingleton<CurrentUserService>();

        Container.Verify();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Register();

            window.DataContext = Container.GetInstance<MainViewModel>();


            window.ShowDialog();

        }
    }

