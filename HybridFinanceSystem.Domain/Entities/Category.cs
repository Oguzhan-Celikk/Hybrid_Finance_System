using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class Category
{
    public int CategoryId { get; set; }

    public Guid? UserId { get; set; }

    public int? ParentCategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string? Icon { get; set; }

    public string? ColorHex { get; set; }

    public bool IsSystem { get; set; }

    public bool IsActive { get; set; }

    public short SortOrder { get; set; }

    public virtual ICollection<Budget> Budgets { get; set; } = new List<Budget>();

    public virtual ICollection<Category> InverseParentCategory { get; set; } = new List<Category>();

    public virtual Category? ParentCategory { get; set; }

    public virtual ICollection<RecurringRule> RecurringRules { get; set; } = new List<RecurringRule>();

    public virtual ICollection<SpendingPattern> SpendingPatterns { get; set; } = new List<SpendingPattern>();

    public virtual ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual User? User { get; set; }
}
