using System;
using System.Collections.Generic;

namespace AIHealthcareManagement.Models;

public partial class MedicalRecord
{
    public int RecordId { get; set; }

    public int PatientId { get; set; }

    public int DoctorId { get; set; }

    public int? AppointmentId { get; set; }

    public string? Diagnosis { get; set; }

    public string? ConsultationNotes { get; set; }

    public DateTime RecordDate { get; set; }

    public virtual Appointment? Appointment { get; set; }

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual Patient Patient { get; set; } = null!;

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}
