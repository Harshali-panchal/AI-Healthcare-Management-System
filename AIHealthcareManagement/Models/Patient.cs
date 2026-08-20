using System;
using System.Collections.Generic;

namespace AIHealthcareManagement.Models;

public partial class Patient
{
    public int PatientId { get; set; }

    public int UserId { get; set; }

    public string FullName { get; set; } = null!;

    public DateOnly? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public string? BloodGroup { get; set; }

    public string? Address { get; set; }

    public string? Allergies { get; set; }

    public string? ChronicConditions { get; set; }

    public string? EmergencyContactName { get; set; }

    public string? EmergencyContactPhone { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<AisymptomAssessment> AisymptomAssessments { get; set; } = new List<AisymptomAssessment>();

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();

    public virtual ICollection<Reminder> Reminders { get; set; } = new List<Reminder>();

    public virtual User? User { get; set; }
}
