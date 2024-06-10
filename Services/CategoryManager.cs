using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _manager;

        public CategoryManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public async Task CreateOneCategoryAsync(Category category)
        {
            if (category is null)
                throw new ArgumentNullException(nameof(category));

            _manager.Category.CreateOneCategoryAsync(category);
            await _manager.SaveAsync();
        }

        public async Task DeleteOneCategoryAsync(Category category)
        {
            _manager.Category.DeleteOneCategoryAsync(category);
            await _manager.SaveAsync();
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackchanges)
        {
            return await _manager.Category.GetAllCategoriesAsync(trackchanges);
        }

        public async Task<Category> GetOneCategoryByIdAsync(int id, bool trackChanges)
        {
            var category = await _manager.Category.GetOneCategoryByIdAsync(id, trackChanges);
            if (category is null)
                throw new CategoryNotFoundException(id);
            return category;
        }

        public async Task UpdateOneCategoryAsync(Category category)
        {
            _manager.Category.UpdateOneCategoryAsync(category);
            await _manager.SaveAsync();
        }
    }
}
