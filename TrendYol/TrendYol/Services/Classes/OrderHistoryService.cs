using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendYol.Context;
using TrendYol.Models;

namespace TrendYol.Services.Classes;
public class OrderHistoryService
    {
    private readonly TrendyolDbContext _dbContext;

    public OrderHistoryService(TrendyolDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    //public List<Orders> GetOrdersForUser(int userId)
    //{
    //    return _dbContext.Products
    //        .Include(oi => oi.Product)
    //        .Where(o => o.UserId == userId)
    //        .ToList();
    //}
}

