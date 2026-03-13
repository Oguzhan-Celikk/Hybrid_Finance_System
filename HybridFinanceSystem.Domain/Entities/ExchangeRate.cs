using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class ExchangeRate
{
    public long RateId { get; set; }

    public string FromCurrency { get; set; } = null!;

    public string ToCurrency { get; set; } = null!;

    public decimal Rate { get; set; }

    public DateOnly RateDate { get; set; }

    public string Source { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}
