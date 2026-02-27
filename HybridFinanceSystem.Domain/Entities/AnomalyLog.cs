using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HybridFinanceSystem.Domain.Common;


namespace HybridFinanceSystem.Domain.Entities;

[Table("AnomalyLogs")]
public class AnomalyLog
{
    [Key]
    public int Anomaly_ID { get; set; }

    public long Transaction_ID { get; set; }

    public string? Reason { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal? ConfidenceScore { get; set; }

    public bool? UserFeedback { get; set; }

    // --- Navigation Properties ---
    [ForeignKey("Transaction_ID")]
    public Transaction Transaction { get; set; } = null!;
}