using System;
using System.Collections.Generic;

namespace AIHealthcareManagement.Models;

public partial class Notification
{
    public int NotificationId { get; set; }

    public int UserId { get; set; }

    public string Message { get; set; } = null!;

    public string Channel { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime? SentAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
