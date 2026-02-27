using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HybridFinanceSystem.Domain.Common;


namespace HybridFinanceSystem.Domain.Entities;

[Table("Budgets")]
public class Budget : BaseEntity
{
    [Key]
    public int Budget_ID { get; set; }

    public int Users_ID { get; set; }

    public int Category_ID { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal AmountLimit { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    // --- Navigation Properties ---
    [ForeignKey("Users_ID")]
    public User User { get; set; } = null!;

    [ForeignKey("Category_ID")]
    public Category Category { get; set; } = null!;
}