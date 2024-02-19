using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendYol.Context;
using TrendYol.Models;

namespace TrendYol.Services.Classes
{
    public class OrderService
    {
        private readonly TrendyolDbContext _context;

        public OrderService(TrendyolDbContext context)
        {
            _context = context;
        }

        public Product AddProductOrder(string name, string description, double price, int count, byte[] image)
        {
            Product productsForOrder = new Product()
            {
                Name = name,
                Description = description,
                Price = price,
                Count = count,
                Image = image
            };
            return productsForOrder;
        }
    }
}
