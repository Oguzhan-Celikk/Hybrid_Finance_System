using HybridFinanceSystem.Application.Interfaces;
using HybridFinanceSystem.Domain.Entities;
using HybridFinanceSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HybridFinanceSystem.Infrastructure.Repositories;

public class AssetPriceHistoryRepository : IAssetPriceHistoryRepository
{
    private readonly AppDbContext _context;

    public AssetPriceHistoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AssetPriceHistory>> GetHistoryByCurrencyAsync(string currencyCode)
    {
        return await _context.AssetPriceHistories
            .Where(p => p.CurrencyCode == currencyCode)
            .OrderByDescending(p => p.PriceDate)
            .ToListAsync();
    }

    public async Task<AssetPriceHistory?> GetLatestPriceAsync(string currencyCode)
    {
        return await _context.AssetPriceHistories
            .Where(p => p.CurrencyCode == currencyCode)
            .OrderByDescending(p => p.PriceDate)
            .FirstOrDefaultAsync();
    }

    public async Task AddPriceAsync(AssetPriceHistory priceHistory)
    {
        await _context.AssetPriceHistories.AddAsync(priceHistory);
        await _context.SaveChangesAsync();
    }
}