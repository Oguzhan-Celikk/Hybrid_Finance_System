using System;
using System.Collections.Generic;

namespace HybridFinanceSystem.Domain.Entities;

public partial class ModelTrainingLog
{
    public Guid LogId { get; set; }

    public Guid UserId { get; set; }

    public string ModelName { get; set; } = null!;

    public string ModelVersion { get; set; } = null!;

    public DateOnly TrainingDataFrom { get; set; }

    public DateOnly TrainingDataTo { get; set; }

    public int SampleCount { get; set; }

    public decimal? AccuracyScore { get; set; }

    public string? Hyperparameters { get; set; }

    public DateTime TrainedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
