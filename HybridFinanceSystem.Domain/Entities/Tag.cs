using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class Tag
{
    public int TagId { get; set; }

    public Guid UserId { get; set; }

    public string Name { get; set; } = null!;

    public string? ColorHex { get; set; }

    public string? Icon { get; set; }

    public int UsageCount { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<TransactionTag> TransactionTags { get; set; } = new List<TransactionTag>();

    public virtual User User { get; set; } = null!;
}
