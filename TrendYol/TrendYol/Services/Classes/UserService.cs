using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using TrendYol.Context;
using TrendYol.Models;
using TrendYol.ViewModels;
using TrendYol.Views;

namespace TrendYol.Services.Classes
{
    public class UserService
    {
        private readonly TrendyolDbContext _context;

        public UserService(TrendyolDbContext context)
        {
            _context = context;
        }

        public User LoginGet(string username)
        {
            return _context.User.FirstOrDefault(u => u.Username == username);
        }

        public bool UserLogin(string email, string password)
        {
            User user = _context.User.FirstOrDefault(u => u.Username == email);
            if (user != null)
            {
                return BCrypt.Net.BCrypt.Verify(password, user.Password);

            }
            return false;
        }

        public User RegisterUser(string name, string email, string password, string secret)
        {
            User user = new User
            {
                Username = name,
                Email = email,
                Password = BCrypt.Net.BCrypt.HashPassword(password),
                SecretWord = secret
            };
            return user;
        }
    }
}
