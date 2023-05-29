using System;
using System.Collections.Generic;

namespace SmartStock.Domain.Entities;

public partial class Order
{
    public int Id { get; set; }

    public int Status { get; set; }

    public int CompanyId { get; set; }

    public double TotalPrice { get; set; }

    public string RemetentAddress { get; set; } = null!;

    public string RecipientAddress { get; set; } = null!;

    public string? RecipientComplement { get; set; }

    public int? RecipientPhoneNumber { get; set; }

    public string? RecipientEmail { get; set; }

    public bool Deleted { get; set; }

    public DateTime? DeletedDate { get; set; }

    public int? UserDeletedId { get; set; }

    public DateTime CreationDate { get; set; }

    public int UserCreationId { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? UserModifiedId { get; set; }

    public DateTime? OrderCompletionDate { get; set; }

    public int? UserCompletionId { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
