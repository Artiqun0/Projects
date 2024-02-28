using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendYol.Models;

namespace TrendYol.Services.Classes;

public class CurrentUserService : INotifyPropertyChanged
{
    private int _userid;
    private string _login;
    private string _secret;
    private string _email;
    private double _balance;

    public int UserId
    {
        get => _userid; 
        set
        {
            _userid = value;
            OnPropertyChanged(nameof(UserId));
        }
    }

 

    public string Login
    {
        get => _login;
        set
        {
            _login = value;
            OnPropertyChanged(nameof(Login));
        }
    }

    public string Email
    {
        get => _email;
        set
        {
            _email = value;
            OnPropertyChanged(nameof(Email));
        }
    }

    public string Secret
    {
        get => _secret;
        set
        {
            _secret = value;
            OnPropertyChanged(nameof(Secret));
        }
    }


    public double Balance
    {
        get => _balance;
        set
        {
            _balance = value;
            OnPropertyChanged(nameof(Balance));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public void UpdateUserData(User user)
    {
        UserId = user.UserId;
        Login = user.Username;
        Email = user.Email;
        Balance = user.Balance;
        Secret = user.SecretWord;
    }

}
