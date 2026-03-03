using HybridFinanceSystem.Domain.Entities;

namespace HybridFinanceSystem.Application.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
    Task<Category?> GetCategoryByIdAsync(int id);
    Task<IEnumerable<Category>> GetCategoriesByParentIdAsync(int? parentId);
    Task AddCategoryAsync(Category category);
    Task UpdateCategoryAsync(Category category);
    Task DeleteCategoryAsync(int id);
    Task<IEnumerable<Category>> GetCategoriesByTypeAsync(bool isIncome);
}