using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class RecurringRule
{
    public Guid RuleId { get; set; }

    public Guid UserId { get; set; }

    public Guid AccountId { get; set; }

    public int? CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Amount { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Frequency { get; set; } = null!;

    public short FrequencyInterval { get; set; }

    public DateOnly NextDueDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public bool IsActive { get; set; }

    public bool AutoCreate { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Category? Category { get; set; }

    public virtual ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual User User { get; set; } = null!;
}
