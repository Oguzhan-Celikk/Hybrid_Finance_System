using HybridFinanceSystem.Domain.Entities;

namespace HybridFinanceSystem.Application.Interfaces;

public interface IMerchantRepository
{
    Task<IEnumerable<Merchant>> GetAllWithCategoriesAsync();
    Task<Merchant?> GetByIdAsync(int id);
    Task<IEnumerable<Merchant>> GetByCategoryIdAsync(int categoryId);
    Task AddAsync(Merchant merchant);
    Task UpdateAsync(Merchant merchant);
    Task DeleteAsync(int id);
}