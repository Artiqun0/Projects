﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
}

