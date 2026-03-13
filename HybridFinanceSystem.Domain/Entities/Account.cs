using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class Account
{
    public Guid AccountId { get; set; }

    public Guid UserId { get; set; }

    public string AccountName { get; set; } = null!;

    public string AccountType { get; set; } = null!;

    public string CurrencyCode { get; set; } = null!;

    public decimal Balance { get; set; }

    public DateTime? BalanceUpdatedAt { get; set; }

    public string DataSource { get; set; } = null!;

    public DateTime? LastSyncedAt { get; set; }

    public bool IsDefault { get; set; }

    public string? Icon { get; set; }

    public string? ColorHex { get; set; }

    public bool IsActive { get; set; }

    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    public virtual ICollection<ForexPosition> ForexPositions { get; set; } = new List<ForexPosition>();

    public virtual ICollection<RecurringRule> RecurringRules { get; set; } = new List<RecurringRule>();

    public virtual ICollection<SavingGoal> SavingGoals { get; set; } = new List<SavingGoal>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual User User { get; set; } = null!;
}
