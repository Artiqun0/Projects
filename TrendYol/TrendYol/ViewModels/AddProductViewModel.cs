using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using TrendYol.Context;
using TrendYol.Models;
using TrendYol.Services.Classes;
using TrendYol.Services.Interfaces;

namespace TrendYol.ViewModels
{
    public class AddProductViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly TrendyolDbContext _context;
        private readonly CurrentUserService _currentUserService;
        private readonly OrderService _addOrderService;
        private readonly Product _product;
        private string _name;
        private string _description;
        private double _price;
        private int _count;

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        public string Description
        {
            get => _description;
            set => Set(ref _description, value);
        }


        public int Count
        {
            get => _count;
            set => Set(ref _count, value);
        }

        public double Price
        {
            get => _price;
            set => Set(ref _price, value);
        }

        public AddProductViewModel(INavigationService navigationService, TrendyolDbContext context, CurrentUserService currentUserService)
        {
            _navigationService = navigationService;
            _context = context;
            _currentUserService = currentUserService;
            _addOrderService = new OrderService(_context);
            _product = new Product();
        }

        public RelayCommand Image
        {
            get => new(
                () =>
                {
                    OpenFileDialog openFileDialog = new();
                    openFileDialog.Filter = "Фото (*.jpg;*.jpeg;*.png;*.gif) | *.jpg;*jpeg;*.png;*.gif";
                    if (openFileDialog.ShowDialog() == true)
                    {
                        _product.Image = File.ReadAllBytes(openFileDialog.FileName);
                    }
                });
        }

        public RelayCommand Back
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<AdminViewModel>();
                });
        }
        public RelayCommand Add
        {
            get => new(
                () =>
                {
                    try
                    {
                        
                        if (_product.Image == null)
                        {
                            MessageBox.Show("Choice image");
                            return;
                        }
                        var product = _addOrderService.AddProductOrder(Name, Description, Price, Count, _product.Image);
                        if (product != null)
                        {
                            _context.Products.Add(product);
                            _context.SaveChanges();
                            Stock ware = new Stock()
                            {
                                ProductId = product.Id,
                                ProductCount = product.Count,
                                
                            };
                            _context.Stock.Add(ware);
                            _context.SaveChanges();
                            Name = "";
                            Description = "";
                            Count = 0;
                            MessageBox.Show("Successful");
                            _navigationService.NavigateTo<AdminViewModel>();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                });
        }
    }
}