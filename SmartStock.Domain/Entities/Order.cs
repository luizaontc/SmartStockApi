
using SmartStock.Domain.Interfaces.Repositories;
using SmartStock.Domain.Models;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace SmartStock.Domain.Entities;

public partial class Order : Base
{
    public int Id { get; set; }

    public int Status { get; set; }

    public int CompanyId { get; set; }

    public double TotalPrice { get; set; }

    public string RemetentAddress { get; set; }

    public string RecipientAddress { get; set; }

    public string? RecipientComplement { get; set; }

    public long? RecipientPhoneNumber { get; set; }

    public string? RecipientEmail { get; set; }

    public DateTime? OrderCompletionDate { get; set; }

    public int? UserCompletionId { get; set; }

    public virtual Company? Company { get; set; }

    public virtual ICollection<OrderDetail>? OrderDetails { get; set; }

}
