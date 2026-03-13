using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class Receipt
{
    public Guid ReceiptId { get; set; }

    public Guid UserId { get; set; }

    public byte[]? ImagePathEncrypted { get; set; }

    public string? ImageHash { get; set; }

    public string? OcrRawText { get; set; }

    public decimal? OcrConfidence { get; set; }

    public string? MerchantName { get; set; }

    public decimal? TotalAmount { get; set; }

    public string? CurrencyCode { get; set; }

    public DateOnly? ReceiptDate { get; set; }

    public string? ReceiptItems { get; set; }

    public string Source { get; set; } = null!;

    public string ProcessingStatus { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual User User { get; set; } = null!;
}
