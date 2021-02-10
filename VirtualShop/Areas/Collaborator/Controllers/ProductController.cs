using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VirtualShop.Models;
using VirtualShop.Repositories.Contracts;

namespace VirtualShop.Areas.Collaborator.Controllers
{
    [Area("Collaborator")]
    public class ProductController : Controller
    {
        private readonly IProductRepository Repo;
        private readonly ICategoryRepository CatRepo;

        public ProductController(IProductRepository repository, ICategoryRepository catRepo)
        {
            Repo = repository;
            CatRepo = catRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? page, string search)
        {
            var paged = await Repo.PageAllAsync(page, search);

            return View(paged);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var dbCategories = await CatRepo.FindAllCategoriesAsync();

            ViewBag.Categories = dbCategories.Select(a => new SelectListItem(a.Name, a.Id.ToString()));
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Product product)
        {
            await Task.Yield();
            return Ok();
        }
    }
}