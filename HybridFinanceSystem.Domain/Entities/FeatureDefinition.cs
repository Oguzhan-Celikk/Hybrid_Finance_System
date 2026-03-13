using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class FeatureDefinition
{
    public string FeatureKey { get; set; } = null!;

    public string DisplayName { get; set; } = null!;

    public string? Description { get; set; }

    public string Category { get; set; } = null!;

    public bool DefaultEnabled { get; set; }

    public string? RequiresPlan { get; set; }

    public bool IsBeta { get; set; }

    public bool IsDeprecated { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<UserFeatureFlag> UserFeatureFlags { get; set; } = new List<UserFeatureFlag>();
}
