using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HybridFinanceSystem.Domain.Common;


namespace HybridFinanceSystem.Domain.Entities;

[Table("InvestmentIncomes")]
public class InvestmentIncome
{
    [Key]
    public int Income_ID { get; set; }

    public int Asset_ID { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal IncomeAmount { get; set; }

    [StringLength(50)]
    public string? IncomeType { get; set; } // 'Dividend', 'Staking' vb.

    public DateTime IncomeDate { get; set; }

    // --- Navigation Properties ---
    [ForeignKey("Asset_ID")]
    public Asset Asset { get; set; } = null!;
}