using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class GeneratedReport
{
    public Guid ReportId { get; set; }

    public Guid UserId { get; set; }

    public Guid ReportDefId { get; set; }

    public string Title { get; set; } = null!;

    public DateOnly PeriodStart { get; set; }

    public DateOnly PeriodEnd { get; set; }

    public byte[]? FilePathEncrypted { get; set; }

    public int? FileSizeBytes { get; set; }

    public string OutputFormat { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime? GeneratedAt { get; set; }

    public DateTime? ExpiresAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ReportDefinition ReportDef { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
