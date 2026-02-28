using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HybridFinanceSystem.Domain.Common;


namespace HybridFinanceSystem.Domain.Entities;

[Table("Assets")]
public class Asset 
{
    public Asset()
    {
        Transactions = new HashSet<Transaction>();
        BalanceAuditLogs = new HashSet<BalanceAuditLog>();
        InvestmentIncomes = new HashSet<InvestmentIncome>();
        ScheduledTransactions = new HashSet<ScheduledTransaction>();
    }

    [Key]
    public int Asset_ID { get; set; }

    public int Users_ID { get; set; }

    [Required, StringLength(100)]
    public string AssetName { get; set; } = string.Empty;

    [StringLength(3)]
    public string CurrencyCode { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18, 4)")]
    public decimal Balance { get; set; } = 0;

    public bool IsDeleted { get; set; } = false;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // --- Navigation Properties ---
    [ForeignKey("Users_ID")]
    public User User { get; set; } = null!;

    [ForeignKey("CurrencyCode")]
    public Currency Currency { get; set; } = null!;

    public ICollection<Transaction> Transactions { get; set; }
    public ICollection<BalanceAuditLog> BalanceAuditLogs { get; set; }
    public ICollection<InvestmentIncome> InvestmentIncomes { get; set; }
    public ICollection<ScheduledTransaction> ScheduledTransactions { get; set; }
}
