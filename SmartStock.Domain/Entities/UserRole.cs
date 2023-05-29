using System;
using System.Collections.Generic;

namespace SmartStock.Domain.Entities;

public partial class UserRole
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int Role { get; set; }

    public bool Deleted { get; set; }

    public DateTime? DeletedDate { get; set; }

    public int? UserDeletedId { get; set; }

    public DateTime CreationDate { get; set; }

    public int UserCreationId { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public int? UserModifiedId { get; set; }

    public virtual Role RoleNavigation { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
