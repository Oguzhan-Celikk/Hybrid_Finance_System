using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class GdprRequest
{
    public Guid RequestId { get; set; }

    public Guid UserId { get; set; }

    public string RequestType { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string? Reason { get; set; }

    public string? ProcessorNotes { get; set; }

    public DateTime RequestedAt { get; set; }

    public DateTime? CompletedAt { get; set; }

    public DateTime DeadlineAt { get; set; }

    public virtual User User { get; set; } = null!;
}
