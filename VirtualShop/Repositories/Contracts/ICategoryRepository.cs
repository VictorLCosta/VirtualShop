using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualShop.Models;
using X.PagedList;

namespace VirtualShop.Repositories.Contracts
{
    public interface ICategoryRepository
    {
        //CRUD
        Task CreateAsync(Category category);
        Task<Category> FindCategoryAsync(int id);
        Task UpdateAsync(Category category);
        Task DeleteAsync(int id);
        Task<IPagedList<Category>> FindAllCategoriesAsync(int? id);
    }
}
