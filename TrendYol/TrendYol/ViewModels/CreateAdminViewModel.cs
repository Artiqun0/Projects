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
    public class CreateAdminViewModel : ViewModelBase
    {
        private readonly INavigationService _navigation;
        private readonly TrendyolDbContext _context;
        private readonly UserService _userService;
        private readonly AdminService _adminService;

        private string _login;
        private string _password;
        private string _trypassword;

        public string Login
        {
            get => _login;
            set => Set(ref _login, value);
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


        public CreateAdminViewModel(INavigationService navigation, TrendyolDbContext context)
        {
            _navigation = navigation;
            _context = context;
            _adminService = new AdminService(_context);
        }

        public RelayCommand Back
        {
            get => new(
                () =>
                {
                    _navigation.NavigateTo<SuperAdminViewModel>();
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
                                MessageBox.Show("Admin whith such name is already exist", "Error");
                                return;
                            }
                            else if (TryPassword != Password)
                            {
                                MessageBox.Show("Confirm password correct!", "Error");
                                return;
                            }
                            else
                            {
                                var newadmin = _adminService.AdminRegister(Login, Password);
                                _context.Admin.Add(newadmin);
                                _context.SaveChanges();
                                MessageBox.Show("Success", "Admin");
                                Password = "";
                                TryPassword = "";
                                _navigation.NavigateTo<SuperAdminViewModel>();
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
