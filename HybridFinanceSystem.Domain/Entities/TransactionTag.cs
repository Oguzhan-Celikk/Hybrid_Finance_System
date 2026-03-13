using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class TransactionTag
{
    public Guid TransactionId { get; set; }

    public int TagId { get; set; }

    public DateTime TaggedAt { get; set; }

    public string TaggedBy { get; set; } = null!;

    public virtual Tag Tag { get; set; } = null!;

    public virtual Transaction Transaction { get; set; } = null!;
}
