using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class RateLimitBucket
{
    public Guid BucketId { get; set; }

    public Guid? UserId { get; set; }

    public string? IpAddressHash { get; set; }

    public string Resource { get; set; } = null!;

    public int RequestCount { get; set; }

    public int ViolationCount { get; set; }

    public int MaxAllowed { get; set; }

    public DateTime WindowStart { get; set; }

    public DateTime WindowEnd { get; set; }

    public bool IsBlocked { get; set; }

    public DateTime? BlockedUntil { get; set; }

    public string? BlockReason { get; set; }

    public DateTime LastRequestAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual User? User { get; set; }
}
