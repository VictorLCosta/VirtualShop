using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VirtualShop.Libraries.Email;
using VirtualShop.Libraries.Text;
using VirtualShop.Repositories.Contracts;
using X.PagedList;

namespace VirtualShop.Areas.Collaborator.Controllers
{
    [Area("Collaborator")]
    public class CollaboratorController : Controller
    {
        private readonly ICollaboratorRepository _repository;
        private MailSender Sender;

        public CollaboratorController(ICollaboratorRepository repository, MailSender sender)
        {
            _repository = repository;
            Sender = sender;
        }

        public async Task<IActionResult> Index(int? page)
        {
            IPagedList<VirtualShop.Models.Collaborator> collaborators = await _repository.FindAllCollaboratorsAsync(page);

            return View(collaborators);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm]Models.Collaborator collaborator)
        {
            if(ModelState.IsValid)
            {
                collaborator.Type = 'C';
                await _repository.CreateAsync(collaborator);

                TempData["MSG_S"] = "Cadastro realizado com sucesso!";

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GeneratePassword(int id)
        {
            var collaborator = await _repository.FindAsync(id);
            collaborator.Password = KeyGenerator.GetUniqueKey(8);

            await _repository.UpdateAsync(collaborator);

            Sender.SendPasswordToCollaborator(collaborator);
            TempData["MSG_S"] = "Senha enviada com sucesso!";

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var collaborator = await _repository.FindAsync(id);
            return View(collaborator);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Models.Collaborator collaborator)
        {
            if(ModelState.IsValid)
            {
                await _repository.UpdateAsync(collaborator);

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);

            TempData["MSG_S"] = "Registro excluído com sucesso!";

            return RedirectToAction(nameof(Index));
        }

    }
}
