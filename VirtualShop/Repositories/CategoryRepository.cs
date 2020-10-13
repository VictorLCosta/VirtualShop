using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualShop.Models;
using VirtualShop.Database;
using VirtualShop.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using Microsoft.Extensions.Configuration;

namespace VirtualShop.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private IConfiguration _conf;
        private readonly VirtualShopContext _context;

        public CategoryRepository(VirtualShopContext context, IConfiguration configuration)
        {
            _context = context;
            _conf = configuration;
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

        public async Task<IPagedList<Category>> FindAllCategoriesAsync(int? id)
        {
            int numPage = id ?? 1;
            return await _context.Categories.Include(c => c.CategoryFather).ToPagedListAsync<Category>(numPage, _conf.GetValue<int>("registerPerPage"));
        }

        public IEnumerable<Category> FindAllCategoriesAsync()
        {
            return _context.Categories.ToList();
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
