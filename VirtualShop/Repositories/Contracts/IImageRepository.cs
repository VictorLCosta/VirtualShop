using System.Threading.Tasks;
using VirtualShop.Models;

namespace VirtualShop.Repositories.Contracts
{
    public interface IImageRepository
    {
        Task CreateAsync(Image image);
        Task DeleteAsync(int id);
        Task RemoveProductImages(int productId);
    }
}