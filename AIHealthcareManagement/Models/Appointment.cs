using System;
using System.Collections.Generic;

namespace AIHealthcareManagement.Models;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public int PatientId { get; set; }

    public int DoctorId { get; set; }

    public DateOnly AppointmentDate { get; set; }

    public TimeOnly AppointmentTime { get; set; }

    public string Status { get; set; } = null!;

    public string? ReasonForVisit { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();

    public virtual Patient Patient { get; set; } = null!;

    public virtual ICollection<Reminder> Reminders { get; set; } = new List<Reminder>();
}
