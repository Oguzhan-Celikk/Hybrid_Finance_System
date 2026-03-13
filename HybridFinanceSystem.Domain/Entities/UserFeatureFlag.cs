using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class UserFeatureFlag
{
    public Guid FlagId { get; set; }

    public Guid UserId { get; set; }

    public string FeatureKey { get; set; } = null!;

    public bool IsEnabled { get; set; }

    public string? OverrideReason { get; set; }

    public DateTime? EnabledFrom { get; set; }

    public DateTime? EnabledUntil { get; set; }

    public string SetBy { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual FeatureDefinition FeatureKeyNavigation { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
