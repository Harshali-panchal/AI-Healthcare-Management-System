using System;
using System.Collections.Generic;

namespace AIHealthcareManagement.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? SecurityStamp { get; set; }

    public string? PhoneNumber { get; set; }

    public int RoleId { get; set; }

    public bool IsActive { get; set; }

    public bool IsEmailVerified { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? LastLoginAt { get; set; }

    public virtual Administrator? Administrator { get; set; }

    public virtual ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();

    public virtual Doctor? Doctor { get; set; }

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual Patient? Patient { get; set; }

    public virtual Role Role { get; set; } = null!;
}
