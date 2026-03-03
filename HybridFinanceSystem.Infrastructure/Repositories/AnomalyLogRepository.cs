using HybridFinanceSystem.Application.Interfaces;
using HybridFinanceSystem.Domain.Entities;
using HybridFinanceSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HybridFinanceSystem.Infrastructure.Repositories;

public class AnomalyLogRepository : IAnomalyLogRepository
{
    private readonly AppDbContext _context;

    public AnomalyLogRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AnomalyLog>> GetAllAsync() => 
        await _context.AnomalyLogs.Include(a => a.Transaction).ToListAsync();

    public async Task<AnomalyLog?> GetByIdAsync(int id) => 
        await _context.AnomalyLogs.Include(a => a.Transaction).FirstOrDefaultAsync(a => a.Anomaly_ID == id);

    public async Task<IEnumerable<AnomalyLog>> GetByTransactionIdAsync(long transactionId) =>
        await _context.AnomalyLogs.Where(a => a.Transaction_ID == transactionId).ToListAsync();

    public async Task<IEnumerable<AnomalyLog>> GetHighConfidenceAnomaliesAsync(decimal minScore) =>
        await _context.AnomalyLogs.Where(a => a.ConfidenceScore >= minScore).ToListAsync();

    public async Task AddAsync(AnomalyLog log)
    {
        await _context.AnomalyLogs.AddAsync(log);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(AnomalyLog log)
    {
        _context.AnomalyLogs.Update(log);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var log = await _context.AnomalyLogs.FindAsync(id);
        if (log != null)
        {
            _context.AnomalyLogs.Remove(log);
            await _context.SaveChangesAsync();
        }
    }
}