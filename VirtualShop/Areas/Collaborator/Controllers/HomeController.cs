using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VirtualShop.Repositories.Contracts;
using VirtualShop.Libraries.Login;

namespace VirtualShop.Areas.Collaborator.Controllers
{
    [Area("Collaborator")]
    public class HomeController : Controller
    {
        private readonly ICollaboratorRepository _collaboaratorRepository;
        private CollaboratorLogin _collaboratorLogin;

        public HomeController(ICollaboratorRepository repository, CollaboratorLogin collaboratorLogin)
        {
            _collaboaratorRepository = repository;
            _collaboratorLogin = collaboratorLogin;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm]Models.Collaborator collaborator) 
        {
            Models.Collaborator collaboratorDb = await _collaboaratorRepository.Login(collaborator.Email, collaborator.Password);

            if (collaboratorDb != null)
            {
                _collaboratorLogin.Login(collaboratorDb);

                return RedirectToAction(nameof(Painel));
            }
            else
            {
                ViewData["MSG_E"] = "Usuário não encontrado!";
                return View();
            }
        }

        [HttpGet]
        public IActionResult RecoverPassword() 
        {
            return View();
        }

        [HttpGet]
        public IActionResult RegisterNewPassword()
        {
            return View();
        }

        public IActionResult Painel()
        {
            return View();
        }
    }
}
