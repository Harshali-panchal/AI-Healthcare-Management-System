using System;
using System.Collections.Generic;

namespace AIHealthcareManagement.Models;

public partial class AisymptomAssessment
{
    public int AssessmentId { get; set; }

    public int PatientId { get; set; }

    public string SymptomsInput { get; set; } = null!;

    public string? AiresultSummary { get; set; }

    public string? UrgencyLevel { get; set; }

    public decimal? ConfidenceScore { get; set; }

    public string? ModelVersion { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Patient Patient { get; set; } = null!;
}
