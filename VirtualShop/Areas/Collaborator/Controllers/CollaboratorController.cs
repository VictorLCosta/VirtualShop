using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VirtualShop.Repositories.Contracts;

namespace VirtualShop.Areas.Collaborator.Controllers
{
    public class CollaboratorController : Controller
    {
        private readonly ICollaboratorRepository _repository;

        public CollaboratorController(ICollaboratorRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index(int? page)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register([FromForm]Models.Collaborator collaborator)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update([FromForm] Models.Collaborator collaborator, int id)
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
