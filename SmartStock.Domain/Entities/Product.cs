using SmartStock.Domain.Models;
using System;
using System.Collections.Generic;

namespace SmartStock.Domain.Entities;

public partial class Product : Base
{
    public int Id { get; set; }

    public string ProductName { get; set; } = null!;

    public int Quantity { get; set; }

    public double Price { get; set; }

    public int CompanyId { get; set; }

    public virtual Company? Company { get; set; }
}
