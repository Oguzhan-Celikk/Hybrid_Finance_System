using HybridFinanceSystem.Domain.Entities;

namespace HybridFinanceSystem.Application.Interfaces;

public interface IAnomalyLogRepository
{
    Task<IEnumerable<AnomalyLog>> GetAllAsync();
    Task<AnomalyLog?> GetByIdAsync(int id);
    Task<IEnumerable<AnomalyLog>> GetByTransactionIdAsync(long transactionId); // BIGINT -> long
    Task<IEnumerable<AnomalyLog>> GetHighConfidenceAnomaliesAsync(decimal minScore);
    Task AddAsync(AnomalyLog log);
    Task UpdateAsync(AnomalyLog log);
    Task DeleteAsync(int id);
}