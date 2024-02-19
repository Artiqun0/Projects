using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendYol.Context;
using TrendYol.Models;

namespace TrendYol.Services.Classes
{
    public class ForgotPasswordService
    {
        private readonly TrendyolDbContext _context;

        public ForgotPasswordService(TrendyolDbContext context)
        {
            _context = context;
        }

        public User ForgotPassword(string username, string email, string password)
        {
            User user = _context.User.SingleOrDefault(u => u.Username == username && u.Email == email);
            if (user != null)
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(password);
            }
            return user;
        }
    }
}
