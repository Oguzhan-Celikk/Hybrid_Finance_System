using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HybridFinanceSystem.Domain.Common;


namespace HybridFinanceSystem.Domain.Entities;

[Table("Transactions")]
public class Transaction : BaseEntity
{
    public Transaction()
    {
        AnomalyLogs = new HashSet<AnomalyLog>();
        BalanceAuditLogs = new HashSet<BalanceAuditLog>();
        Attachments = new HashSet<TransactionAttachment>();
    }

    [Key]
    public long Transaction_ID { get; set; }

    public int Users_ID { get; set; }
    public int Asset_ID { get; set; }
    public int Category_ID { get; set; }
    public int? Merchant_ID { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal Amount { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal? LocalAmount { get; set; }

    public string? Description { get; set; }

    public DateTime TransactionDate { get; set; }

    public byte SourceType { get; set; } = 0;

    public bool IsAnomaly { get; set; } = false;

    // --- Navigation Properties ---
    [ForeignKey("Users_ID")]
    public User User { get; set; } = null!;

    [ForeignKey("Asset_ID")]
    public Asset Asset { get; set; } = null!;

    [ForeignKey("Category_ID")]
    public Category Category { get; set; } = null!;

    [ForeignKey("Merchant_ID")]
    public Merchant? Merchant { get; set; }

    public ICollection<AnomalyLog> AnomalyLogs { get; set; }
    public ICollection<BalanceAuditLog> BalanceAuditLogs { get; set; }
    public ICollection<TransactionAttachment> Attachments { get; set; }
}