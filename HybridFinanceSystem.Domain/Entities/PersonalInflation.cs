using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class PersonalInflation
{
    public Guid InflationId { get; set; }

    public Guid UserId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? Barcode { get; set; }

    public string? Unit { get; set; }

    public decimal Price { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public DateOnly PurchaseDate { get; set; }

    public string? MerchantName { get; set; }

    public Guid? TransactionId { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Transaction? Transaction { get; set; }

    public virtual User User { get; set; } = null!;
}
