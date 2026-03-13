using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class TaxEvent
{
    public Guid TaxEventId { get; set; }

    public Guid UserId { get; set; }

    public Guid? AssetTxId { get; set; }

    public Guid? TransactionId { get; set; }

    public Guid? StakingRewardId { get; set; }

    public string TaxEventType { get; set; } = null!;

    public string Jurisdiction { get; set; } = null!;

    public decimal CostBasis { get; set; }

    public decimal Proceeds { get; set; }

    public decimal? GrossGainLoss { get; set; }

    public int? HoldingDays { get; set; }

    public bool IsTaxExempt { get; set; }

    public decimal? TaxRate { get; set; }

    public decimal WithholdingTax { get; set; }

    public decimal? EstimatedTax { get; set; }

    public DateOnly EventDate { get; set; }

    public short? TaxYear { get; set; }

    public string Status { get; set; } = null!;

    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<AssetTransaction> AssetTransactions { get; set; } = new List<AssetTransaction>();

    public virtual AssetTransaction? AssetTx { get; set; }

    public virtual StakingReward? StakingReward { get; set; }

    public virtual Transaction? Transaction { get; set; }

    public virtual User User { get; set; } = null!;
}
