using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class OauthConnection
{
    public Guid ConnectionId { get; set; }

    public Guid UserId { get; set; }

    public string Provider { get; set; } = null!;

    public string ProviderUserId { get; set; } = null!;

    public byte[] AccessTokenEncrypted { get; set; } = null!;

    public byte[]? RefreshTokenEncrypted { get; set; }

    public DateTime TokenExpiresAt { get; set; }

    public string Scopes { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime ConnectedAt { get; set; }

    public DateTime? LastUsedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
