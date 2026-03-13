using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class Session
{
    public Guid SessionId { get; set; }

    public Guid UserId { get; set; }

    public string RefreshTokenHash { get; set; } = null!;

    public Guid? DeviceId { get; set; }

    public byte[] IpAddressEncrypted { get; set; } = null!;

    public string? UserAgent { get; set; }

    public DateTime ExpiresAt { get; set; }

    public bool IsRevoked { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Device? Device { get; set; }

    public virtual User User { get; set; } = null!;
}
