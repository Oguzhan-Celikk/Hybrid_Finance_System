using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class Bill
{
    public Guid BillId { get; set; }

    public Guid UserId { get; set; }

    public Guid? AccountId { get; set; }

    public string Name { get; set; } = null!;

    public string? ProviderName { get; set; }

    public string BillType { get; set; } = null!;

    public decimal? EstimatedAmount { get; set; }

    public decimal? ActualAmount { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public byte? BillingCycleDay { get; set; }

    public byte DueDay { get; set; }

    public DateOnly? DueDate { get; set; }

    public string Status { get; set; } = null!;

    public Guid? PaymentTransactionId { get; set; }

    public decimal? LateFeeRate { get; set; }

    public byte ReminderDaysBefore { get; set; }

    public bool IsActive { get; set; }

    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Account? Account { get; set; }

    public virtual Transaction? PaymentTransaction { get; set; }

    public virtual User User { get; set; } = null!;
}
