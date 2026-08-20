using System;
using System.Collections.Generic;

namespace AIHealthcareManagement.Models;

public partial class Prescription
{
    public int PrescriptionId { get; set; }

    public int RecordId { get; set; }

    public string MedicineName { get; set; } = null!;

    public string? Dosage { get; set; }

    public string? Frequency { get; set; }

    public int? DurationDays { get; set; }

    public string? Instructions { get; set; }

    public virtual MedicalRecord Record { get; set; } = null!;

    public virtual ICollection<Reminder> Reminders { get; set; } = new List<Reminder>();
}
