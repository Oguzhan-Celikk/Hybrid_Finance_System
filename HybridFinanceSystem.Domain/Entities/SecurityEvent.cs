using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class SecurityEvent
{
    public long EventId { get; set; }

    public Guid? UserId { get; set; }

    public string EventType { get; set; } = null!;

    public string Severity { get; set; } = null!;

    public string Description { get; set; } = null!;

    public byte[] IpAddressEncrypted { get; set; } = null!;

    public string? DeviceInfo { get; set; }

    public bool IsResolved { get; set; }

    public DateTime CreatedAt { get; set; }
}
