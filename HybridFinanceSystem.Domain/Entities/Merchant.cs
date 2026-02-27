using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HybridFinanceSystem.Domain.Common;


namespace HybridFinanceSystem.Domain.Entities;

[Table("Merchants")]
public class Merchant
{
    public Merchant()
    {
        Transactions = new HashSet<Transaction>();
        ScheduledTransactions = new HashSet<ScheduledTransaction>();
    }

    [Key]
    public int Merchant_ID { get; set; }

    [Required, StringLength(200)]
    public string MerchantName { get; set; } = string.Empty;

    public int MainCategory_ID { get; set; }

    public bool IsSubscriptionProvider { get; set; } = false;

    // Navigation Properties
    [ForeignKey("MainCategory_ID")]
    public Category Category { get; set; } = null!; // Bu mutlaka dolu gelmeli

    public ICollection<Transaction> Transactions { get; set; }
    public ICollection<ScheduledTransaction> ScheduledTransactions { get; set; }
}