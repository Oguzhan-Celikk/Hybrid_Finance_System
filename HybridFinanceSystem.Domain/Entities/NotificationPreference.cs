using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class NotificationPreference
{
    public Guid PrefId { get; set; }

    public Guid UserId { get; set; }

    public string EventType { get; set; } = null!;

    public bool PushEnabled { get; set; }

    public bool EmailEnabled { get; set; }

    public bool InAppEnabled { get; set; }

    public byte? QuietHoursStart { get; set; }

    public byte? QuietHoursEnd { get; set; }

    public string MinSeverity { get; set; } = null!;

    public DateTime UpdatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
