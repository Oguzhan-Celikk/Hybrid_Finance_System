using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class Anomaly
{
    public Guid AnomalyId { get; set; }

    public Guid UserId { get; set; }

    public Guid TransactionId { get; set; }

    public string AnomalyType { get; set; } = null!;

    public decimal AnomalyScore { get; set; }

    public string Description { get; set; } = null!;

    public string ModelVersion { get; set; } = null!;

    public bool? IsConfirmed { get; set; }

    public string? UserFeedback { get; set; }

    public DateTime DetectedAt { get; set; }

    public DateTime? ReviewedAt { get; set; }

    public virtual Transaction Transaction { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
