using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class GoalContribution
{
    public Guid ContributionId { get; set; }

    public Guid GoalId { get; set; }

    public Guid? TransactionId { get; set; }

    public decimal Amount { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public string? Note { get; set; }

    public DateTime ContributedAt { get; set; }

    public virtual SavingGoal Goal { get; set; } = null!;

    public virtual Transaction? Transaction { get; set; }
}
