﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using TrendYol.Context;
using TrendYol.Models;
using TrendYol.Services.Interfaces;
using TrendYol.Views;

namespace TrendYol.ViewModels;
    public class RegisterViewModel : ViewModelBase
    {
    private readonly INavigationService navigationService;
    private readonly TrendyolDbContext _context;
    private readonly IDataService _dataService;




    private string usernameTextBox;
    private string emailTextBox;
    private string passwordTextBox;
    private string confirmPasswordTextBox;
    private string secetWordTextBox;

    public string TextBox1
    {
        get => usernameTextBox;
        set
        {
            if (usernameTextBox != value)
            {
                usernameTextBox = value;
                RaisePropertyChanged(nameof(TextBox1));
            }
        }
    }
    public string TextBox2
    {
        get => emailTextBox;
        set
        {
            if (emailTextBox != value)
            {
                emailTextBox = value;
                RaisePropertyChanged(nameof(TextBox2));
            }
        }
    }
    public string TextBox3
    {
        get => passwordTextBox;
        set
        {
            if (passwordTextBox != value)
            {
                passwordTextBox = value;
                RaisePropertyChanged(nameof(TextBox3));
            }
        }
    }
    public string TextBox4
    {
        get => confirmPasswordTextBox;
        set
        {
            if (confirmPasswordTextBox != value)
            {
                confirmPasswordTextBox = value;
                RaisePropertyChanged(nameof(TextBox4));
            }
        }
    }
    public string TextBox5
    {
        get => secetWordTextBox;
        set
        {
            if (secetWordTextBox != value)
            {
                secetWordTextBox = value;
                RaisePropertyChanged(nameof(TextBox5));
            }
        }
    }

    public RegisterViewModel(INavigationService navigation, TrendyolDbContext context, IDataService dataService)
    {
        navigationService = navigation;
        _context = context;
        _dataService = dataService;
    }

    public RelayCommand BackToLogin
    {
        get => new(() =>
        {
            TextBox1 = String.Empty;
            TextBox2 = String.Empty;
            TextBox3 = String.Empty;
            TextBox4 = String.Empty;
            TextBox5 = String.Empty;
            navigationService.NavigateTo<LoginViewModel>();
        });
    }

    public RelayCommand CompleteRegistration
    {
        get => new(() =>
        {
            var res = ValidateUserData(TextBox1, TextBox2, TextBox3, TextBox4, TextBox5);

            if (res == true)
            {
                User newUser = new User
                {
                    Username = TextBox1,
                    Password = BCrypt.Net.BCrypt.HashPassword(TextBox3),
                    Email = TextBox2,
                    SecretWord = TextBox5,
                    Balance = 0,
                    Position = "User"
                };

                _context.User.Add(newUser);
                _context.SaveChanges();

                MessageBox.Show("Registration completed successfully!");

                User CurentUser = _context.User.Single(u => u.Email == TextBox2);
                _dataService.SendData(CurentUser);
                
                HomePageView newWindow = new HomePageView();
                newWindow.DataContext = App.Container.GetInstance<AccountViewModel>();

                App.window.Close();

                newWindow.ShowDialog();
            }
            else
                return;



        });
    }


    public bool ValidateUserData(string t1, string t2, string t3, string t4, string t5)
    {
        string usernameRegex = @"^(?=[a-zA-Z0-9_]{3,16}$)(?![_0-9])[a-zA-Z0-9_]+$";
        string passwordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()\-_=+\\|[\]{};:'"",.<>/?]).{8,20}$";
        string secretWordRegex = @"^(?!\s)(?!.*\s$)[a-zA-Z0-9\s]{5,20}$";
        string emailRegex = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

        var userNameCheck = _context.User.FirstOrDefault(u => u.Username == TextBox1);
        var emailCheck = _context.User.FirstOrDefault(u => u.Email == TextBox2);


        if (userNameCheck != null && emailCheck != null)
        {
            if (t1 == userNameCheck.Username)
            {
                MessageBox.Show("A user with the same Username already exists.");
                return false;
            }
            if (t2 == emailCheck.Email)
            {
                MessageBox.Show("a user with the same email already exists.");
            }
        }

        if (string.IsNullOrWhiteSpace(t1) || !Regex.IsMatch(t1, usernameRegex))
        {
            MessageBox.Show("The username entered is incorrect! Length from 3 to 16 characters.\r\nCan only contain letters of the Latin alphabet (in any case), numbers and underscores.\r\nMust not begin with a number or underscore.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        if (string.IsNullOrWhiteSpace(t2) || !Regex.IsMatch(t2, emailRegex))
        {
            MessageBox.Show("The email was entered incorrectly. Please re-enter.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        if (string.IsNullOrWhiteSpace(t3) || !Regex.IsMatch(t3, passwordRegex))
        {
            MessageBox.Show("The password entered is incorrect! Length from 8 to 20 characters.\r\nMust contain at least one uppercase and lowercase letter.\r\nMust contain at least one digit.\r\nSpecial characters are allowed.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        if (string.IsNullOrWhiteSpace(t4) || !Regex.IsMatch(t3, passwordRegex))
        {
            MessageBox.Show("The password entered is incorrect! Length from 8 to 20 characters.\r\nMust contain at least one uppercase and lowercase letter.\r\nMust contain at least one digit.\r\nSpecial characters are allowed.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        if (t3 != t4)
        {
            MessageBox.Show("Password and confirm password must match.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }

        if (string.IsNullOrWhiteSpace(t5) || !Regex.IsMatch(t5, secretWordRegex))
        {
            MessageBox.Show("The secret word was entered incorrectly! Length from 5 to 20 characters.\r\nMay contain letters of the Latin alphabet (in any case), numbers and spaces.\r\nMust not start or end with a space.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;
        }


        return true;
    }
}
    

