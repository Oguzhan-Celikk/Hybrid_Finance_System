using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class PriceAlert
{
    public Guid AlertId { get; set; }

    public Guid UserId { get; set; }

    public string Symbol { get; set; } = null!;

    public string AssetType { get; set; } = null!;

    public Guid? AssetId { get; set; }

    public string AlertType { get; set; } = null!;

    public decimal ThresholdValue { get; set; }

    public string ThresholdCurrency { get; set; } = null!;

    public decimal? PreAlertPct { get; set; }

    public string NotificationChannel { get; set; } = null!;

    public string? AlertLabel { get; set; }

    public bool IsActive { get; set; }

    public bool IsTriggered { get; set; }

    public DateTime? TriggeredAt { get; set; }

    public decimal? TriggeredPrice { get; set; }

    public int TriggerCount { get; set; }

    public bool AutoReset { get; set; }

    public short? RepeatCount { get; set; }

    public decimal? LastKnownPrice { get; set; }

    public DateTime? LastPriceUpdatedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Asset? Asset { get; set; }

    public virtual User User { get; set; } = null!;
}
