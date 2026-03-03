using HybridFinanceSystem.Domain.Entities;

namespace HybridFinanceSystem.Application.Interfaces;

public interface IAssetPriceHistoryRepository
{
    Task<IEnumerable<AssetPriceHistory>> GetHistoryByCurrencyAsync(string currencyCode);
    Task<AssetPriceHistory?> GetLatestPriceAsync(string currencyCode);
    Task AddPriceAsync(AssetPriceHistory priceHistory);
}