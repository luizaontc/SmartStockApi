using SmartStock.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SmartStock.Domain.Entities;

public partial class OrderDetail : Base
{
    public int Id { get; set; }

    public int OrderId { get; set; }
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int Quantity { get; set; }

    public double Price { get; set; }

    public int CompanyId { get; set; }
    [JsonIgnore]
    public virtual Company Company { get; set; }
    [JsonIgnore]
    public virtual Order Order { get; set; }

    public override void SetCreationDate()
    {
        base.SetCreationDate();
    }
}
