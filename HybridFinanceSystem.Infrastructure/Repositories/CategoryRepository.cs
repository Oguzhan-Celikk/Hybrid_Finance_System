using HybridFinanceSystem.Application.Interfaces;
using HybridFinanceSystem.Domain.Entities;
using HybridFinanceSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HybridFinanceSystem.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        return await _context.Categories
            .Include(c => c.SubCategories)
            .Include(c => c.ParentCategory)
            .ToListAsync();
    }

    public async Task<Category?> GetCategoryByIdAsync(int id)
    {
        return await _context.Categories
            .Include(c => c.SubCategories)
            .Include(c => c.ParentCategory)
            .FirstOrDefaultAsync(c => c.Category_ID == id);
    }

    public async Task<IEnumerable<Category>> GetCategoriesByParentIdAsync(int? parentId)
    {
        return await _context.Categories
            .Where(c => c.ParentCategory_ID == parentId)
            .Include(c => c.SubCategories)
            .ToListAsync();
    }

    public async Task AddCategoryAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCategoryAsync(Category category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCategoryAsync(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category != null)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Category>> GetCategoriesByTypeAsync(bool isIncome)
    {
        return await _context.Categories
            .Where(c => c.IsIncome == isIncome)
            .Include(c => c.SubCategories)
            .ToListAsync();
    }
}