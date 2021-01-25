using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using VirtualShop.Database;
using VirtualShop.Models;
using VirtualShop.Repositories.Contracts;
using X.PagedList;

namespace VirtualShop.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly VirtualShopContext Context;
        private readonly IConfiguration Config;

        public ProductRepository(VirtualShopContext context, IConfiguration config)
        {
            Context = context;
            Config = config;
        }

        public async Task CreateAsync(Product product)
        {
            await Context.Products.AddAsync(product);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var obj = await Context.Products.FindAsync(id);

            Context.Products.Remove(obj);
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> FindAllAsync()
        {
            return await Context.Products.ToListAsync();
        }

        public async Task<Product> FindAsync(int id)
        {
            return await Context.Products.FindAsync(id);
        }

        public async Task<IPagedList<Product>> PageAllAsync(int? page, string search)
        {
            int numPage = page ?? 1;
            int registerPerPage = Config.GetValue<int>("registerPerPage");

            var dbProducts = Context.Products.AsQueryable();
            if(!string.IsNullOrEmpty(search))
            {
                dbProducts = dbProducts.Where(a => a.Name.Contains(search));
            }

            return await dbProducts.ToPagedListAsync<Product>(numPage, registerPerPage);
        }

        public async Task UpdateAsync(Product product)
        {
            Context.Products.Update(product);
            await Context.SaveChangesAsync();
        }
    }
}