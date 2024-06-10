using Entities.Models;

namespace Services.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackchanges);
        Task<Category> GetOneCategoryByIdAsync(int id, bool trackChanges);
        Task CreateOneCategoryAsync(Category category);
        Task UpdateOneCategoryAsync(Category category);
        Task DeleteOneCategoryAsync(Category category);
    }
}
