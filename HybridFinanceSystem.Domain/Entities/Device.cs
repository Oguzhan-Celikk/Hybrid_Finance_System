using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class Device
{
    public Guid DeviceId { get; set; }

    public Guid UserId { get; set; }

    public string DeviceFingerprint { get; set; } = null!;

    public string? DeviceName { get; set; }

    public string Platform { get; set; } = null!;

    public byte[]? PushTokenEncrypted { get; set; }

    public bool IsTrusted { get; set; }

    public DateTime RegisteredAt { get; set; }

    public DateTime? LastSeenAt { get; set; }

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();

    public virtual User User { get; set; } = null!;
}
