using System;
using System.Collections.Generic;
using HybridFinanceSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HybridFinanceSystem.Infrastructure.Persistence;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Anomaly> Anomalies { get; set; }

    public virtual DbSet<ArchivalPolicy> ArchivalPolicies { get; set; }

    public virtual DbSet<Asset> Assets { get; set; }

    public virtual DbSet<AssetTransaction> AssetTransactions { get; set; }

    public virtual DbSet<AuditLog> AuditLogs { get; set; }

    public virtual DbSet<Bill> Bills { get; set; }

    public virtual DbSet<Budget> Budgets { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Device> Devices { get; set; }

    public virtual DbSet<EncryptionKeyVersion> EncryptionKeyVersions { get; set; }

    public virtual DbSet<ExchangeRate> ExchangeRates { get; set; }

    public virtual DbSet<FeatureDefinition> FeatureDefinitions { get; set; }

    public virtual DbSet<ForexPosition> ForexPositions { get; set; }

    public virtual DbSet<GdprRequest> GdprRequests { get; set; }

    public virtual DbSet<GeneratedReport> GeneratedReports { get; set; }

    public virtual DbSet<GoalContribution> GoalContributions { get; set; }

    public virtual DbSet<IncomeSource> IncomeSources { get; set; }

    public virtual DbSet<ModelTrainingLog> ModelTrainingLogs { get; set; }

    public virtual DbSet<MonthlySummary> MonthlySummaries { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<NotificationPreference> NotificationPreferences { get; set; }

    public virtual DbSet<OauthConnection> OauthConnections { get; set; }

    public virtual DbSet<PersonalInflation> PersonalInflations { get; set; }

    public virtual DbSet<PortfolioSnapshot> PortfolioSnapshots { get; set; }

    public virtual DbSet<Prediction> Predictions { get; set; }

    public virtual DbSet<PriceAlert> PriceAlerts { get; set; }

    public virtual DbSet<PriceHistory> PriceHistories { get; set; }

    public virtual DbSet<PriceUpdateSchedule> PriceUpdateSchedules { get; set; }

    public virtual DbSet<RateLimitBucket> RateLimitBuckets { get; set; }

    public virtual DbSet<Receipt> Receipts { get; set; }

    public virtual DbSet<RecurringRule> RecurringRules { get; set; }

    public virtual DbSet<ReportDefinition> ReportDefinitions { get; set; }

    public virtual DbSet<SavingGoal> SavingGoals { get; set; }

    public virtual DbSet<ScheduledJob> ScheduledJobs { get; set; }

    public virtual DbSet<SecurityEvent> SecurityEvents { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<SpendingPattern> SpendingPatterns { get; set; }

    public virtual DbSet<StakingReward> StakingRewards { get; set; }

    public virtual DbSet<Subscription> Subscriptions { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<TaxEvent> TaxEvents { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<TransactionTag> TransactionTags { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserFeatureFlag> UserFeatureFlags { get; set; }

    public virtual DbSet<Watchlist> Watchlists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=FinancialEcosystem;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.ToTable("accounts", "fin", tb => tb.HasTrigger("trg_accounts_updated_at"));

            entity.Property(e => e.AccountId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("account_id");
            entity.Property(e => e.AccountName)
                .HasMaxLength(150)
                .HasColumnName("account_name");
            entity.Property(e => e.AccountType)
                .HasMaxLength(30)
                .HasColumnName("account_type");
            entity.Property(e => e.Balance)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("balance");
            entity.Property(e => e.BalanceUpdatedAt).HasColumnName("balance_updated_at");
            entity.Property(e => e.ColorHex)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("color_hex");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValue("TRY")
                .IsFixedLength()
                .HasColumnName("currency_code");
            entity.Property(e => e.DataSource)
                .HasMaxLength(20)
                .HasDefaultValue("manual")
                .HasColumnName("data_source");
            entity.Property(e => e.Icon)
                .HasMaxLength(50)
                .HasColumnName("icon");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsDefault).HasColumnName("is_default");
            entity.Property(e => e.LastSyncedAt).HasColumnName("last_synced_at");
            entity.Property(e => e.Notes)
                .HasMaxLength(300)
                .HasColumnName("notes");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_accounts_user");
        });

        modelBuilder.Entity<Anomaly>(entity =>
        {
            entity.ToTable("anomalies", "ai");

            entity.HasIndex(e => new { e.UserId, e.DetectedAt, e.IsConfirmed }, "IX_anomalies_user_date").IsDescending(false, true, false);

            entity.Property(e => e.AnomalyId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("anomaly_id");
            entity.Property(e => e.AnomalyScore)
                .HasColumnType("decimal(5, 4)")
                .HasColumnName("anomaly_score");
            entity.Property(e => e.AnomalyType)
                .HasMaxLength(50)
                .HasColumnName("anomaly_type");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.DetectedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("detected_at");
            entity.Property(e => e.IsConfirmed).HasColumnName("is_confirmed");
            entity.Property(e => e.ModelVersion)
                .HasMaxLength(20)
                .HasColumnName("model_version");
            entity.Property(e => e.ReviewedAt).HasColumnName("reviewed_at");
            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
            entity.Property(e => e.UserFeedback)
                .HasMaxLength(200)
                .HasColumnName("user_feedback");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Transaction).WithMany(p => p.Anomalies)
                .HasForeignKey(d => d.TransactionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_anomaly_transaction");

            entity.HasOne(d => d.User).WithMany(p => p.Anomalies)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_anomaly_user");
        });

        modelBuilder.Entity<ArchivalPolicy>(entity =>
        {
            entity.HasKey(e => e.PolicyId);

            entity.ToTable("archival_policies", "audit");

            entity.HasIndex(e => new { e.TableSchema, e.TableName }, "UQ_archival_table").IsUnique();

            entity.Property(e => e.PolicyId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("policy_id");
            entity.Property(e => e.ArchiveAfterMonths).HasColumnName("archive_after_months");
            entity.Property(e => e.ArchiveDestination)
                .HasMaxLength(100)
                .HasColumnName("archive_destination");
            entity.Property(e => e.CompressionEnabled)
                .HasDefaultValue(true)
                .HasColumnName("compression_enabled");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.DateColumn)
                .HasMaxLength(100)
                .HasColumnName("date_column");
            entity.Property(e => e.DeleteAfterMonths).HasColumnName("delete_after_months");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.LastRunAt).HasColumnName("last_run_at");
            entity.Property(e => e.LastRunStatus)
                .HasMaxLength(15)
                .HasColumnName("last_run_status");
            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .HasColumnName("notes");
            entity.Property(e => e.RowsArchivedLast).HasColumnName("rows_archived_last");
            entity.Property(e => e.RowsDeletedLast).HasColumnName("rows_deleted_last");
            entity.Property(e => e.TableName)
                .HasMaxLength(100)
                .HasColumnName("table_name");
            entity.Property(e => e.TableSchema)
                .HasMaxLength(50)
                .HasColumnName("table_schema");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("updated_at");
            entity.Property(e => e.WhereClause)
                .HasMaxLength(500)
                .HasColumnName("where_clause");
        });

        modelBuilder.Entity<Asset>(entity =>
        {
            entity.ToTable("assets", "portfolio", tb => tb.HasTrigger("trg_assets_updated_at"));

            entity.Property(e => e.AssetId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("asset_id");
            entity.Property(e => e.AssetType)
                .HasMaxLength(15)
                .HasColumnName("asset_type");
            entity.Property(e => e.AverageCost)
                .HasColumnType("decimal(18, 8)")
                .HasColumnName("average_cost");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("currency_code");
            entity.Property(e => e.CurrentPrice)
                .HasColumnType("decimal(18, 8)")
                .HasColumnName("current_price");
            entity.Property(e => e.CurrentValue)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("current_value");
            entity.Property(e => e.Exchange)
                .HasMaxLength(50)
                .HasColumnName("exchange");
            entity.Property(e => e.ForexPositionId).HasColumnName("forex_position_id");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");
            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .HasColumnName("notes");
            entity.Property(e => e.PriceUpdatedAt).HasColumnName("price_updated_at");
            entity.Property(e => e.Quantity)
                .HasColumnType("decimal(28, 10)")
                .HasColumnName("quantity");
            entity.Property(e => e.Symbol)
                .HasMaxLength(20)
                .HasColumnName("symbol");
            entity.Property(e => e.TotalCost)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("total_cost");
            entity.Property(e => e.UnrealizedPnl)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("unrealized_pnl");
            entity.Property(e => e.UnrealizedPnlPct)
                .HasColumnType("decimal(10, 4)")
                .HasColumnName("unrealized_pnl_pct");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.ForexPosition).WithMany(p => p.Assets)
                .HasForeignKey(d => d.ForexPositionId)
                .HasConstraintName("FK_assets_forex");

            entity.HasOne(d => d.User).WithMany(p => p.Assets)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_assets_user");
        });

        modelBuilder.Entity<AssetTransaction>(entity =>
        {
            entity.HasKey(e => e.AssetTxId);

            entity.ToTable("asset_transactions", "portfolio", tb => tb.HasTrigger("trg_create_tax_event"));

            entity.Property(e => e.AssetTxId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("asset_tx_id");
            entity.Property(e => e.AssetId).HasColumnName("asset_id");
            entity.Property(e => e.Commission)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("commission");
            entity.Property(e => e.CommissionCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValue("TRY")
                .IsFixedLength()
                .HasColumnName("commission_currency");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("currency_code");
            entity.Property(e => e.ExchangeRateToTry)
                .HasDefaultValue(1m)
                .HasColumnType("decimal(18, 8)")
                .HasColumnName("exchange_rate_to_try");
            entity.Property(e => e.NotesEncrypted).HasColumnName("notes_encrypted");
            entity.Property(e => e.PricePerUnit)
                .HasColumnType("decimal(18, 8)")
                .HasColumnName("price_per_unit");
            entity.Property(e => e.Quantity)
                .HasColumnType("decimal(28, 10)")
                .HasColumnName("quantity");
            entity.Property(e => e.TaxEventId).HasColumnName("tax_event_id");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("total_amount");
            entity.Property(e => e.TotalAmountTry)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("total_amount_try");
            entity.Property(e => e.TransactionDate).HasColumnName("transaction_date");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(15)
                .HasColumnName("transaction_type");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Asset).WithMany(p => p.AssetTransactions)
                .HasForeignKey(d => d.AssetId)
                .HasConstraintName("FK_at_asset");

            entity.HasOne(d => d.TaxEvent).WithMany(p => p.AssetTransactions)
                .HasForeignKey(d => d.TaxEventId)
                .HasConstraintName("FK_at_tax_event");

            entity.HasOne(d => d.User).WithMany(p => p.AssetTransactions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_at_user");
        });

        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(e => e.LogId);

            entity.ToTable("audit_log", "audit");

            entity.HasIndex(e => new { e.TableSchema, e.TableName, e.CreatedAt }, "IX_audit_log_table").IsDescending(false, false, true);

            entity.HasIndex(e => new { e.UserId, e.CreatedAt }, "IX_audit_log_user").IsDescending(false, true);

            entity.Property(e => e.LogId).HasColumnName("log_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.IpAddressEncrypted)
                .HasMaxLength(256)
                .HasColumnName("ip_address_encrypted");
            entity.Property(e => e.NewValuesEncrypted).HasColumnName("new_values_encrypted");
            entity.Property(e => e.OldValuesEncrypted).HasColumnName("old_values_encrypted");
            entity.Property(e => e.Operation)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("operation");
            entity.Property(e => e.RecordId)
                .HasMaxLength(100)
                .HasColumnName("record_id");
            entity.Property(e => e.SessionId).HasColumnName("session_id");
            entity.Property(e => e.TableName)
                .HasMaxLength(100)
                .HasColumnName("table_name");
            entity.Property(e => e.TableSchema)
                .HasMaxLength(50)
                .HasColumnName("table_schema");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Bill>(entity =>
        {
            entity.ToTable("bills", "fin", tb =>
                {
                    tb.HasTrigger("trg_bill_overdue_check");
                    tb.HasTrigger("trg_bills_updated_at");
                });

            entity.HasIndex(e => new { e.DueDate, e.Status }, "IX_bills_overdue").HasFilter("([status]='pending')");

            entity.HasIndex(e => new { e.UserId, e.Status, e.DueDate }, "IX_bills_user_due");

            entity.Property(e => e.BillId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("bill_id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.ActualAmount)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("actual_amount");
            entity.Property(e => e.BillType)
                .HasMaxLength(20)
                .HasColumnName("bill_type");
            entity.Property(e => e.BillingCycleDay).HasColumnName("billing_cycle_day");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValue("TRY")
                .IsFixedLength()
                .HasColumnName("currency_code");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.DueDay).HasColumnName("due_day");
            entity.Property(e => e.EstimatedAmount)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("estimated_amount");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.LateFeeRate)
                .HasColumnType("decimal(8, 4)")
                .HasColumnName("late_fee_rate");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.Notes)
                .HasMaxLength(300)
                .HasColumnName("notes");
            entity.Property(e => e.PaymentTransactionId).HasColumnName("payment_transaction_id");
            entity.Property(e => e.ProviderName)
                .HasMaxLength(200)
                .HasColumnName("provider_name");
            entity.Property(e => e.ReminderDaysBefore)
                .HasDefaultValue((byte)3)
                .HasColumnName("reminder_days_before");
            entity.Property(e => e.Status)
                .HasMaxLength(15)
                .HasDefaultValue("pending")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Account).WithMany(p => p.Bills)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_bills_account");

            entity.HasOne(d => d.PaymentTransaction).WithMany(p => p.Bills)
                .HasForeignKey(d => d.PaymentTransactionId)
                .HasConstraintName("FK_bills_payment");

            entity.HasOne(d => d.User).WithMany(p => p.Bills)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_bills_user");
        });

        modelBuilder.Entity<Budget>(entity =>
        {
            entity.ToTable("budgets", "fin");

            entity.HasIndex(e => new { e.UserId, e.IsActive, e.StartDate, e.EndDate }, "IX_budgets_user_active");

            entity.Property(e => e.BudgetId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("budget_id");
            entity.Property(e => e.AlertAtPercent)
                .HasDefaultValue((short)80)
                .HasColumnName("alert_at_percent");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("amount");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValue("TRY")
                .IsFixedLength()
                .HasColumnName("currency_code");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.PeriodType)
                .HasMaxLength(15)
                .HasDefaultValue("monthly")
                .HasColumnName("period_type");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Category).WithMany(p => p.Budgets)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_budgets_category");

            entity.HasOne(d => d.User).WithMany(p => p.Budgets)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_budgets_user");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("categories", "fin");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.ColorHex)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("color_hex");
            entity.Property(e => e.Icon)
                .HasMaxLength(50)
                .HasColumnName("icon");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsSystem).HasColumnName("is_system");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.ParentCategoryId).HasColumnName("parent_category_id");
            entity.Property(e => e.SortOrder).HasColumnName("sort_order");
            entity.Property(e => e.Type)
                .HasMaxLength(10)
                .HasColumnName("type");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.ParentCategory).WithMany(p => p.InverseParentCategory)
                .HasForeignKey(d => d.ParentCategoryId)
                .HasConstraintName("FK_categories_parent");

            entity.HasOne(d => d.User).WithMany(p => p.Categories)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_categories_user");
        });

        modelBuilder.Entity<Device>(entity =>
        {
            entity.ToTable("devices", "auth");

            entity.Property(e => e.DeviceId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("device_id");
            entity.Property(e => e.DeviceFingerprint)
                .HasMaxLength(256)
                .HasColumnName("device_fingerprint");
            entity.Property(e => e.DeviceName)
                .HasMaxLength(100)
                .HasColumnName("device_name");
            entity.Property(e => e.IsTrusted).HasColumnName("is_trusted");
            entity.Property(e => e.LastSeenAt).HasColumnName("last_seen_at");
            entity.Property(e => e.Platform)
                .HasMaxLength(20)
                .HasColumnName("platform");
            entity.Property(e => e.PushTokenEncrypted).HasColumnName("push_token_encrypted");
            entity.Property(e => e.RegisteredAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("registered_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Devices)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_devices_user");
        });

        modelBuilder.Entity<EncryptionKeyVersion>(entity =>
        {
            entity.HasKey(e => e.KeyVersionId);

            entity.ToTable("encryption_key_versions", "audit");

            entity.HasIndex(e => e.KeyAlias, "UQ_key_alias").IsUnique();

            entity.Property(e => e.KeyVersionId)
                .ValueGeneratedNever()
                .HasColumnName("key_version_id");
            entity.Property(e => e.ActivatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("activated_at");
            entity.Property(e => e.Algorithm)
                .HasMaxLength(20)
                .HasDefaultValue("AES-256-GCM")
                .HasColumnName("algorithm");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasDefaultValueSql("(suser_sname())")
                .HasColumnName("created_by");
            entity.Property(e => e.KeyAlias)
                .HasMaxLength(50)
                .HasColumnName("key_alias");
            entity.Property(e => e.KeyDerivation)
                .HasMaxLength(30)
                .HasDefaultValue("PBKDF2-SHA256")
                .HasColumnName("key_derivation");
            entity.Property(e => e.KeyFingerprint)
                .HasMaxLength(64)
                .HasColumnName("key_fingerprint");
            entity.Property(e => e.KeyLengthBits)
                .HasDefaultValue((short)256)
                .HasColumnName("key_length_bits");
            entity.Property(e => e.MigratedRecords).HasColumnName("migrated_records");
            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .HasColumnName("notes");
            entity.Property(e => e.RetireAt).HasColumnName("retire_at");
            entity.Property(e => e.RevokedAt).HasColumnName("revoked_at");
            entity.Property(e => e.RotatedAt).HasColumnName("rotated_at");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .HasDefaultValue("active")
                .HasColumnName("status");
            entity.Property(e => e.TotalRecordsToMigrate).HasColumnName("total_records_to_migrate");
        });

        modelBuilder.Entity<ExchangeRate>(entity =>
        {
            entity.HasKey(e => e.RateId);

            entity.ToTable("exchange_rates", "portfolio");

            entity.HasIndex(e => new { e.FromCurrency, e.ToCurrency, e.RateDate }, "IX_exchange_rates_pair").IsDescending(false, false, true);

            entity.HasIndex(e => new { e.FromCurrency, e.ToCurrency, e.RateDate, e.Source }, "UQ_exchange_rates").IsUnique();

            entity.Property(e => e.RateId).HasColumnName("rate_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.FromCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("from_currency");
            entity.Property(e => e.Rate)
                .HasColumnType("decimal(18, 8)")
                .HasColumnName("rate");
            entity.Property(e => e.RateDate).HasColumnName("rate_date");
            entity.Property(e => e.Source)
                .HasMaxLength(50)
                .HasColumnName("source");
            entity.Property(e => e.ToCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("to_currency");
        });

        modelBuilder.Entity<FeatureDefinition>(entity =>
        {
            entity.HasKey(e => e.FeatureKey);

            entity.ToTable("feature_definitions", "auth");

            entity.Property(e => e.FeatureKey)
                .HasMaxLength(60)
                .HasColumnName("feature_key");
            entity.Property(e => e.Category)
                .HasMaxLength(30)
                .HasColumnName("category");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.DefaultEnabled).HasColumnName("default_enabled");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(150)
                .HasColumnName("display_name");
            entity.Property(e => e.IsBeta).HasColumnName("is_beta");
            entity.Property(e => e.IsDeprecated).HasColumnName("is_deprecated");
            entity.Property(e => e.RequiresPlan)
                .HasMaxLength(20)
                .HasColumnName("requires_plan");
        });

        modelBuilder.Entity<ForexPosition>(entity =>
        {
            entity.HasKey(e => e.PositionId);

            entity.ToTable("forex_positions", "portfolio");

            entity.HasIndex(e => new { e.UserId, e.CurrencyCode }, "IX_forex_user_currency");

            entity.HasIndex(e => new { e.UserId, e.AccountId, e.CurrencyCode }, "UQ_forex_position").IsUnique();

            entity.Property(e => e.PositionId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("position_id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.AverageBuyRate)
                .HasColumnType("decimal(18, 8)")
                .HasColumnName("average_buy_rate");
            entity.Property(e => e.BaseCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValue("TRY")
                .IsFixedLength()
                .HasColumnName("base_currency");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("currency_code");
            entity.Property(e => e.CurrentRate)
                .HasColumnType("decimal(18, 8)")
                .HasColumnName("current_rate");
            entity.Property(e => e.CurrentValueBase)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("current_value_base");
            entity.Property(e => e.LastUpdatedAt).HasColumnName("last_updated_at");
            entity.Property(e => e.PositionType)
                .HasMaxLength(10)
                .HasDefaultValue("long")
                .HasColumnName("position_type");
            entity.Property(e => e.Quantity)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("quantity");
            entity.Property(e => e.RealizedPnl)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("realized_pnl");
            entity.Property(e => e.TotalCostBase)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("total_cost_base");
            entity.Property(e => e.UnrealizedPnl)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("unrealized_pnl");
            entity.Property(e => e.UnrealizedPnlPct)
                .HasColumnType("decimal(10, 4)")
                .HasColumnName("unrealized_pnl_pct");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Account).WithMany(p => p.ForexPositions)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_fp_account");

            entity.HasOne(d => d.User).WithMany(p => p.ForexPositions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_fp_user");
        });

        modelBuilder.Entity<GdprRequest>(entity =>
        {
            entity.HasKey(e => e.RequestId);

            entity.ToTable("gdpr_requests", "audit");

            entity.Property(e => e.RequestId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("request_id");
            entity.Property(e => e.CompletedAt).HasColumnName("completed_at");
            entity.Property(e => e.DeadlineAt).HasColumnName("deadline_at");
            entity.Property(e => e.ProcessorNotes)
                .HasMaxLength(500)
                .HasColumnName("processor_notes");
            entity.Property(e => e.Reason)
                .HasMaxLength(500)
                .HasColumnName("reason");
            entity.Property(e => e.RequestType)
                .HasMaxLength(20)
                .HasColumnName("request_type");
            entity.Property(e => e.RequestedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("requested_at");
            entity.Property(e => e.Status)
                .HasMaxLength(15)
                .HasDefaultValue("pending")
                .HasColumnName("status");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.GdprRequests)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_gdpr_user");
        });

        modelBuilder.Entity<GeneratedReport>(entity =>
        {
            entity.HasKey(e => e.ReportId);

            entity.ToTable("generated_reports", "report");

            entity.Property(e => e.ReportId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("report_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.ExpiresAt).HasColumnName("expires_at");
            entity.Property(e => e.FilePathEncrypted).HasColumnName("file_path_encrypted");
            entity.Property(e => e.FileSizeBytes).HasColumnName("file_size_bytes");
            entity.Property(e => e.GeneratedAt).HasColumnName("generated_at");
            entity.Property(e => e.OutputFormat)
                .HasMaxLength(10)
                .HasColumnName("output_format");
            entity.Property(e => e.PeriodEnd).HasColumnName("period_end");
            entity.Property(e => e.PeriodStart).HasColumnName("period_start");
            entity.Property(e => e.ReportDefId).HasColumnName("report_def_id");
            entity.Property(e => e.Status)
                .HasMaxLength(15)
                .HasDefaultValue("pending")
                .HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(200)
                .HasColumnName("title");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.ReportDef).WithMany(p => p.GeneratedReports)
                .HasForeignKey(d => d.ReportDefId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_gr_definition");

            entity.HasOne(d => d.User).WithMany(p => p.GeneratedReports)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_gr_user");
        });

        modelBuilder.Entity<GoalContribution>(entity =>
        {
            entity.HasKey(e => e.ContributionId);

            entity.ToTable("goal_contributions", "fin", tb => tb.HasTrigger("trg_update_goal_progress"));

            entity.Property(e => e.ContributionId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("contribution_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("amount");
            entity.Property(e => e.ContributedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("contributed_at");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValue("TRY")
                .IsFixedLength()
                .HasColumnName("currency_code");
            entity.Property(e => e.GoalId).HasColumnName("goal_id");
            entity.Property(e => e.Note)
                .HasMaxLength(200)
                .HasColumnName("note");
            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");

            entity.HasOne(d => d.Goal).WithMany(p => p.GoalContributions)
                .HasForeignKey(d => d.GoalId)
                .HasConstraintName("FK_gc_goal");

            entity.HasOne(d => d.Transaction).WithMany(p => p.GoalContributions)
                .HasForeignKey(d => d.TransactionId)
                .HasConstraintName("FK_gc_transaction");
        });

        modelBuilder.Entity<IncomeSource>(entity =>
        {
            entity.HasKey(e => e.SourceId);

            entity.ToTable("income_sources", "fin");

            entity.HasIndex(e => new { e.UserId, e.IsActive, e.IncomeType }, "IX_income_sources_user");

            entity.Property(e => e.SourceId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("source_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValue("TRY")
                .IsFixedLength()
                .HasColumnName("currency_code");
            entity.Property(e => e.EmployerName)
                .HasMaxLength(200)
                .HasColumnName("employer_name");
            entity.Property(e => e.EmployerTaxId)
                .HasMaxLength(20)
                .HasColumnName("employer_tax_id");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.ExpectedAmount)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("expected_amount");
            entity.Property(e => e.Frequency)
                .HasMaxLength(15)
                .HasColumnName("frequency");
            entity.Property(e => e.IncomeType)
                .HasMaxLength(25)
                .HasColumnName("income_type");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsRecurring)
                .HasDefaultValue(true)
                .HasColumnName("is_recurring");
            entity.Property(e => e.IsTaxable)
                .HasDefaultValue(true)
                .HasColumnName("is_taxable");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .HasColumnName("notes");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.TaxCategory)
                .HasMaxLength(30)
                .HasColumnName("tax_category");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.WithholdingRate)
                .HasColumnType("decimal(5, 4)")
                .HasColumnName("withholding_rate");

            entity.HasOne(d => d.User).WithMany(p => p.IncomeSources)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_income_user");
        });

        modelBuilder.Entity<ModelTrainingLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK_model_logs");

            entity.ToTable("model_training_logs", "ai");

            entity.Property(e => e.LogId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("log_id");
            entity.Property(e => e.AccuracyScore)
                .HasColumnType("decimal(5, 4)")
                .HasColumnName("accuracy_score");
            entity.Property(e => e.Hyperparameters).HasColumnName("hyperparameters");
            entity.Property(e => e.ModelName)
                .HasMaxLength(50)
                .HasColumnName("model_name");
            entity.Property(e => e.ModelVersion)
                .HasMaxLength(20)
                .HasColumnName("model_version");
            entity.Property(e => e.SampleCount).HasColumnName("sample_count");
            entity.Property(e => e.TrainedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("trained_at");
            entity.Property(e => e.TrainingDataFrom).HasColumnName("training_data_from");
            entity.Property(e => e.TrainingDataTo).HasColumnName("training_data_to");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.ModelTrainingLogs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_ml_user");
        });

        modelBuilder.Entity<MonthlySummary>(entity =>
        {
            entity.HasKey(e => e.SummaryId);

            entity.ToTable("monthly_summaries", "report");

            entity.HasIndex(e => new { e.UserId, e.SummaryYear, e.SummaryMonth }, "IX_monthly_summaries_period").IsDescending(false, true, true);

            entity.HasIndex(e => new { e.UserId, e.SummaryYear, e.SummaryMonth }, "UQ_monthly_summary").IsUnique();

            entity.Property(e => e.SummaryId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("summary_id");
            entity.Property(e => e.AccountBalances).HasColumnName("account_balances");
            entity.Property(e => e.AnomalyCount).HasColumnName("anomaly_count");
            entity.Property(e => e.BudgetsExceeded).HasColumnName("budgets_exceeded");
            entity.Property(e => e.BudgetsOnTrack).HasColumnName("budgets_on_track");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.EstimatedTaxLiability)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("estimated_tax_liability");
            entity.Property(e => e.ExpenseCount).HasColumnName("expense_count");
            entity.Property(e => e.IncomeCount).HasColumnName("income_count");
            entity.Property(e => e.IsFinalized).HasColumnName("is_finalized");
            entity.Property(e => e.LastCalculatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("last_calculated_at");
            entity.Property(e => e.NetCashflow)
                .HasComputedColumnSql("([total_income]-[total_expense])", false)
                .HasColumnType("decimal(19, 4)")
                .HasColumnName("net_cashflow");
            entity.Property(e => e.SavingsRate)
                .HasComputedColumnSql("(case when [total_income]>(0) then round((([total_income]-[total_expense])/[total_income])*(100),(2)) else CONVERT([decimal](18,2),(0)) end)", false)
                .HasColumnType("decimal(38, 15)")
                .HasColumnName("savings_rate");
            entity.Property(e => e.SummaryMonth).HasColumnName("summary_month");
            entity.Property(e => e.SummaryYear).HasColumnName("summary_year");
            entity.Property(e => e.TopExpenseCategories).HasColumnName("top_expense_categories");
            entity.Property(e => e.TopIncomeSources).HasColumnName("top_income_sources");
            entity.Property(e => e.TotalExpense)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("total_expense");
            entity.Property(e => e.TotalIncome)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("total_income");
            entity.Property(e => e.TotalTransfer)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("total_transfer");
            entity.Property(e => e.TransferCount).HasColumnName("transfer_count");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.MonthlySummaries)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_ms_user");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.ToTable("notifications", "notification");

            entity.HasIndex(e => new { e.Status, e.SentAt }, "IX_notifications_pending").HasFilter("([status]='pending')");

            entity.HasIndex(e => new { e.UserId, e.IsRead, e.CreatedAt }, "IX_notifications_unread").IsDescending(false, false, true);

            entity.Property(e => e.NotificationId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("notification_id");
            entity.Property(e => e.ActionUrl)
                .HasMaxLength(300)
                .HasColumnName("action_url");
            entity.Property(e => e.Body)
                .HasMaxLength(500)
                .HasColumnName("body");
            entity.Property(e => e.Channel)
                .HasMaxLength(10)
                .HasDefaultValue("in_app")
                .HasColumnName("channel");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.EventType)
                .HasMaxLength(50)
                .HasColumnName("event_type");
            entity.Property(e => e.ExpiresAt).HasColumnName("expires_at");
            entity.Property(e => e.IsRead).HasColumnName("is_read");
            entity.Property(e => e.ReadAt).HasColumnName("read_at");
            entity.Property(e => e.RelatedEntityId)
                .HasMaxLength(100)
                .HasColumnName("related_entity_id");
            entity.Property(e => e.RelatedEntityType)
                .HasMaxLength(30)
                .HasColumnName("related_entity_type");
            entity.Property(e => e.SentAt).HasColumnName("sent_at");
            entity.Property(e => e.Severity)
                .HasMaxLength(10)
                .HasDefaultValue("info")
                .HasColumnName("severity");
            entity.Property(e => e.Status)
                .HasMaxLength(15)
                .HasDefaultValue("pending")
                .HasColumnName("status");
            entity.Property(e => e.Title)
                .HasMaxLength(150)
                .HasColumnName("title");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_notif_user");
        });

        modelBuilder.Entity<NotificationPreference>(entity =>
        {
            entity.HasKey(e => e.PrefId).HasName("PK_notification_prefs");

            entity.ToTable("notification_preferences", "notification");

            entity.HasIndex(e => new { e.UserId, e.EventType }, "UQ_notif_user_event").IsUnique();

            entity.Property(e => e.PrefId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("pref_id");
            entity.Property(e => e.EmailEnabled).HasColumnName("email_enabled");
            entity.Property(e => e.EventType)
                .HasMaxLength(50)
                .HasColumnName("event_type");
            entity.Property(e => e.InAppEnabled)
                .HasDefaultValue(true)
                .HasColumnName("in_app_enabled");
            entity.Property(e => e.MinSeverity)
                .HasMaxLength(10)
                .HasDefaultValue("info")
                .HasColumnName("min_severity");
            entity.Property(e => e.PushEnabled)
                .HasDefaultValue(true)
                .HasColumnName("push_enabled");
            entity.Property(e => e.QuietHoursEnd).HasColumnName("quiet_hours_end");
            entity.Property(e => e.QuietHoursStart).HasColumnName("quiet_hours_start");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.NotificationPreferences)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_np_user");
        });

        modelBuilder.Entity<OauthConnection>(entity =>
        {
            entity.HasKey(e => e.ConnectionId).HasName("PK_oauth");

            entity.ToTable("oauth_connections", "auth");

            entity.HasIndex(e => new { e.UserId, e.Provider, e.IsActive }, "IX_oauth_user");

            entity.HasIndex(e => new { e.Provider, e.ProviderUserId }, "UQ_oauth_provider").IsUnique();

            entity.Property(e => e.ConnectionId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("connection_id");
            entity.Property(e => e.AccessTokenEncrypted).HasColumnName("access_token_encrypted");
            entity.Property(e => e.ConnectedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("connected_at");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.LastUsedAt).HasColumnName("last_used_at");
            entity.Property(e => e.Provider)
                .HasMaxLength(50)
                .HasColumnName("provider");
            entity.Property(e => e.ProviderUserId)
                .HasMaxLength(256)
                .HasColumnName("provider_user_id");
            entity.Property(e => e.RefreshTokenEncrypted).HasColumnName("refresh_token_encrypted");
            entity.Property(e => e.Scopes)
                .HasMaxLength(500)
                .HasColumnName("scopes");
            entity.Property(e => e.TokenExpiresAt).HasColumnName("token_expires_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.OauthConnections)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_oauth_user");
        });

        modelBuilder.Entity<PersonalInflation>(entity =>
        {
            entity.HasKey(e => e.InflationId);

            entity.ToTable("personal_inflation", "fin");

            entity.HasIndex(e => new { e.UserId, e.ProductName, e.PurchaseDate }, "IX_inflation_user_product");

            entity.Property(e => e.InflationId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("inflation_id");
            entity.Property(e => e.Barcode)
                .HasMaxLength(50)
                .HasColumnName("barcode");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValue("TRY")
                .IsFixedLength()
                .HasColumnName("currency_code");
            entity.Property(e => e.MerchantName)
                .HasMaxLength(200)
                .HasColumnName("merchant_name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("price");
            entity.Property(e => e.ProductName)
                .HasMaxLength(200)
                .HasColumnName("product_name");
            entity.Property(e => e.PurchaseDate).HasColumnName("purchase_date");
            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
            entity.Property(e => e.Unit)
                .HasMaxLength(30)
                .HasColumnName("unit");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Transaction).WithMany(p => p.PersonalInflations)
                .HasForeignKey(d => d.TransactionId)
                .HasConstraintName("FK_pi_transaction");

            entity.HasOne(d => d.User).WithMany(p => p.PersonalInflations)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_pi_user");
        });

        modelBuilder.Entity<PortfolioSnapshot>(entity =>
        {
            entity.HasKey(e => e.SnapshotId);

            entity.ToTable("portfolio_snapshots", "portfolio");

            entity.Property(e => e.SnapshotId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("snapshot_id");
            entity.Property(e => e.AssetBreakdown).HasColumnName("asset_breakdown");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.PositionsSnapshot).HasColumnName("positions_snapshot");
            entity.Property(e => e.SnapshotDate).HasColumnName("snapshot_date");
            entity.Property(e => e.SnapshotType)
                .HasMaxLength(15)
                .HasDefaultValue("monthly")
                .HasColumnName("snapshot_type");
            entity.Property(e => e.TotalCostTry)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("total_cost_try");
            entity.Property(e => e.TotalPnlPct)
                .HasColumnType("decimal(10, 4)")
                .HasColumnName("total_pnl_pct");
            entity.Property(e => e.TotalPnlTry)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("total_pnl_try");
            entity.Property(e => e.TotalValueTry)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("total_value_try");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.PortfolioSnapshots)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_ps_user");
        });

        modelBuilder.Entity<Prediction>(entity =>
        {
            entity.ToTable("predictions", "ai");

            entity.Property(e => e.PredictionId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("prediction_id");
            entity.Property(e => e.ActualValue)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("actual_value");
            entity.Property(e => e.ConfidenceHigh)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("confidence_high");
            entity.Property(e => e.ConfidenceLow)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("confidence_low");
            entity.Property(e => e.ConfidenceScore)
                .HasColumnType("decimal(5, 4)")
                .HasColumnName("confidence_score");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.InputFeatures).HasColumnName("input_features");
            entity.Property(e => e.ModelVersion)
                .HasMaxLength(20)
                .HasColumnName("model_version");
            entity.Property(e => e.PredictedValue)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("predicted_value");
            entity.Property(e => e.PredictionType)
                .HasMaxLength(30)
                .HasColumnName("prediction_type");
            entity.Property(e => e.TargetDate).HasColumnName("target_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Predictions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_pred_user");
        });

        modelBuilder.Entity<PriceAlert>(entity =>
        {
            entity.HasKey(e => e.AlertId);

            entity.ToTable("price_alerts", "portfolio");

            entity.HasIndex(e => new { e.Symbol, e.AssetType, e.IsActive, e.IsTriggered }, "IX_price_alerts_symbol").HasFilter("([is_active]=(1))");

            entity.HasIndex(e => new { e.UserId, e.IsActive, e.AssetType, e.CreatedAt }, "IX_price_alerts_user").IsDescending(false, false, false, true);

            entity.Property(e => e.AlertId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("alert_id");
            entity.Property(e => e.AlertLabel)
                .HasMaxLength(150)
                .HasColumnName("alert_label");
            entity.Property(e => e.AlertType)
                .HasMaxLength(20)
                .HasColumnName("alert_type");
            entity.Property(e => e.AssetId).HasColumnName("asset_id");
            entity.Property(e => e.AssetType)
                .HasMaxLength(15)
                .HasColumnName("asset_type");
            entity.Property(e => e.AutoReset).HasColumnName("auto_reset");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsTriggered).HasColumnName("is_triggered");
            entity.Property(e => e.LastKnownPrice)
                .HasColumnType("decimal(18, 8)")
                .HasColumnName("last_known_price");
            entity.Property(e => e.LastPriceUpdatedAt).HasColumnName("last_price_updated_at");
            entity.Property(e => e.NotificationChannel)
                .HasMaxLength(10)
                .HasDefaultValue("push")
                .HasColumnName("notification_channel");
            entity.Property(e => e.PreAlertPct)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("pre_alert_pct");
            entity.Property(e => e.RepeatCount).HasColumnName("repeat_count");
            entity.Property(e => e.Symbol)
                .HasMaxLength(20)
                .HasColumnName("symbol");
            entity.Property(e => e.ThresholdCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValue("TRY")
                .IsFixedLength()
                .HasColumnName("threshold_currency");
            entity.Property(e => e.ThresholdValue)
                .HasColumnType("decimal(18, 8)")
                .HasColumnName("threshold_value");
            entity.Property(e => e.TriggerCount).HasColumnName("trigger_count");
            entity.Property(e => e.TriggeredAt).HasColumnName("triggered_at");
            entity.Property(e => e.TriggeredPrice)
                .HasColumnType("decimal(18, 8)")
                .HasColumnName("triggered_price");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Asset).WithMany(p => p.PriceAlerts)
                .HasForeignKey(d => d.AssetId)
                .HasConstraintName("FK_pa_asset");

            entity.HasOne(d => d.User).WithMany(p => p.PriceAlerts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_pa_user");
        });

        modelBuilder.Entity<PriceHistory>(entity =>
        {
            entity.HasKey(e => e.PriceId);

            entity.ToTable("price_history", "portfolio", tb => tb.HasTrigger("trg_check_price_alerts"));

            entity.HasIndex(e => new { e.Symbol, e.PriceDate }, "IX_price_history_symbol").IsDescending(false, true);

            entity.HasIndex(e => new { e.Symbol, e.AssetType, e.PriceDate }, "UQ_price_history").IsUnique();

            entity.Property(e => e.PriceId).HasColumnName("price_id");
            entity.Property(e => e.AssetType)
                .HasMaxLength(15)
                .HasColumnName("asset_type");
            entity.Property(e => e.ClosePrice)
                .HasColumnType("decimal(18, 8)")
                .HasColumnName("close_price");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("currency_code");
            entity.Property(e => e.HighPrice)
                .HasColumnType("decimal(18, 8)")
                .HasColumnName("high_price");
            entity.Property(e => e.LowPrice)
                .HasColumnType("decimal(18, 8)")
                .HasColumnName("low_price");
            entity.Property(e => e.OpenPrice)
                .HasColumnType("decimal(18, 8)")
                .HasColumnName("open_price");
            entity.Property(e => e.PriceDate).HasColumnName("price_date");
            entity.Property(e => e.Source)
                .HasMaxLength(50)
                .HasColumnName("source");
            entity.Property(e => e.Symbol)
                .HasMaxLength(20)
                .HasColumnName("symbol");
            entity.Property(e => e.Volume)
                .HasColumnType("decimal(28, 4)")
                .HasColumnName("volume");
        });

        modelBuilder.Entity<PriceUpdateSchedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("PK_price_schedules");

            entity.ToTable("price_update_schedules", "portfolio");

            entity.HasIndex(e => new { e.NextUpdateAt, e.IsActive }, "IX_price_schedule_next").HasFilter("([is_active]=(1))");

            entity.HasIndex(e => new { e.Symbol, e.AssetType }, "UQ_price_schedule").IsUnique();

            entity.Property(e => e.ScheduleId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("schedule_id");
            entity.Property(e => e.ActiveWeekdays)
                .HasDefaultValue((byte)62)
                .HasColumnName("active_weekdays");
            entity.Property(e => e.AssetType)
                .HasMaxLength(15)
                .HasColumnName("asset_type");
            entity.Property(e => e.ConsecutiveFailures).HasColumnName("consecutive_failures");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.FallbackApiSource)
                .HasMaxLength(50)
                .HasColumnName("fallback_api_source");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.LastUpdateAt).HasColumnName("last_update_at");
            entity.Property(e => e.LastUpdateStatus)
                .HasMaxLength(15)
                .HasColumnName("last_update_status");
            entity.Property(e => e.MarketCloseTime).HasColumnName("market_close_time");
            entity.Property(e => e.MarketOpenTime).HasColumnName("market_open_time");
            entity.Property(e => e.MarketTimezone)
                .HasMaxLength(50)
                .HasColumnName("market_timezone");
            entity.Property(e => e.MaxRetryCount)
                .HasDefaultValue((byte)3)
                .HasColumnName("max_retry_count");
            entity.Property(e => e.NextUpdateAt).HasColumnName("next_update_at");
            entity.Property(e => e.PrimaryApiSource)
                .HasMaxLength(50)
                .HasColumnName("primary_api_source");
            entity.Property(e => e.RetryDelayMinutes)
                .HasDefaultValue((byte)5)
                .HasColumnName("retry_delay_minutes");
            entity.Property(e => e.Symbol)
                .HasMaxLength(20)
                .HasColumnName("symbol");
            entity.Property(e => e.UpdateFrequencyMinutes).HasColumnName("update_frequency_minutes");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<RateLimitBucket>(entity =>
        {
            entity.HasKey(e => e.BucketId);

            entity.ToTable("rate_limit_buckets", "auth");

            entity.HasIndex(e => new { e.IpAddressHash, e.Resource, e.WindowEnd }, "IX_rate_limit_ip");

            entity.HasIndex(e => new { e.Resource, e.WindowEnd, e.IsBlocked }, "IX_rate_limit_resource");

            entity.Property(e => e.BucketId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("bucket_id");
            entity.Property(e => e.BlockReason)
                .HasMaxLength(200)
                .HasColumnName("block_reason");
            entity.Property(e => e.BlockedUntil).HasColumnName("blocked_until");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.IpAddressHash)
                .HasMaxLength(64)
                .HasColumnName("ip_address_hash");
            entity.Property(e => e.IsBlocked).HasColumnName("is_blocked");
            entity.Property(e => e.LastRequestAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("last_request_at");
            entity.Property(e => e.MaxAllowed).HasColumnName("max_allowed");
            entity.Property(e => e.RequestCount)
                .HasDefaultValue(1)
                .HasColumnName("request_count");
            entity.Property(e => e.Resource)
                .HasMaxLength(100)
                .HasColumnName("resource");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.ViolationCount).HasColumnName("violation_count");
            entity.Property(e => e.WindowEnd).HasColumnName("window_end");
            entity.Property(e => e.WindowStart)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("window_start");

            entity.HasOne(d => d.User).WithMany(p => p.RateLimitBuckets)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_rlb_user");
        });

        modelBuilder.Entity<Receipt>(entity =>
        {
            entity.ToTable("receipts", "fin");

            entity.Property(e => e.ReceiptId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("receipt_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("currency_code");
            entity.Property(e => e.ImageHash)
                .HasMaxLength(256)
                .HasColumnName("image_hash");
            entity.Property(e => e.ImagePathEncrypted).HasColumnName("image_path_encrypted");
            entity.Property(e => e.MerchantName)
                .HasMaxLength(200)
                .HasColumnName("merchant_name");
            entity.Property(e => e.OcrConfidence)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("ocr_confidence");
            entity.Property(e => e.OcrRawText).HasColumnName("ocr_raw_text");
            entity.Property(e => e.ProcessingStatus)
                .HasMaxLength(20)
                .HasDefaultValue("pending")
                .HasColumnName("processing_status");
            entity.Property(e => e.ReceiptDate).HasColumnName("receipt_date");
            entity.Property(e => e.ReceiptItems).HasColumnName("receipt_items");
            entity.Property(e => e.Source)
                .HasMaxLength(20)
                .HasDefaultValue("camera")
                .HasColumnName("source");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("total_amount");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Receipts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_receipts_user");
        });

        modelBuilder.Entity<RecurringRule>(entity =>
        {
            entity.HasKey(e => e.RuleId);

            entity.ToTable("recurring_rules", "fin");

            entity.Property(e => e.RuleId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("rule_id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("amount");
            entity.Property(e => e.AutoCreate).HasColumnName("auto_create");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValue("TRY")
                .IsFixedLength()
                .HasColumnName("currency_code");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.Frequency)
                .HasMaxLength(15)
                .HasColumnName("frequency");
            entity.Property(e => e.FrequencyInterval)
                .HasDefaultValue((short)1)
                .HasColumnName("frequency_interval");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.NextDueDate).HasColumnName("next_due_date");
            entity.Property(e => e.Type)
                .HasMaxLength(10)
                .HasColumnName("type");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Account).WithMany(p => p.RecurringRules)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_rr_account");

            entity.HasOne(d => d.Category).WithMany(p => p.RecurringRules)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_rr_category");

            entity.HasOne(d => d.User).WithMany(p => p.RecurringRules)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_rr_user");
        });

        modelBuilder.Entity<ReportDefinition>(entity =>
        {
            entity.HasKey(e => e.ReportDefId);

            entity.ToTable("report_definitions", "report");

            entity.Property(e => e.ReportDefId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("report_def_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsSystem).HasColumnName("is_system");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.OutputFormat)
                .HasMaxLength(10)
                .HasDefaultValue("pdf")
                .HasColumnName("output_format");
            entity.Property(e => e.Parameters)
                .HasDefaultValue("{}")
                .HasColumnName("parameters");
            entity.Property(e => e.ReportType)
                .HasMaxLength(30)
                .HasColumnName("report_type");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.ReportDefinitions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_rd_user");
        });

        modelBuilder.Entity<SavingGoal>(entity =>
        {
            entity.HasKey(e => e.GoalId);

            entity.ToTable("saving_goals", "fin", tb => tb.HasTrigger("trg_goals_updated_at"));

            entity.HasIndex(e => new { e.UserId, e.Status, e.TargetDate }, "IX_goals_user_status");

            entity.Property(e => e.GoalId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("goal_id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.ColorHex)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("color_hex");
            entity.Property(e => e.CompletedAt).HasColumnName("completed_at");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValue("TRY")
                .IsFixedLength()
                .HasColumnName("currency_code");
            entity.Property(e => e.CurrentAmount)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("current_amount");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Icon)
                .HasMaxLength(50)
                .HasColumnName("icon");
            entity.Property(e => e.MonthlyContribution)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("monthly_contribution");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.Priority)
                .HasDefaultValue((byte)2)
                .HasColumnName("priority");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.Status)
                .HasMaxLength(15)
                .HasDefaultValue("active")
                .HasColumnName("status");
            entity.Property(e => e.TargetAmount)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("target_amount");
            entity.Property(e => e.TargetDate).HasColumnName("target_date");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Account).WithMany(p => p.SavingGoals)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_goals_account");

            entity.HasOne(d => d.User).WithMany(p => p.SavingGoals)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_goals_user");
        });

        modelBuilder.Entity<ScheduledJob>(entity =>
        {
            entity.HasKey(e => e.JobId);

            entity.ToTable("scheduled_jobs", "report");

            entity.HasIndex(e => new { e.NextRunAt, e.IsActive }, "IX_scheduled_jobs_next").HasFilter("([is_active]=(1))");

            entity.Property(e => e.JobId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("job_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.CronExpression)
                .HasMaxLength(100)
                .HasColumnName("cron_expression");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.JobType)
                .HasMaxLength(50)
                .HasColumnName("job_type");
            entity.Property(e => e.LastRunAt).HasColumnName("last_run_at");
            entity.Property(e => e.LastRunStatus)
                .HasMaxLength(15)
                .HasColumnName("last_run_status");
            entity.Property(e => e.NextRunAt).HasColumnName("next_run_at");
            entity.Property(e => e.Parameters).HasColumnName("parameters");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.ScheduledJobs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_sj_user");
        });

        modelBuilder.Entity<SecurityEvent>(entity =>
        {
            entity.HasKey(e => e.EventId);

            entity.ToTable("security_events", "audit");

            entity.HasIndex(e => new { e.Severity, e.IsResolved, e.CreatedAt }, "IX_security_events_severity").IsDescending(false, false, true);

            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.DeviceInfo)
                .HasMaxLength(500)
                .HasColumnName("device_info");
            entity.Property(e => e.EventType)
                .HasMaxLength(50)
                .HasColumnName("event_type");
            entity.Property(e => e.IpAddressEncrypted)
                .HasMaxLength(256)
                .HasColumnName("ip_address_encrypted");
            entity.Property(e => e.IsResolved).HasColumnName("is_resolved");
            entity.Property(e => e.Severity)
                .HasMaxLength(10)
                .HasDefaultValue("info")
                .HasColumnName("severity");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.ToTable("sessions", "auth");

            entity.HasIndex(e => e.RefreshTokenHash, "IX_sessions_token");

            entity.HasIndex(e => new { e.UserId, e.IsRevoked, e.ExpiresAt }, "IX_sessions_user_active").IsDescending(false, false, true);

            entity.HasIndex(e => e.RefreshTokenHash, "UQ_sessions_token").IsUnique();

            entity.Property(e => e.SessionId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("session_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.DeviceId).HasColumnName("device_id");
            entity.Property(e => e.ExpiresAt).HasColumnName("expires_at");
            entity.Property(e => e.IpAddressEncrypted)
                .HasMaxLength(256)
                .HasColumnName("ip_address_encrypted");
            entity.Property(e => e.IsRevoked).HasColumnName("is_revoked");
            entity.Property(e => e.RefreshTokenHash)
                .HasMaxLength(512)
                .HasColumnName("refresh_token_hash");
            entity.Property(e => e.UserAgent)
                .HasMaxLength(500)
                .HasColumnName("user_agent");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Device).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.DeviceId)
                .HasConstraintName("FK_sessions_device");

            entity.HasOne(d => d.User).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_sessions_user");
        });

        modelBuilder.Entity<SpendingPattern>(entity =>
        {
            entity.HasKey(e => e.PatternId);

            entity.ToTable("spending_patterns", "ai");

            entity.HasIndex(e => new { e.UserId, e.CategoryId, e.PeriodType }, "IX_spending_patterns_lookup");

            entity.Property(e => e.PatternId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("pattern_id");
            entity.Property(e => e.AvgAmount)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("avg_amount");
            entity.Property(e => e.CalculatedFrom).HasColumnName("calculated_from");
            entity.Property(e => e.CalculatedTo).HasColumnName("calculated_to");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.ConfidenceScore)
                .HasColumnType("decimal(5, 4)")
                .HasColumnName("confidence_score");
            entity.Property(e => e.DayOfWeek).HasColumnName("day_of_week");
            entity.Property(e => e.HourOfDay).HasColumnName("hour_of_day");
            entity.Property(e => e.LastUpdatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("last_updated_at");
            entity.Property(e => e.MedianAmount)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("median_amount");
            entity.Property(e => e.ModelVersion)
                .HasMaxLength(20)
                .HasColumnName("model_version");
            entity.Property(e => e.P95Amount)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("p95_amount");
            entity.Property(e => e.PeriodType)
                .HasMaxLength(10)
                .HasColumnName("period_type");
            entity.Property(e => e.SampleCount).HasColumnName("sample_count");
            entity.Property(e => e.StddevAmount)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("stddev_amount");
            entity.Property(e => e.TypicalHours)
                .HasMaxLength(200)
                .HasColumnName("typical_hours");
            entity.Property(e => e.TypicalMerchants).HasColumnName("typical_merchants");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Category).WithMany(p => p.SpendingPatterns)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_sp_category");

            entity.HasOne(d => d.User).WithMany(p => p.SpendingPatterns)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_sp_user");
        });

        modelBuilder.Entity<StakingReward>(entity =>
        {
            entity.HasKey(e => e.RewardId);

            entity.ToTable("staking_rewards", "portfolio", tb => tb.HasTrigger("trg_compound_staking"));

            entity.HasIndex(e => new { e.UserId, e.RewardDate }, "IX_staking_user_date").IsDescending(false, true);

            entity.Property(e => e.RewardId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("reward_id");
            entity.Property(e => e.ApyRate)
                .HasColumnType("decimal(8, 4)")
                .HasColumnName("apy_rate");
            entity.Property(e => e.AssetId).HasColumnName("asset_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.IsAutoCompound).HasColumnName("is_auto_compound");
            entity.Property(e => e.Notes)
                .HasMaxLength(300)
                .HasColumnName("notes");
            entity.Property(e => e.Platform)
                .HasMaxLength(100)
                .HasColumnName("platform");
            entity.Property(e => e.PriceAtReward)
                .HasColumnType("decimal(18, 8)")
                .HasColumnName("price_at_reward");
            entity.Property(e => e.Quantity)
                .HasColumnType("decimal(28, 10)")
                .HasColumnName("quantity");
            entity.Property(e => e.RewardDate).HasColumnName("reward_date");
            entity.Property(e => e.RewardSymbol)
                .HasMaxLength(20)
                .HasColumnName("reward_symbol");
            entity.Property(e => e.RewardType)
                .HasMaxLength(20)
                .HasDefaultValue("staking")
                .HasColumnName("reward_type");
            entity.Property(e => e.TxHash)
                .HasMaxLength(100)
                .HasColumnName("tx_hash");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.ValueTry)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("value_try");

            entity.HasOne(d => d.Asset).WithMany(p => p.StakingRewards)
                .HasForeignKey(d => d.AssetId)
                .HasConstraintName("FK_sr_asset");

            entity.HasOne(d => d.User).WithMany(p => p.StakingRewards)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_sr_user");
        });

        modelBuilder.Entity<Subscription>(entity =>
        {
            entity.ToTable("subscriptions", "ai");

            entity.Property(e => e.SubscriptionId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("subscription_id");
            entity.Property(e => e.BillingDay).HasColumnName("billing_day");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValue("TRY")
                .IsFixedLength()
                .HasColumnName("currency_code");
            entity.Property(e => e.DetectedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("detected_at");
            entity.Property(e => e.DetectionMethod)
                .HasMaxLength(20)
                .HasDefaultValue("ai")
                .HasColumnName("detection_method");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.LastChargeDate).HasColumnName("last_charge_date");
            entity.Property(e => e.MonthlyCost)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("monthly_cost");
            entity.Property(e => e.NextChargeDate).HasColumnName("next_charge_date");
            entity.Property(e => e.RecurringRuleId).HasColumnName("recurring_rule_id");
            entity.Property(e => e.ServiceName)
                .HasMaxLength(150)
                .HasColumnName("service_name");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Category).WithMany(p => p.Subscriptions)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_sub_category");

            entity.HasOne(d => d.RecurringRule).WithMany(p => p.Subscriptions)
                .HasForeignKey(d => d.RecurringRuleId)
                .HasConstraintName("FK_sub_rule");

            entity.HasOne(d => d.User).WithMany(p => p.Subscriptions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_sub_user");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.ToTable("tags", "fin");

            entity.HasIndex(e => new { e.UserId, e.Name }, "UQ_tags_user_name").IsUnique();

            entity.Property(e => e.TagId).HasColumnName("tag_id");
            entity.Property(e => e.ColorHex)
                .HasMaxLength(7)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("color_hex");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.Icon)
                .HasMaxLength(50)
                .HasColumnName("icon");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.UsageCount).HasColumnName("usage_count");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Tags)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_tags_user");
        });

        modelBuilder.Entity<TaxEvent>(entity =>
        {
            entity.ToTable("tax_events", "fin");

            entity.HasIndex(e => new { e.UserId, e.EventDate, e.TaxEventType }, "IX_tax_user_year");

            entity.Property(e => e.TaxEventId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("tax_event_id");
            entity.Property(e => e.AssetTxId).HasColumnName("asset_tx_id");
            entity.Property(e => e.CostBasis)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("cost_basis");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.EstimatedTax)
                .HasComputedColumnSql("(case when [is_tax_exempt]=(1) then CONVERT([decimal](18,4),(0)) when [tax_rate] IS NOT NULL AND ([proceeds]-[cost_basis])>(0) then round(([proceeds]-[cost_basis])*[tax_rate],(2)) else CONVERT([decimal](18,4),(0)) end)", false)
                .HasColumnType("decimal(25, 8)")
                .HasColumnName("estimated_tax");
            entity.Property(e => e.EventDate).HasColumnName("event_date");
            entity.Property(e => e.GrossGainLoss)
                .HasComputedColumnSql("([proceeds]-[cost_basis])", false)
                .HasColumnType("decimal(19, 4)")
                .HasColumnName("gross_gain_loss");
            entity.Property(e => e.HoldingDays).HasColumnName("holding_days");
            entity.Property(e => e.IsTaxExempt).HasColumnName("is_tax_exempt");
            entity.Property(e => e.Jurisdiction)
                .HasMaxLength(10)
                .HasDefaultValue("TR")
                .HasColumnName("jurisdiction");
            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .HasColumnName("notes");
            entity.Property(e => e.Proceeds)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("proceeds");
            entity.Property(e => e.StakingRewardId).HasColumnName("staking_reward_id");
            entity.Property(e => e.Status)
                .HasMaxLength(15)
                .HasDefaultValue("estimated")
                .HasColumnName("status");
            entity.Property(e => e.TaxEventType)
                .HasMaxLength(30)
                .HasColumnName("tax_event_type");
            entity.Property(e => e.TaxRate)
                .HasColumnType("decimal(5, 4)")
                .HasColumnName("tax_rate");
            entity.Property(e => e.TaxYear)
                .HasComputedColumnSql("(CONVERT([smallint],datepart(year,[event_date])))", false)
                .HasColumnName("tax_year");
            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.WithholdingTax)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("withholding_tax");

            entity.HasOne(d => d.AssetTx).WithMany(p => p.TaxEvents)
                .HasForeignKey(d => d.AssetTxId)
                .HasConstraintName("FK_tax_asset_tx");

            entity.HasOne(d => d.StakingReward).WithMany(p => p.TaxEvents)
                .HasForeignKey(d => d.StakingRewardId)
                .HasConstraintName("FK_tax_staking");

            entity.HasOne(d => d.Transaction).WithMany(p => p.TaxEvents)
                .HasForeignKey(d => d.TransactionId)
                .HasConstraintName("FK_tax_transaction");

            entity.HasOne(d => d.User).WithMany(p => p.TaxEvents)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_tax_user");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.ToTable("transactions", "fin", tb => tb.HasTrigger("trg_refresh_monthly_summary"));

            entity.HasIndex(e => new { e.AccountId, e.TransactionDate }, "IX_transactions_account_date").IsDescending(false, true);

            entity.HasIndex(e => new { e.UserId, e.IsAnomaly, e.TransactionDate }, "IX_transactions_anomaly")
                .IsDescending(false, false, true)
                .HasFilter("([is_anomaly]=(1))");

            entity.HasIndex(e => new { e.CategoryId, e.Type, e.TransactionDate }, "IX_transactions_category");

            entity.HasIndex(e => new { e.UserId, e.TransactionDate }, "IX_transactions_user_date").IsDescending(false, true);

            entity.Property(e => e.TransactionId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("transaction_id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("amount");
            entity.Property(e => e.AmountInBase)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("amount_in_base");
            entity.Property(e => e.BillId).HasColumnName("bill_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("currency_code");
            entity.Property(e => e.DescriptionEncrypted).HasColumnName("description_encrypted");
            entity.Property(e => e.DuplicateOf).HasColumnName("duplicate_of");
            entity.Property(e => e.ExchangeRate)
                .HasDefaultValue(100000000m)
                .HasColumnType("decimal(18, 8)")
                .HasColumnName("exchange_rate");
            entity.Property(e => e.IncomeSourceId).HasColumnName("income_source_id");
            entity.Property(e => e.IsAnomaly).HasColumnName("is_anomaly");
            entity.Property(e => e.IsDuplicate).HasColumnName("is_duplicate");
            entity.Property(e => e.IsVerified).HasColumnName("is_verified");
            entity.Property(e => e.KeyVersion)
                .HasDefaultValue((short)1)
                .HasColumnName("key_version");
            entity.Property(e => e.MerchantName)
                .HasMaxLength(200)
                .HasColumnName("merchant_name");
            entity.Property(e => e.RawSourceText).HasColumnName("raw_source_text");
            entity.Property(e => e.ReceiptId).HasColumnName("receipt_id");
            entity.Property(e => e.RecurringRuleId).HasColumnName("recurring_rule_id");
            entity.Property(e => e.Source)
                .HasMaxLength(20)
                .HasDefaultValue("manual")
                .HasColumnName("source");
            entity.Property(e => e.TransactionDate).HasColumnName("transaction_date");
            entity.Property(e => e.TransactionTime).HasColumnName("transaction_time");
            entity.Property(e => e.Type)
                .HasMaxLength(10)
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Account).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tx_account");

            entity.HasOne(d => d.Category).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_tx_category");

            entity.HasOne(d => d.DuplicateOfNavigation).WithMany(p => p.InverseDuplicateOfNavigation)
                .HasForeignKey(d => d.DuplicateOf)
                .HasConstraintName("FK_tx_duplicate");

            entity.HasOne(d => d.IncomeSource).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.IncomeSourceId)
                .HasConstraintName("FK_tx_income_source");

            entity.HasOne(d => d.KeyVersionNavigation).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.KeyVersion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tx_key_version");

            entity.HasOne(d => d.Receipt).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.ReceiptId)
                .HasConstraintName("FK_tx_receipt");

            entity.HasOne(d => d.RecurringRule).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.RecurringRuleId)
                .HasConstraintName("FK_tx_recurring");

            entity.HasOne(d => d.User).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_tx_user");
        });

        modelBuilder.Entity<TransactionTag>(entity =>
        {
            entity.HasKey(e => new { e.TransactionId, e.TagId });

            entity.ToTable("transaction_tags", "fin", tb => tb.HasTrigger("trg_tag_usage_count"));

            entity.HasIndex(e => new { e.TagId, e.TransactionId }, "IX_tt_tag_transaction");

            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
            entity.Property(e => e.TagId).HasColumnName("tag_id");
            entity.Property(e => e.TaggedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("tagged_at");
            entity.Property(e => e.TaggedBy)
                .HasMaxLength(15)
                .HasDefaultValue("user")
                .HasColumnName("tagged_by");

            entity.HasOne(d => d.Tag).WithMany(p => p.TransactionTags)
                .HasForeignKey(d => d.TagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tt_tag");

            entity.HasOne(d => d.Transaction).WithMany(p => p.TransactionTags)
                .HasForeignKey(d => d.TransactionId)
                .HasConstraintName("FK_tt_transaction");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users", "auth", tb =>
                {
                    tb.HasTrigger("trg_soft_delete_user");
                    tb.HasTrigger("trg_users_updated_at");
                });

            entity.HasIndex(e => e.EmailHash, "UQ_users_email_hash").IsUnique();

            entity.Property(e => e.UserId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("user_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.DeletedAt).HasColumnName("deleted_at");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(100)
                .HasColumnName("display_name");
            entity.Property(e => e.EmailEncrypted).HasColumnName("email_encrypted");
            entity.Property(e => e.EmailHash)
                .HasMaxLength(256)
                .HasColumnName("email_hash");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsEmailVerified).HasColumnName("is_email_verified");
            entity.Property(e => e.KeyVersion)
                .HasDefaultValue((short)1)
                .HasColumnName("key_version");
            entity.Property(e => e.LastLoginAt).HasColumnName("last_login_at");
            entity.Property(e => e.MfaEnabled).HasColumnName("mfa_enabled");
            entity.Property(e => e.MfaSecretEncrypted).HasColumnName("mfa_secret_encrypted");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(512)
                .HasColumnName("password_hash");
            entity.Property(e => e.PhoneEncrypted).HasColumnName("phone_encrypted");
            entity.Property(e => e.PreferredCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValue("TRY")
                .IsFixedLength()
                .HasColumnName("preferred_currency");
            entity.Property(e => e.PreferredLanguage)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasDefaultValue("tr-TR")
                .IsFixedLength()
                .HasColumnName("preferred_language");
            entity.Property(e => e.Salt)
                .HasMaxLength(128)
                .HasColumnName("salt");
            entity.Property(e => e.Timezone)
                .HasMaxLength(50)
                .HasDefaultValue("Europe/Istanbul")
                .HasColumnName("timezone");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.KeyVersionNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.KeyVersion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_users_key_version");
        });

        modelBuilder.Entity<UserFeatureFlag>(entity =>
        {
            entity.HasKey(e => e.FlagId);

            entity.ToTable("user_feature_flags", "auth");

            entity.HasIndex(e => new { e.UserId, e.FeatureKey, e.IsEnabled }, "IX_feature_flags_lookup");

            entity.HasIndex(e => new { e.UserId, e.FeatureKey }, "UQ_user_feature").IsUnique();

            entity.Property(e => e.FlagId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("flag_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("created_at");
            entity.Property(e => e.EnabledFrom).HasColumnName("enabled_from");
            entity.Property(e => e.EnabledUntil).HasColumnName("enabled_until");
            entity.Property(e => e.FeatureKey)
                .HasMaxLength(60)
                .HasColumnName("feature_key");
            entity.Property(e => e.IsEnabled).HasColumnName("is_enabled");
            entity.Property(e => e.OverrideReason)
                .HasMaxLength(200)
                .HasColumnName("override_reason");
            entity.Property(e => e.SetBy)
                .HasMaxLength(20)
                .HasDefaultValue("user")
                .HasColumnName("set_by");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.FeatureKeyNavigation).WithMany(p => p.UserFeatureFlags)
                .HasForeignKey(d => d.FeatureKey)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_uff_feature");

            entity.HasOne(d => d.User).WithMany(p => p.UserFeatureFlags)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_uff_user");
        });

        modelBuilder.Entity<Watchlist>(entity =>
        {
            entity.ToTable("watchlist", "portfolio");

            entity.HasIndex(e => new { e.UserId, e.Symbol, e.AssetType }, "UQ_watchlist").IsUnique();

            entity.Property(e => e.WatchlistId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("watchlist_id");
            entity.Property(e => e.AddedAt)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("added_at");
            entity.Property(e => e.AlertPriceAbove)
                .HasColumnType("decimal(18, 8)")
                .HasColumnName("alert_price_above");
            entity.Property(e => e.AlertPriceBelow)
                .HasColumnType("decimal(18, 8)")
                .HasColumnName("alert_price_below");
            entity.Property(e => e.AssetType)
                .HasMaxLength(15)
                .HasColumnName("asset_type");
            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .HasColumnName("notes");
            entity.Property(e => e.Symbol)
                .HasMaxLength(20)
                .HasColumnName("symbol");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Watchlists)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_wl_user");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
