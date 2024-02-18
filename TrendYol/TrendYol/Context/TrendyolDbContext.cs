using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendYol.Models;
using Microsoft.Extensions.Configuration;
namespace TrendYol.Context;
public     class TrendyolDbContext : DbContext
    {
    public DbSet<User> User { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Stock> Stock { get; set; }
    public DbSet<Orders> Order { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source = localhost; Initial Catalog = TrendYolDb; Integrated Security = True; Pooling = true; Trust Server Certificate = true;");
    }

}

