using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HybridFinanceSystem.Domain.Common;


namespace HybridFinanceSystem.Domain.Entities;

[Table("AssetPriceHistory")]
public class AssetPriceHistory
{
    [Key]
    public long Price_ID { get; set; }

    [Required, StringLength(3)]
    public string CurrencyCode { get; set; } = string.Empty;

    public DateTime PriceDate { get; set; } = DateTime.Now;

    [Column(TypeName = "decimal(18, 8)")] // Kripto hassasiyeti
    public decimal Price { get; set; }

    [StringLength(50)]
    public string? Source { get; set; }

    // --- Navigation Properties ---
    [ForeignKey("CurrencyCode")]
    public Currency Currency { get; set; } = null!;
}