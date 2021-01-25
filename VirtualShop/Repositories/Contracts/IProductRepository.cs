using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualShop.Models;
using X.PagedList;

namespace VirtualShop.Repositories.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> FindAllAsync();
        Task<Product> FindAsync(int id);
        Task CreateAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);

        //Pagination
        Task<IPagedList<Product>> PageAllAsync(int? page, string search);
    }
}