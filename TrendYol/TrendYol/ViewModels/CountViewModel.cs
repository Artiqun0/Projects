using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TrendYol.Context;
using TrendYol.Models;
using TrendYol.Services.Classes;
using TrendYol.Services.Interfaces;

namespace TrendYol.ViewModels
{
    public class CountViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly TrendyolDbContext _context;
        private readonly CurrentUserService _currentUserService;
        private Product _selectedProduct;
        private int _count;
        private string _product;

        public int Count
        {
            get => _count;
            set => Set(ref _count, value);
        }

        public string Product
        {
            get => _product;
            set => Set(ref _product, value);
        }

        public Product SelectedProduct
        {
            get => _selectedProduct;
            set => Set(ref _selectedProduct, value);
        }

        public CountViewModel(INavigationService navigationService, TrendyolDbContext context, CurrentUserService currentUserService)
        {
            _navigationService = navigationService;
            _context = context;
            _currentUserService = currentUserService;
            _selectedProduct = new Product();
            Messenger.Default.Register<string>(this, "SelectedProductName", SetSelectedProductName);
            Messenger.Default.Register<int>(this, "SelectedProductCount", SetSelectedProductCount);
            Messenger.Default.Register<Product>(this, "SelectedProductForOrder", SetSelectedProduct);
        }

        private void SetSelectedProductCount(int count)
        {
            Count = count;
        }

        private void SetSelectedProductName(string productName)
        {
            Product = productName;
        }

        private void SetSelectedProduct(Product selectedProduct)
        {
            SelectedProduct = selectedProduct;
            _selectedProduct = selectedProduct;
        }

        public RelayCommand Back
        {
            get => new(
                () =>
                {
                    _navigationService.NavigateTo<HomePageViewModel>();
                });
        }

        public RelayCommand AddOrder
        {
            get => new(
                () =>
                {
                    try
                    {
                        int currentId = _currentUserService.UserId;
                        if (_selectedProduct != null)
                        {
                            var wareHouseProduct = _context.Stock.FirstOrDefault(p => p.ProductId == _selectedProduct.Id);
                            if (wareHouseProduct != null)
                            {
                                if (wareHouseProduct.ProductId < Count)
                                {
                                    MessageBox.Show("not so namy product in Stock.");
                                    _navigationService.NavigateTo<ShopViewModel>();
                                    return;
                                }
                                else if (Count == 0)
                                {
                                    MessageBox.Show("Input product count", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                    return;
                                }

                            }

                            if (_selectedProduct.Count == 0)
                            {
                                _context.Products.Remove(_selectedProduct);
                                _context.SaveChanges();
                            }


                            Order order = new Order
                            {
                                UserId = currentId,
                                Product = _selectedProduct.Name,
                                ProductsCount = Count,
                                ProductId = _selectedProduct.Id,
                                Status = "Order ready",
                                Created = DateTime.Now,
                            };
                            _context.Order.Add(order);
                            _context.SaveChanges();
                            var user = _context.User.FirstOrDefault(u => u.UserId == _currentUserService.UserId);
                            _context.SaveChanges();
                            wareHouseProduct.ProductCount -= Count;
                            _context.SaveChanges();
                            _selectedProduct.Count -= Count;
                            _context.SaveChanges();
                            MessageBox.Show("Successfuly order", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                            Count = 0;
                            _navigationService.NavigateTo<HomePageViewModel>();

                        }
                        else
                        {
                            MessageBox.Show("Somthing wrong. Failed");
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                });
        }
    }
}
