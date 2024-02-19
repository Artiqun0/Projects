using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendYol.Models;
public class User
{
    [Key]
    public int UserId { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string SecretWord { get; set; }
    [Required]
    public double Balance { get; set; }
    public ICollection<Order> Orders { get; set; }
    public ICollection<Product> Products { get; set; }


}
