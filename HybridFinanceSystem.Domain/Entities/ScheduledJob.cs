using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class ScheduledJob
{
    public Guid JobId { get; set; }

    public Guid? UserId { get; set; }

    public string JobType { get; set; } = null!;

    public string? CronExpression { get; set; }

    public string? Parameters { get; set; }

    public bool IsActive { get; set; }

    public DateTime? LastRunAt { get; set; }

    public string? LastRunStatus { get; set; }

    public DateTime? NextRunAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual User? User { get; set; }
}
