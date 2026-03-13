using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class MonthlySummary
{
    public Guid SummaryId { get; set; }

    public Guid UserId { get; set; }

    public short SummaryYear { get; set; }

    public byte SummaryMonth { get; set; }

    public decimal TotalIncome { get; set; }

    public int IncomeCount { get; set; }

    public decimal TotalExpense { get; set; }

    public int ExpenseCount { get; set; }

    public decimal? NetCashflow { get; set; }

    public decimal? SavingsRate { get; set; }

    public decimal TotalTransfer { get; set; }

    public int TransferCount { get; set; }

    public string? TopExpenseCategories { get; set; }

    public string? TopIncomeSources { get; set; }

    public string? AccountBalances { get; set; }

    public byte BudgetsOnTrack { get; set; }

    public byte BudgetsExceeded { get; set; }

    public int AnomalyCount { get; set; }

    public decimal EstimatedTaxLiability { get; set; }

    public bool IsFinalized { get; set; }

    public DateTime LastCalculatedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
