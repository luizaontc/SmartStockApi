using SmartStock.Domain.Models;
using System;
using System.Collections.Generic;

namespace SmartStock.Domain.Entities;

public partial class User : Base
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Document { get; set; } = null!;

    public string? UserImage { get; set; }

    public string Email { get; set; } = null!;

    public string? Name { get; set; }

    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

    public virtual ICollection<UsersCompany> UsersCompanies { get; set; } = new List<UsersCompany>();
}
