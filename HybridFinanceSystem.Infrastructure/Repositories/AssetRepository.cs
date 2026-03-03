using HybridFinanceSystem.Application.Interfaces;
using HybridFinanceSystem.Domain.Entities;
using HybridFinanceSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HybridFinanceSystem.Infrastructure.Repositories;

public class AssetRepository : IAssetRepository
{
    private readonly AppDbContext _context;

    public AssetRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Asset>> GetAllAssetsAsync()
    {
        return await _context.Assets
            .Include(a => a.Currency) // Navigasyon özelliği
            .Include(a => a.User)
            .ToListAsync();
    }

    public async Task<Asset?> GetAssetByIdAsync(int id)
    {
        return await _context.Assets
            .Include(a => a.Currency)
            .FirstOrDefaultAsync(a => a.Asset_ID == id); // PK ismi SQL'de Asset_ID
    }

    public async Task<IEnumerable<Asset>> GetAssetsByUserIdAsync(int userId)
    {
        return await _context.Assets
            .Where(a => a.Users_ID == userId) // SQL'deki kolon adı
            .Include(a => a.Currency)
            .ToListAsync();
    }

    public async Task<IEnumerable<Asset>> GetAssetsByCurrencyAsync(string currencyCode)
    {
        // SQL'de CurrencyCode NVARCHAR(3) olduğu için string ile karşılaştırıyoruz
        return await _context.Assets
            .Where(a => a.CurrencyCode == currencyCode)
            .ToListAsync();
    }

    public async Task AddAssetAsync(Asset asset)
    {
        await _context.Assets.AddAsync(asset);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAssetAsync(Asset asset)
    {
        _context.Assets.Update(asset);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAssetAsync(int id)
    {
        var asset = await _context.Assets.FindAsync(id);
        if (asset != null)
        {
            _context.Assets.Remove(asset);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<decimal> GetTotalBalanceByUserIdAsync(int userId)
    {
        // Şemanda Quantity/UnitPrice yok, sadece Balance kolonunun toplamını alıyoruz
        return await _context.Assets
            .Where(a => a.Users_ID == userId)
            .SumAsync(a => a.Balance);
    }
}