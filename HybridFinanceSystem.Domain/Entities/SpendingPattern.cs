using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class SpendingPattern
{
    public Guid PatternId { get; set; }

    public Guid UserId { get; set; }

    public int? CategoryId { get; set; }

    public string PeriodType { get; set; } = null!;

    public byte? DayOfWeek { get; set; }

    public byte? HourOfDay { get; set; }

    public decimal AvgAmount { get; set; }

    public decimal StddevAmount { get; set; }

    public decimal MedianAmount { get; set; }

    public decimal P95Amount { get; set; }

    public string? TypicalMerchants { get; set; }

    public string? TypicalHours { get; set; }

    public int SampleCount { get; set; }

    public decimal ConfidenceScore { get; set; }

    public string ModelVersion { get; set; } = null!;

    public DateOnly CalculatedFrom { get; set; }

    public DateOnly CalculatedTo { get; set; }

    public DateTime LastUpdatedAt { get; set; }

    public virtual Category? Category { get; set; }

    public virtual User User { get; set; } = null!;
}
