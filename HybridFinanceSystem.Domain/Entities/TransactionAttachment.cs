using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HybridFinanceSystem.Domain.Common;


namespace HybridFinanceSystem.Domain.Entities;

[Table("TransactionAttachments")]
public class TransactionAttachment
{
    [Key]
    public long Attachment_ID { get; set; }

    public long Transaction_ID { get; set; }

    [Required]
    public string FilePath { get; set; } = string.Empty;

    public string? RawOCRText { get; set; }

    public DateTime UploadedAt { get; set; } = DateTime.Now;

    // --- Navigation Properties ---
    [ForeignKey("Transaction_ID")]
    public Transaction Transaction { get; set; } = null!;
}