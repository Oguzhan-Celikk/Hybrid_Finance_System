using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class Prediction
{
    public Guid PredictionId { get; set; }

    public Guid UserId { get; set; }

    public string PredictionType { get; set; } = null!;

    public DateOnly TargetDate { get; set; }

    public decimal PredictedValue { get; set; }

    public decimal ConfidenceLow { get; set; }

    public decimal ConfidenceHigh { get; set; }

    public decimal ConfidenceScore { get; set; }

    public string ModelVersion { get; set; } = null!;

    public string InputFeatures { get; set; } = null!;

    public decimal? ActualValue { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
