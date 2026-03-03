using HybridFinanceSystem.Application.Interfaces;
using HybridFinanceSystem.Domain.Entities;
using HybridFinanceSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HybridFinanceSystem.Infrastructure.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly AppDbContext _context;

    public TransactionRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync()
    {
        return await _context.Transactions
            .Include(t => t.User)
            .Include(t => t.Category)
            .Include(t => t.Merchant)
            .ToListAsync();
    }

    public async Task<Transaction?> GetTransactionByIdAsync(long id)
    {
        return await _context.Transactions
            .Include(t => t.User)
            .Include(t => t.Category)
            .Include(t => t.Merchant)
            .FirstOrDefaultAsync(t => t.Transaction_ID == id);
    }

    public async Task<IEnumerable<Transaction>> GetTransactionsByUserIdAsync(int userId)
    {
        return await _context.Transactions
            .Where(t => t.Users_ID == userId)
            .Include(t => t.Category)
            .Include(t => t.Merchant)
            .OrderByDescending(t => t.TransactionDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<Transaction>> GetTransactionsByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        return await _context.Transactions
            .Where(t => t.TransactionDate >= startDate && t.TransactionDate <= endDate)
            .Include(t => t.User)
            .Include(t => t.Category)
            .OrderByDescending(t => t.TransactionDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<Transaction>> GetTransactionsByCategoryIdAsync(int categoryId)
    {
        return await _context.Transactions
            .Where(t => t.Category_ID == categoryId)
            .Include(t => t.User)
            .Include(t => t.Merchant)
            .ToListAsync();
    }

    public async Task AddTransactionAsync(Transaction transaction)
    {
        await _context.Transactions.AddAsync(transaction);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTransactionAsync(Transaction transaction)
    {
        _context.Transactions.Update(transaction);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTransactionAsync(long id)
    {
        var transaction = await _context.Transactions.FindAsync(id);
        if (transaction != null)
        {
            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<decimal> GetTotalTransactionsByUserAsync(int userId)
    {
        return await _context.Transactions
            .Where(t => t.Users_ID == userId)
            .SumAsync(t => t.Amount);
    }
}
