using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VirtualShop.Repositories.Contracts;

namespace VirtualShop.Areas.Collaborator.Controllers
{
    [Area("Collaborator")]
    public class ProductController : Controller
    {
        private readonly IProductRepository Repo;

        public ProductController(IProductRepository repository)
        {
            Repo = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? page, string search)
        {
            var paged = await Repo.PageAllAsync(page, search);

            return View(paged);
        }

    }
}