using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HybridFinanceSystem.Domain.Common;


namespace HybridFinanceSystem.Domain.Entities;

[Table("Users")] // Veritabanındaki tablo adının 'Users' olduğunu garanti ederiz
public class User : BaseEntity
{
    public User()
    {
        // HashSet performans ve benzersizlik için daha iyidir
        Assets = new HashSet<Asset>();
        Transactions = new HashSet<Transaction>();
    }

    [Key]
    public int Users_ID { get; set; }
        
    [Required, StringLength(50)]
    public string Username { get; set; } = string.Empty; // SQL'deki 'Username' ile aynı isim
        
    [Required, EmailAddress, StringLength(100)]
    public string Email { get; set; } = string.Empty;
        
    [Required]
    public string PasswordHash { get; set; } = string.Empty;
        
    [StringLength(3)]
    public string BaseCurrencyCode { get; set; } = "TRY";
        
    public bool IsActive { get; set; } = true;

    // --- Navigation Properties ---

    [ForeignKey("BaseCurrencyCode")]
    public Currency? Currency { get; set; } // Bu olmazsa döviz detayına erişemezsin

    public ICollection<Asset> Assets { get; set; }
    public ICollection<Transaction> Transactions { get; set; }
}