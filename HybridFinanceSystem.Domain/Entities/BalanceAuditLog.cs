using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HybridFinanceSystem.Domain.Common;


namespace HybridFinanceSystem.Domain.Entities;

[Table("BalanceAuditLogs")]
public class BalanceAuditLog
{
    [Key]
    public long Audit_ID { get; set; }

    public int Asset_ID { get; set; }

    public long? Transaction_ID { get; set; } // Bazı değişimler bir işleme bağlı olmayabilir

    [Column(TypeName = "decimal(18, 4)")]
    public decimal OldBalance { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal NewBalance { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal ChangeAmount { get; set; }

    [Required, StringLength(50)]
    public string ActionType { get; set; } = string.Empty; // 'TRANSACTION', 'MANUAL_ADJUSTMENT' vb.

    public DateTime ChangedAt { get; set; } = DateTime.Now;

    // --- Navigation Properties ---
    [ForeignKey("Asset_ID")]
    public Asset Asset { get; set; } = null!;

    [ForeignKey("Transaction_ID")]
    public Transaction? Transaction { get; set; }
}