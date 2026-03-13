using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class PriceHistory
{
    public long PriceId { get; set; }

    public string Symbol { get; set; } = null!;

    public string AssetType { get; set; } = null!;

    public DateOnly PriceDate { get; set; }

    public decimal? OpenPrice { get; set; }

    public decimal? HighPrice { get; set; }

    public decimal? LowPrice { get; set; }

    public decimal ClosePrice { get; set; }

    public decimal? Volume { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public string Source { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}
