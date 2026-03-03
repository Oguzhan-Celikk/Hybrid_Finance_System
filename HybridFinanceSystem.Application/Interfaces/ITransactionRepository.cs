using HybridFinanceSystem.Domain.Entities;

namespace HybridFinanceSystem.Application.Interfaces;

public interface ITransactionRepository
{
    Task<IEnumerable<Transaction>> GetAllTransactionsAsync();
    Task<Transaction?> GetTransactionByIdAsync(long id);
    Task<IEnumerable<Transaction>> GetTransactionsByUserIdAsync(int userId);
    Task<IEnumerable<Transaction>> GetTransactionsByDateRangeAsync(DateTime startDate, DateTime endDate);
    Task<IEnumerable<Transaction>> GetTransactionsByCategoryIdAsync(int categoryId);
    Task AddTransactionAsync(Transaction transaction);
    Task UpdateTransactionAsync(Transaction transaction);
    Task DeleteTransactionAsync(long id);
    Task<decimal> GetTotalTransactionsByUserAsync(int userId);
}