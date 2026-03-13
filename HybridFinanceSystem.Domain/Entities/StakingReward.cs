using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class StakingReward
{
    public Guid RewardId { get; set; }

    public Guid AssetId { get; set; }

    public Guid UserId { get; set; }

    public string RewardType { get; set; } = null!;

    public string RewardSymbol { get; set; } = null!;

    public decimal Quantity { get; set; }

    public decimal? PriceAtReward { get; set; }

    public decimal? ValueTry { get; set; }

    public string? Platform { get; set; }

    public decimal? ApyRate { get; set; }

    public DateOnly RewardDate { get; set; }

    public bool IsAutoCompound { get; set; }

    public string? TxHash { get; set; }

    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Asset Asset { get; set; } = null!;

    public virtual ICollection<TaxEvent> TaxEvents { get; set; } = new List<TaxEvent>();

    public virtual User User { get; set; } = null!;
}
