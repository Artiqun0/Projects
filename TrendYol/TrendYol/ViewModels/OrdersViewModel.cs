using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendYol.Context;
using TrendYol.Models;

namespace TrendYol.ViewModels;
    public class OrdersViewModel : ViewModelBase
    {
    public ObservableCollection<Order> Orders { get; set; }

    public OrdersViewModel()
    {
        LoadOrders();
    }

    private void LoadOrders()
    {
        Orders = new ObservableCollection<Order>();

        using (var context = new TrendyolDbContext())
        {
            //var ordersFromDb = context.Orders.Include(o => o.Product).ToList();

            //foreach (var order in ordersFromDb)
            //{
            //    Orders.Add(order);
            //}
        }
    }
}

