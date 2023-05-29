using System;
using System.Collections.Generic;

namespace SmartStock.Domain.Entities;

public partial class OrderDetail
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public string ProductName { get; set; } = null!;

    public int Quantity { get; set; }

    public double Price { get; set; }

    public int CompanyId { get; set; }

    public bool Deleted { get; set; }

    public DateTime? DeletedDate { get; set; }

    public int? UserDeletedId { get; set; }

    public DateTime CreationDate { get; set; }

    public int UserCreationId { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? UserModifiedId { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
