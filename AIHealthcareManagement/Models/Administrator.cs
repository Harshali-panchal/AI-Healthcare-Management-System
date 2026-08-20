using System;
using System.Collections.Generic;

namespace AIHealthcareManagement.Models;

public partial class Administrator
{
    public int AdminId { get; set; }

    public int UserId { get; set; }

    public string FullName { get; set; } = null!;

    public string? Department { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
