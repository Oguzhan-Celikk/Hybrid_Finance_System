using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HybridFinanceSystem.Domain.Common;


namespace HybridFinanceSystem.Domain.Entities;

[Table("ScheduledTransactions")]
public class ScheduledTransaction
{
    [Key]
    public int Scheduled_ID { get; set; }

    public int Users_ID { get; set; }

    public int Asset_ID { get; set; }

    public int Category_ID { get; set; }

    public int? Merchant_ID { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal Amount { get; set; }

    [StringLength(20)]
    public string Frequency { get; set; } = "Monthly"; // 'Monthly', 'Weekly' vb.

    public DateTime NextOccurrenceDate { get; set; }

    public bool IsActive { get; set; } = true;

    // --- Navigation Properties ---
    [ForeignKey("Users_ID")]
    public User User { get; set; } = null!;

    [ForeignKey("Asset_ID")]
    public Asset Asset { get; set; } = null!;

    [ForeignKey("Category_ID")]
    public Category Category { get; set; } = null!;

    [ForeignKey("Merchant_ID")]
    public Merchant? Merchant { get; set; }
}