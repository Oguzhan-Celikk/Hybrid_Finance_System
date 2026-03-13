using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class ArchivalPolicy
{
    public Guid PolicyId { get; set; }

    public string TableSchema { get; set; } = null!;

    public string TableName { get; set; } = null!;

    public string DateColumn { get; set; } = null!;

    public int ArchiveAfterMonths { get; set; }

    public int? DeleteAfterMonths { get; set; }

    public string? ArchiveDestination { get; set; }

    public bool CompressionEnabled { get; set; }

    public string? WhereClause { get; set; }

    public bool IsActive { get; set; }

    public DateTime? LastRunAt { get; set; }

    public string? LastRunStatus { get; set; }

    public int? RowsArchivedLast { get; set; }

    public int? RowsDeletedLast { get; set; }

    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
