using System;
using System.Collections.Generic;

namespace SmartStock.Domain.Entities;

public partial class UsersCompany
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? CompanyId { get; set; }

    public virtual Company? Company { get; set; }

    public virtual User? User { get; set; }
}
