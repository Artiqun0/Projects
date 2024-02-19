using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace TrendYol.Models;
public class Product
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(30), RegularExpression("^[A-Z][a-z]+$")]
    public string Name { get; set; }
    [Required, MaxLength(255)]
    public string Description { get; set; }
    [Required]
    public int Count { get; set; }
    [Required]
    public double Price {  get; set; }
    [Required]
    public byte[] Image {  get; set; }

}

