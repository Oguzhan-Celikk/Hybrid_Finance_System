using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class Transaction
{
    public Guid TransactionId { get; set; }

    public Guid UserId { get; set; }

    public Guid AccountId { get; set; }

    public int? CategoryId { get; set; }

    public Guid? IncomeSourceId { get; set; }

    public Guid? BillId { get; set; }

    public Guid? ReceiptId { get; set; }

    public Guid? RecurringRuleId { get; set; }

    public decimal Amount { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public decimal ExchangeRate { get; set; }

    public decimal AmountInBase { get; set; }

    public string Type { get; set; } = null!;

    public byte[]? DescriptionEncrypted { get; set; }

    public string? MerchantName { get; set; }

    public string Source { get; set; } = null!;

    public string? RawSourceText { get; set; }

    public bool IsVerified { get; set; }

    public bool IsAnomaly { get; set; }

    public bool IsDuplicate { get; set; }

    public Guid? DuplicateOf { get; set; }

    public DateOnly TransactionDate { get; set; }

    public DateTime? TransactionTime { get; set; }

    public short KeyVersion { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<Anomaly> Anomalies { get; set; } = new List<Anomaly>();

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    public virtual Category? Category { get; set; }

    public virtual Transaction? DuplicateOfNavigation { get; set; }

    public virtual ICollection<GoalContribution> GoalContributions { get; set; } = new List<GoalContribution>();

    public virtual IncomeSource? IncomeSource { get; set; }

    public virtual ICollection<Transaction> InverseDuplicateOfNavigation { get; set; } = new List<Transaction>();

    public virtual EncryptionKeyVersion KeyVersionNavigation { get; set; } = null!;

    public virtual ICollection<PersonalInflation> PersonalInflations { get; set; } = new List<PersonalInflation>();

    public virtual Receipt? Receipt { get; set; }

    public virtual RecurringRule? RecurringRule { get; set; }

    public virtual ICollection<TaxEvent> TaxEvents { get; set; } = new List<TaxEvent>();

    public virtual ICollection<TransactionTag> TransactionTags { get; set; } = new List<TransactionTag>();

    public virtual User User { get; set; } = null!;
}
