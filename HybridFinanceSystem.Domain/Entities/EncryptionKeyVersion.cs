using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class EncryptionKeyVersion
{
    public short KeyVersionId { get; set; }

    public string KeyAlias { get; set; } = null!;

    public string Algorithm { get; set; } = null!;

    public string KeyDerivation { get; set; } = null!;

    public string KeyFingerprint { get; set; } = null!;

    public short KeyLengthBits { get; set; }

    public string Status { get; set; } = null!;

    public DateTime ActivatedAt { get; set; }

    public DateTime? RotatedAt { get; set; }

    public DateTime? RetireAt { get; set; }

    public DateTime? RevokedAt { get; set; }

    public int? TotalRecordsToMigrate { get; set; }

    public int MigratedRecords { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string? Notes { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
