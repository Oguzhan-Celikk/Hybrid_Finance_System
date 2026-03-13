using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class PortfolioSnapshot
{
    public Guid SnapshotId { get; set; }

    public Guid UserId { get; set; }

    public DateOnly SnapshotDate { get; set; }

    public string SnapshotType { get; set; } = null!;

    public decimal TotalValueTry { get; set; }

    public decimal TotalCostTry { get; set; }

    public decimal TotalPnlTry { get; set; }

    public decimal TotalPnlPct { get; set; }

    public string AssetBreakdown { get; set; } = null!;

    public string PositionsSnapshot { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
