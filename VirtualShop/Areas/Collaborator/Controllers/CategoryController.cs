using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VirtualShop.Models;
using VirtualShop.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using VirtualShop.Libraries.Filter;
using X.PagedList;

namespace VirtualShop.Areas.Collaborator.Controllers
{
    [Area("Collaborator")]
    public class CategoryController : Controller
    {
        private ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? page)
        {
            IPagedList<Category> categories = await _repository.FindAllCategoriesAsync(page);

            return View(categories);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm]Category category)
        {
            if (ModelState.IsValid)
            {
                await _repository.CreateAsync(category);

                TempData["MSG_S"] = "Registro salvo com sucesso";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromForm]Category category)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}
