using System;
using System.Collections.Generic;

namespace AIHealthcareManagement.Models;

public partial class DoctorAvailability
{
    public int AvailabilityId { get; set; }

    public int DoctorId { get; set; }

    public byte DayOfWeek { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public bool IsAvailable { get; set; }

    public virtual Doctor Doctor { get; set; } = null!;
}
