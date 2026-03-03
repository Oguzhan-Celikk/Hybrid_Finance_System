using HybridFinanceSystem.Domain.Entities;

namespace HybridFinanceSystem.Application.Interfaces;

public interface ICurrencyRepository
{
    Task<IEnumerable<Currency>> GetAllAsync();
    Task<Currency?> GetByCodeAsync(string code); // PK string (TRY, USD vb.)
    Task AddAsync(Currency currency);
    Task UpdateAsync(Currency currency);
    Task DeleteAsync(string code);
}