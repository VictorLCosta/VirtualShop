using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VirtualShop.Libraries.Filter;
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
        
        public async Task<IActionResult> Create([FromForm]Product product)
        {
            if(ModelState.IsValid)
            {
                await Repo.CreateAsync(product);

                TempData["MSG_S"] = "Produto cadastrado com sucesso";

                return RedirectToAction(nameof(Index));
            }

            var dbCategories = await CatRepo.FindAllCategoriesAsync();

            ViewBag.Categories = dbCategories.Select(a => new SelectListItem(a.Name, a.Id.ToString()));
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var dbCategories = await Repo.FindAllAsync();

            ViewBag.Categories = dbCategories.Select(a => new SelectListItem(a.Name, a.Id.ToString()));

            Product product = await Repo.FindAsync(id);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromForm]Product product)
        {
            if(ModelState.IsValid)
            {
                await Repo.UpdateAsync(product);

                TempData["MSG_S"] = "Produto atualizado com sucesso";

                return RedirectToAction(nameof(Index));
            }

            var dbCategories = await Repo.FindAllAsync();

            ViewBag.Categories = dbCategories.Select(a => new SelectListItem(a.Name, a.Id.ToString()));
            return View(product);
        }
    }
}