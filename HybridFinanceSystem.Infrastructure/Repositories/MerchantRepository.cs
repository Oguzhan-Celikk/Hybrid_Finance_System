using HybridFinanceSystem.Application.Interfaces;
using HybridFinanceSystem.Domain.Entities;
using HybridFinanceSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HybridFinanceSystem.Infrastructure.Repositories;

public class MerchantRepository : IMerchantRepository
{
    private readonly AppDbContext _context;

    public MerchantRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Merchant>> GetAllWithCategoriesAsync()
    {
        return await _context.Merchants
            .Include(m => m.Category) // Navigasyon özelliği
            .ToListAsync();
    }

    public async Task<Merchant?> GetByIdAsync(int id)
    {
        return await _context.Merchants
            .Include(m => m.Category)
            .FirstOrDefaultAsync(m => m.Merchant_ID == id);
    }

    public async Task<IEnumerable<Merchant>> GetByCategoryIdAsync(int categoryId)
    {
        return await _context.Merchants
            .Where(m => m.MainCategory_ID == categoryId)
            .ToListAsync();
    }

    public async Task AddAsync(Merchant merchant)
    {
        await _context.Merchants.AddAsync(merchant);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Merchant merchant)
    {
        _context.Merchants.Update(merchant);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var merchant = await _context.Merchants.FindAsync(id);
        if (merchant != null)
        {
            _context.Merchants.Remove(merchant);
            await _context.SaveChangesAsync();
        }
    }
}