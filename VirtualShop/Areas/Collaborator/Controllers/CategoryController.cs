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
using Microsoft.AspNetCore.Mvc.Rendering;

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
            ViewBag.Categories =  _repository.FindAllCategoriesAsync().Select(a=> new SelectListItem(a.Name, a.Id.ToString()));
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
        public async Task<IActionResult> Update(int id)
        {
            Category category = await _repository.FindCategoryAsync(id);

            ViewBag.Categories = _repository.FindAllCategoriesAsync().Where(a => a.Id != id).Select(a => new SelectListItem(a.Name, a.Id.ToString()));
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromForm]Category category, int id)
        {
            if (ModelState.IsValid)
            {
                await _repository.UpdateAsync(category);

                TempData["MSG_S"] = "Registro atualizado com sucesso!";

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = _repository.FindAllCategoriesAsync().Where(a => a.Id != id).Select(a => new SelectListItem(a.Name, a.Id.ToString()));
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);

            TempData["MSG_S"] = "Registro excluido com sucesso";
            return RedirectToAction(nameof(Index));
        }
    }
}
