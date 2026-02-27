using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HybridFinanceSystem.Domain.Common;


namespace HybridFinanceSystem.Domain.Entities;

[Table("Categories")]
public class Category
{
    public Category()
    {
        SubCategories = new HashSet<Category>();
        Merchants = new HashSet<Merchant>();
        Transactions = new HashSet<Transaction>();
        Budgets = new HashSet<Budget>();
    }

    [Key]
    public int Category_ID { get; set; }

    public int? ParentCategory_ID { get; set; } // Boş olabilir (Root kategori)

    [Required, StringLength(100)]
    public string CategoryName { get; set; } = string.Empty;

    public bool IsIncome { get; set; } = false;

    [StringLength(50)]
    public string? IconCode { get; set; } // Nullable olduğu için string?

    // Navigation Properties
    [ForeignKey("ParentCategory_ID")]
    public Category? ParentCategory { get; set; }
        
    public ICollection<Category> SubCategories { get; set; }
    public ICollection<Merchant> Merchants { get; set; }
    public ICollection<Transaction> Transactions { get; set; }
    public ICollection<Budget> Budgets { get; set; }
}