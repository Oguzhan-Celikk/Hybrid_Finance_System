using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class PriceUpdateSchedule
{
    public Guid ScheduleId { get; set; }

    public string Symbol { get; set; } = null!;

    public string AssetType { get; set; } = null!;

    public int UpdateFrequencyMinutes { get; set; }

    public TimeOnly? MarketOpenTime { get; set; }

    public TimeOnly? MarketCloseTime { get; set; }

    public string? MarketTimezone { get; set; }

    public byte ActiveWeekdays { get; set; }

    public string PrimaryApiSource { get; set; } = null!;

    public string? FallbackApiSource { get; set; }

    public bool IsActive { get; set; }

    public DateTime? LastUpdateAt { get; set; }

    public string? LastUpdateStatus { get; set; }

    public byte ConsecutiveFailures { get; set; }

    public DateTime? NextUpdateAt { get; set; }

    public byte MaxRetryCount { get; set; }

    public byte RetryDelayMinutes { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
