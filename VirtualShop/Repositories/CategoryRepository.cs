using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualShop.Models;
using VirtualShop.Database;
using VirtualShop.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace VirtualShop.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly VirtualShopContext _context;

        public CategoryRepository(VirtualShopContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            _context.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> FindAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> FindCategoryAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }
    }
}
