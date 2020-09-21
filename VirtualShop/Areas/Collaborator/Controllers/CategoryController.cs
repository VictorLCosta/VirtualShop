using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VirtualShop.Models;
using VirtualShop.Repositories;
using Microsoft.EntityFrameworkCore;
using VirtualShop.Libraries.Filter;
using X.PagedList;

namespace VirtualShop.Areas.Collaborator.Controllers
{
    [Area("Collaborator")]
    
    public class CategoryController : Controller
    {
        private CategoryRepository _repository;

        public CategoryController(CategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index(int? page)
        {
            var categories = await _repository.FindAllCategoriesAsync(page);

            return View(categories);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register([FromForm]Category category)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update([FromForm]Category category)
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
