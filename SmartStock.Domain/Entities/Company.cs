using System;
using System.Collections.Generic;

namespace SmartStock.Domain.Entities;

public partial class Company
{
    public int Id { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? CompanyLogo { get; set; }

    public string? Email { get; set; }

    public string Address { get; set; } = null!;

    public string? Complement { get; set; }

    public string Cnpj { get; set; } = null!;

    public int? PhoneNumber { get; set; }

    public bool Deleted { get; set; }

    public DateTime? DeletedDate { get; set; }

    public int? UserDeletedId { get; set; }

    public DateTime CreationDate { get; set; }

    public int UserCreationId { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? UserModifiedId { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<UsersCompany> UsersCompanies { get; set; } = new List<UsersCompany>();
}
