using Microsoft.EntityFrameworkCore;
using HybridFinanceSystem.Domain.Entities;

namespace HybridFinanceSystem.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Tablolarımızı buraya tanımlıyoruz
    public DbSet<Currency> Currencies { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Merchant> Merchants { get; set; }
    public DbSet<Asset> Assets { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<AnomalyLog> AnomalyLogs { get; set; }
    public DbSet<DateDimension> DateDimensions { get; set; }
    public DbSet<AssetPriceHistory> AssetPriceHistories { get; set; }
    public DbSet<BalanceAuditLog> BalanceAuditLogs { get; set; }
    public DbSet<Budget> Budgets { get; set; }
    public DbSet<ScheduledTransaction> ScheduledTransactions { get; set; }
    public DbSet<TransactionAttachment> TransactionAttachments { get; set; }
    public DbSet<InvestmentIncome> InvestmentIncomes { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- 1. Decimal Hassasiyet Ayarları ---
            // EF Core'a bu alanların sadece 2 hane değil, SQL'deki gibi daha hassas olduğunu söylüyoruz.
            var decimalEntities = modelBuilder.Model.GetEntityTypes();
            foreach (var entityType in decimalEntities)
            {
                var properties = entityType.GetProperties()
                    .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?));

                foreach (var property in properties)
                {
                    // Varsayılan 18,4 yapalım, özel durumları aşağıda ezeceğiz
                    property.SetPrecision(18);
                    property.SetScale(4);
                }
            }

            // Kripto fiyatları için özel 18,8 hassasiyeti
            modelBuilder.Entity<AssetPriceHistory>()
                .Property(p => p.Price)
                .HasPrecision(18, 8);

            // Anomali skoru için 5,2 hassasiyeti
            modelBuilder.Entity<AnomalyLog>()
                .Property(p => p.ConfidenceScore)
                .HasPrecision(5, 2);

            // --- 2. İlişki Yapılandırmaları (Fluent API) ---

            // Category Self-Reference (Kendi kendine bağlılık)
            modelBuilder.Entity<Category>()
                .HasOne(c => c.ParentCategory)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(c => c.ParentCategory_ID)
                .OnDelete(DeleteBehavior.Restrict);

            // Silme Davranışları (Cascade Delete Engelleme)
            // Finansal verilerde bir kullanıcı silindiğinde tüm geçmişin patlamaması için 'Restrict' güvenlidir.
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            // --- 3. Index Tanımlamaları (Performans İçin) ---
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();
        }
    }
