using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class ReportDefinition
{
    public Guid ReportDefId { get; set; }

    public Guid? UserId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string ReportType { get; set; } = null!;

    public string OutputFormat { get; set; } = null!;

    public string Parameters { get; set; } = null!;

    public bool IsSystem { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<GeneratedReport> GeneratedReports { get; set; } = new List<GeneratedReport>();

    public virtual User? User { get; set; }
}
