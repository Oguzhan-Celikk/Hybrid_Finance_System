using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class AuditLog
{
    public long LogId { get; set; }

    public Guid? UserId { get; set; }

    public Guid? SessionId { get; set; }

    public string TableSchema { get; set; } = null!;

    public string TableName { get; set; } = null!;

    public string RecordId { get; set; } = null!;

    public string Operation { get; set; } = null!;

    public byte[]? OldValuesEncrypted { get; set; }

    public byte[]? NewValuesEncrypted { get; set; }

    public byte[]? IpAddressEncrypted { get; set; }

    public DateTime CreatedAt { get; set; }
}
