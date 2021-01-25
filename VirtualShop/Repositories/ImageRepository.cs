using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VirtualShop.Database;
using VirtualShop.Models;
using VirtualShop.Repositories.Contracts;

namespace VirtualShop.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly VirtualShopContext Context;
        public ImageRepository(VirtualShopContext context)
        {
            Context = context;
        }

        public async Task CreateAsync(Image image)
        {
            await Context.Images.AddAsync(image);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var dbImage = await Context.Images.FindAsync(id);

            Context.Images.Remove(dbImage);
            await Context.SaveChangesAsync();
        }

        public async Task RemoveProductImages(int productId)
        {
            var images = await Context.Images.Where(i => i.ProductId == productId).ToListAsync();

            foreach(var image in images)
            {
                Context.Remove(image);
            }

            await Context.SaveChangesAsync();
        }
    }
}