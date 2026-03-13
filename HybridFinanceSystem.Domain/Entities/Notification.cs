using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class Notification
{
    public Guid NotificationId { get; set; }

    public Guid UserId { get; set; }

    public string EventType { get; set; } = null!;

    public string Severity { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Body { get; set; } = null!;

    public string? ActionUrl { get; set; }

    public string? RelatedEntityType { get; set; }

    public string? RelatedEntityId { get; set; }

    public string Channel { get; set; } = null!;

    public string Status { get; set; } = null!;

    public bool IsRead { get; set; }

    public DateTime? SentAt { get; set; }

    public DateTime? ReadAt { get; set; }

    public DateTime? ExpiresAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
