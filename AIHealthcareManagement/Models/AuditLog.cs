using System;
using System.Collections.Generic;

namespace AIHealthcareManagement.Models;

public partial class AuditLog
{
    public int LogId { get; set; }

    public int? UserId { get; set; }

    public string Action { get; set; } = null!;

    public string? EntityName { get; set; }

    public int? EntityId { get; set; }

    public string? Ipaddress { get; set; }

    public DateTime Timestamp { get; set; }

    public virtual User? User { get; set; }
}
