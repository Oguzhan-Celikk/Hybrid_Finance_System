using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HybridFinanceSystem.Domain.Common;


namespace HybridFinanceSystem.Domain.Entities;

[Table("Currencies")]
public class Currency
{
    public Currency()
    {
        Users = new HashSet<User>();
        Assets = new HashSet<Asset>();
        AssetPriceHistories = new HashSet<AssetPriceHistory>();
    }

    [Key]
    [StringLength(3)]
    public string Code { get; set; } = string.Empty; // Örn: 'TRY'

    [Required, StringLength(5)]
    public string Symbol { get; set; } = string.Empty;

    [Required, StringLength(50)]
    public string Name { get; set; } = string.Empty;

    // Navigation Properties
    public ICollection<User> Users { get; set; }
    public ICollection<Asset> Assets { get; set; }
    public ICollection<AssetPriceHistory> AssetPriceHistories { get; set; }
}