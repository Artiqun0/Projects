using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TrendYol.Context;
using TrendYol.Services.Classes;
using TrendYol.Services.Interfaces;

namespace TrendYol.ViewModels
{
    public class CreateUserViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly TrendyolDbContext _context;
        private readonly UserService _userService;
        private string _name;
        private string _email;
        private string _login;
        private string _secret;
        private string _password;
        private string _trypassword;

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public string Email
        {
            get => _email;
            set => Set(ref _email, value);
        }

        public string Login
        {
            get => _login;
            set => Set(ref _login, value);
        }

        public string Secret
        {
            get => _secret;
            set => Set(ref _secret, value);
        }

        public string Password
        {
            get => _password;
            set => Set(ref _password, value);
        }

        public string TryPassword
        {
            get => _trypassword;
            set => Set(ref _trypassword, value);
        }
        public CreateUserViewModel(INavigationService navigationService, TrendyolDbContext context)
        {
            _navigationService = navigationService;
            _context = context;
            _userService = new UserService(_context);
        }

        public RelayCommand Back
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<SuperAdminViewModel>();
                });
        }

        public RelayCommand Add
        {
            get => new(
                () =>
                {
                    try
                    {
                        using (TrendyolDbContext context = new TrendyolDbContext())
                        {
                            if (_context.Admin.Any(a => a.Name == Login))
                            {
                                MessageBox.Show("User whith such name is already exist", "Error");
                                return;
                            }
                            else if (TryPassword != Password)
                            {
                                MessageBox.Show("Confirm password correctly!", "Error");
                                return;
                            }
                            else
                            {
                                var user = _userService.RegisterUser(Name, Email, Password, Secret);
                                _context.User.Add(user);
                                _context.SaveChanges();
                                MessageBox.Show("Succes", "Admin");
                                Password = "";
                                TryPassword = "";
                                _navigationService.NavigateTo<SuperAdminViewModel>();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                });
        }
    }
}
