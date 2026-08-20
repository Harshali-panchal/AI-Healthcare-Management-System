using System;
using System.Collections.Generic;

namespace AIHealthcareManagement.Models;

public partial class Reminder
{
    public int ReminderId { get; set; }

    public int PatientId { get; set; }

    public string ReminderType { get; set; } = null!;

    public string Message { get; set; } = null!;

    public DateTime ReminderDateTime { get; set; }

    public int? RelatedAppointmentId { get; set; }

    public int? RelatedPrescriptionId { get; set; }

    public bool IsSent { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Patient Patient { get; set; } = null!;

    public virtual Appointment? RelatedAppointment { get; set; }

    public virtual Prescription? RelatedPrescription { get; set; }
}
