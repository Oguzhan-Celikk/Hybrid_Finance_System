using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class Asset
{
    public Guid AssetId { get; set; }

    public Guid UserId { get; set; }

    public string Symbol { get; set; } = null!;

    public string AssetType { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Exchange { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public decimal Quantity { get; set; }

    public decimal AverageCost { get; set; }

    public decimal TotalCost { get; set; }

    public decimal? CurrentPrice { get; set; }

    public decimal? CurrentValue { get; set; }

    public decimal? UnrealizedPnl { get; set; }

    public decimal? UnrealizedPnlPct { get; set; }

    public DateTime? PriceUpdatedAt { get; set; }

    public Guid? ForexPositionId { get; set; }

    public bool IsActive { get; set; }

    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<AssetTransaction> AssetTransactions { get; set; } = new List<AssetTransaction>();

    public virtual ForexPosition? ForexPosition { get; set; }

    public virtual ICollection<PriceAlert> PriceAlerts { get; set; } = new List<PriceAlert>();

    public virtual ICollection<StakingReward> StakingRewards { get; set; } = new List<StakingReward>();

    public virtual User User { get; set; } = null!;
}
