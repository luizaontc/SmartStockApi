using System;
using System.Collections.Generic;

namespace SmartStock.Domain.Entities;

public partial class Log
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string? Username { get; set; }

    public string? Action { get; set; }

    public virtual User User { get; set; } = null!;
}
