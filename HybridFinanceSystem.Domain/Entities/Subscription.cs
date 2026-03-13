using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class Subscription
{
    public Guid SubscriptionId { get; set; }

    public Guid UserId { get; set; }

    public Guid? RecurringRuleId { get; set; }

    public string ServiceName { get; set; } = null!;

    public int? CategoryId { get; set; }

    public decimal MonthlyCost { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public short? BillingDay { get; set; }

    public string DetectionMethod { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateOnly? LastChargeDate { get; set; }

    public DateOnly? NextChargeDate { get; set; }

    public DateTime DetectedAt { get; set; }

    public virtual Category? Category { get; set; }

    public virtual RecurringRule? RecurringRule { get; set; }

    public virtual User User { get; set; } = null!;
}
