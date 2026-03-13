using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class SavingGoal
{
    public Guid GoalId { get; set; }

    public Guid UserId { get; set; }

    public Guid? AccountId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal TargetAmount { get; set; }

    public decimal CurrentAmount { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly TargetDate { get; set; }

    public decimal? MonthlyContribution { get; set; }

    public byte Priority { get; set; }

    public string Status { get; set; } = null!;

    public string? Icon { get; set; }

    public string? ColorHex { get; set; }

    public DateTime? CompletedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Account? Account { get; set; }

    public virtual ICollection<GoalContribution> GoalContributions { get; set; } = new List<GoalContribution>();

    public virtual User User { get; set; } = null!;
}
