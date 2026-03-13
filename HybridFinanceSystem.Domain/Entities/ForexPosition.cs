using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class ForexPosition
{
    public Guid PositionId { get; set; }

    public Guid UserId { get; set; }

    public Guid AccountId { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public string BaseCurrency { get; set; } = null!;

    public decimal Quantity { get; set; }

    public decimal AverageBuyRate { get; set; }

    public decimal TotalCostBase { get; set; }

    public decimal RealizedPnl { get; set; }

    public decimal? CurrentRate { get; set; }

    public decimal? CurrentValueBase { get; set; }

    public decimal? UnrealizedPnl { get; set; }

    public decimal? UnrealizedPnlPct { get; set; }

    public string PositionType { get; set; } = null!;

    public DateTime? LastUpdatedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();

    public virtual User User { get; set; } = null!;
}
