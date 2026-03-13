using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class User
{
    public Guid UserId { get; set; }

    public string EmailHash { get; set; } = null!;

    public byte[] EmailEncrypted { get; set; } = null!;

    public byte[]? PhoneEncrypted { get; set; }

    public string DisplayName { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Salt { get; set; } = null!;

    public bool IsActive { get; set; }

    public bool IsEmailVerified { get; set; }

    public string PreferredCurrency { get; set; } = null!;

    public string PreferredLanguage { get; set; } = null!;

    public string Timezone { get; set; } = null!;

    public bool MfaEnabled { get; set; }

    public byte[]? MfaSecretEncrypted { get; set; }

    public short KeyVersion { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public DateTime? LastLoginAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual ICollection<Anomaly> Anomalies { get; set; } = new List<Anomaly>();

    public virtual ICollection<AssetTransaction> AssetTransactions { get; set; } = new List<AssetTransaction>();

    public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    public virtual ICollection<Budget> Budgets { get; set; } = new List<Budget>();

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

    public virtual ICollection<Device> Devices { get; set; } = new List<Device>();

    public virtual ICollection<ForexPosition> ForexPositions { get; set; } = new List<ForexPosition>();

    public virtual ICollection<GdprRequest> GdprRequests { get; set; } = new List<GdprRequest>();

    public virtual ICollection<GeneratedReport> GeneratedReports { get; set; } = new List<GeneratedReport>();

    public virtual ICollection<IncomeSource> IncomeSources { get; set; } = new List<IncomeSource>();

    public virtual EncryptionKeyVersion KeyVersionNavigation { get; set; } = null!;

    public virtual ICollection<ModelTrainingLog> ModelTrainingLogs { get; set; } = new List<ModelTrainingLog>();

    public virtual ICollection<MonthlySummary> MonthlySummaries { get; set; } = new List<MonthlySummary>();

    public virtual ICollection<NotificationPreference> NotificationPreferences { get; set; } = new List<NotificationPreference>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<OauthConnection> OauthConnections { get; set; } = new List<OauthConnection>();

    public virtual ICollection<PersonalInflation> PersonalInflations { get; set; } = new List<PersonalInflation>();

    public virtual ICollection<PortfolioSnapshot> PortfolioSnapshots { get; set; } = new List<PortfolioSnapshot>();

    public virtual ICollection<Prediction> Predictions { get; set; } = new List<Prediction>();

    public virtual ICollection<PriceAlert> PriceAlerts { get; set; } = new List<PriceAlert>();

    public virtual ICollection<RateLimitBucket> RateLimitBuckets { get; set; } = new List<RateLimitBucket>();

    public virtual ICollection<Receipt> Receipts { get; set; } = new List<Receipt>();

    public virtual ICollection<RecurringRule> RecurringRules { get; set; } = new List<RecurringRule>();

    public virtual ICollection<ReportDefinition> ReportDefinitions { get; set; } = new List<ReportDefinition>();

    public virtual ICollection<SavingGoal> SavingGoals { get; set; } = new List<SavingGoal>();

    public virtual ICollection<ScheduledJob> ScheduledJobs { get; set; } = new List<ScheduledJob>();

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();

    public virtual ICollection<SpendingPattern> SpendingPatterns { get; set; } = new List<SpendingPattern>();

    public virtual ICollection<StakingReward> StakingRewards { get; set; } = new List<StakingReward>();

    public virtual ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();

    public virtual ICollection<TaxEvent> TaxEvents { get; set; } = new List<TaxEvent>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual ICollection<UserFeatureFlag> UserFeatureFlags { get; set; } = new List<UserFeatureFlag>();

    public virtual ICollection<Watchlist> Watchlists { get; set; } = new List<Watchlist>();
}
