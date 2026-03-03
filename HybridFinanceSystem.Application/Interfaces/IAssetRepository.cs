using HybridFinanceSystem.Domain.Entities;

namespace HybridFinanceSystem.Application.Interfaces;

public interface IAssetRepository
{
    Task<IEnumerable<Asset>> GetAllAssetsAsync();
    Task<Asset?> GetAssetByIdAsync(int id);
    Task<IEnumerable<Asset>> GetAssetsByUserIdAsync(int userId);
    Task<IEnumerable<Asset>> GetAssetsByCurrencyAsync(string currencyCode); // string olmalı (Örn: 'TRY')
    Task AddAssetAsync(Asset asset);
    Task UpdateAssetAsync(Asset asset);
    Task DeleteAssetAsync(int id);
    Task<decimal> GetTotalBalanceByUserIdAsync(int userId); // Şemada sadece Balance var
}