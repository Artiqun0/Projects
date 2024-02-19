using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendYol.Models;
public class Product
    {
    [Key]
    public int Id { get; set; }
    [Required]
    public string ProductName { get; set; }
    [Required]
    public double ProductPrice { get; set; }
    [Required]
    public string ProductImageURL { get; set; }
    [Required]
    public int Count {  get; set; }
    [Required, ForeignKey("User")]
    public int UserId { get; set; }
    public User Users { get; set; }
    public ICollection<Order> Orders{ get; set; }

}

