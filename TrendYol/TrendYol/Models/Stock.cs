using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendYol.Models;
public class Stock
{
    [Key]
    public int Id { get; set; }
    
    [ForeignKey("Product")]
    public int ProductId { get; set; }

    public int ProductCount {  get; set; }


}

