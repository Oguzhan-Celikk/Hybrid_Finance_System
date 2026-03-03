using HybridFinanceSystem.Application.Interfaces;
using HybridFinanceSystem.Domain.Entities;
using HybridFinanceSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HybridFinanceSystem.Infrastructure.Repositories;

public class CurrencyRepository : ICurrencyRepository
{
    private readonly AppDbContext _context;

    public CurrencyRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Currency>> GetAllAsync() => await _context.Currencies.ToListAsync();

    public async Task<Currency?> GetByCodeAsync(string code) => 
        await _context.Currencies.FirstOrDefaultAsync(c => c.Code == code);

    public async Task AddAsync(Currency currency)
    {
        await _context.Currencies.AddAsync(currency);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Currency currency)
    {
        _context.Currencies.Update(currency);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(string code)
    {
        var currency = await GetByCodeAsync(code);
        if (currency != null)
        {
            _context.Currencies.Remove(currency);
            await _context.SaveChangesAsync();
        }
    }
}