using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using TrendYol.Context;
using TrendYol.Models;
using TrendYol.Services.Interfaces;

namespace TrendYol.ViewModels;
    public class ShopViewModel : ViewModelBase
    {
    private readonly INavigationService _navigationService;
    private readonly TrendyolDbContext _context;
    private ObservableCollection<Product> _products;
    private Product _selectedProducts;

    public ObservableCollection<Product> Product
    {
        get => _products;
        set => Set(ref _products, value);
    }

    public Product SelectedProduct
    {
        get => _selectedProducts;
        set
        {
            if (Set(ref _selectedProducts, value))
            {
                Messenger.Default.Send(value.Name, "SelectedProductName");
            }
        }
    }


    public ShopViewModel(INavigationService navigationService, TrendyolDbContext context)
    {
        _navigationService = navigationService;
        _context = context;
        Product = new ObservableCollection<Product>(_context.Products.ToList());
        MessengerInstance.Register<Product>(this, "SelectedProductName", SetSelectedProductName);
    }

    private void SetSelectedProductName(Product selectedProduct)
    {
        SelectedProduct = selectedProduct;
    }

    public RelayCommand BackToHome
    {
        get => new(
            () =>
            {
                _navigationService.NavigateTo<HomePageViewModel>();
            });
    }

    public RelayCommand Add
    {
        get => new(
            () =>
            {
                try
                {
                    if (SelectedProduct != null)
                    {
                        Messenger.Default.Send(SelectedProduct, "SelectedProductForOrder");
                        _navigationService.NavigateTo<CountViewModel>();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            });
    }
}

