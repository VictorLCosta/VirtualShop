using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualShop.Models;

namespace VirtualShop.Repositories.Contracts
{
    public interface ICategoryRepository
    {
        //CRUD
        Task CreateAsync(Category category);
        Task<Category> FindCategoryAsync(int id);
        Task UpdateAsync(Category category);
        Task DeleteAsync(int id);
        Task<IEnumerable<Category>> FindAllCategoriesAsync();
    }
}
