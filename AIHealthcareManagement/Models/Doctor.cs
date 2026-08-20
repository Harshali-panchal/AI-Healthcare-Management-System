using System;
using System.Collections.Generic;

namespace AIHealthcareManagement.Models;

public partial class Doctor
{
    public int DoctorId { get; set; }

    public int UserId { get; set; }

    public string FullName { get; set; } = null!;

    public string Specialization { get; set; } = null!;

    public string? Qualification { get; set; }

    public string? LicenseNumber { get; set; }

    public int? YearsOfExperience { get; set; }

    public decimal? ConsultationFee { get; set; }

    public bool IsVerified { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<DoctorAvailability> DoctorAvailabilities { get; set; } = new List<DoctorAvailability>();

    public virtual ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();

    public virtual User User { get; set; } = null!;
}
