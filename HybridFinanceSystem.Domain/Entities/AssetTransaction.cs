using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class AssetTransaction
{
    public Guid AssetTxId { get; set; }

    public Guid AssetId { get; set; }

    public Guid UserId { get; set; }

    public string TransactionType { get; set; } = null!;

    public decimal Quantity { get; set; }

    public decimal PricePerUnit { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public decimal ExchangeRateToTry { get; set; }

    public decimal TotalAmount { get; set; }

    public decimal TotalAmountTry { get; set; }

    public decimal Commission { get; set; }

    public string CommissionCurrency { get; set; } = null!;

    public byte[]? NotesEncrypted { get; set; }

    public Guid? TaxEventId { get; set; }

    public DateTime TransactionDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Asset Asset { get; set; } = null!;

    public virtual TaxEvent? TaxEvent { get; set; }

    public virtual ICollection<TaxEvent> TaxEvents { get; set; } = new List<TaxEvent>();

    public virtual User User { get; set; } = null!;
}
