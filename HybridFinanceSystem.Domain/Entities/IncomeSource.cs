using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class IncomeSource
{
    public Guid SourceId { get; set; }

    public Guid UserId { get; set; }

    public string Name { get; set; } = null!;

    public string IncomeType { get; set; } = null!;

    public bool IsTaxable { get; set; }

    public string? TaxCategory { get; set; }

    public decimal? WithholdingRate { get; set; }

    public bool IsRecurring { get; set; }

    public string? Frequency { get; set; }

    public decimal? ExpectedAmount { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public string? EmployerName { get; set; }

    public string? EmployerTaxId { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public bool IsActive { get; set; }

    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual User User { get; set; } = null!;
}
