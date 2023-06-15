using SmartStock.Domain.Models;
using System;
using System.Collections.Generic;

namespace SmartStock.Domain.Entities;

public partial class UserRole : Base
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int Role { get; set; }

    public virtual Role RoleNavigation { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
