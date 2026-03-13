using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class Watchlist
{
    public Guid WatchlistId { get; set; }

    public Guid UserId { get; set; }

    public string Symbol { get; set; } = null!;

    public string AssetType { get; set; } = null!;

    public decimal? AlertPriceAbove { get; set; }

    public decimal? AlertPriceBelow { get; set; }

    public string? Notes { get; set; }

    public DateTime AddedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
