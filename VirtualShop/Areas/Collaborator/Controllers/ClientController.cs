using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VirtualShop.Libraries.Constants;
using VirtualShop.Libraries.Filter;
using VirtualShop.Models;
using VirtualShop.Repositories.Contracts;
using X.PagedList;

namespace VirtualShop.Areas.Collaborator.Controllers
{
    [Area("Collaborator")]
    [CollaboratorAuthorization]
    public class ClientController : Controller
    {
        private readonly IClientRepository _repository;

        public ClientController(IClientRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? page, string search)
        {
            IPagedList<Client> clients = await _repository.FindAllClientsAsync(page, search);

            return View(clients);
        }

        [ValidateHttpReferer]
        public async Task<IActionResult> ActivateDesactivate(int id)
        {
            var client = await _repository.FindClientAsync(id);

            client.Situation = (client.Situation == SituationConstant.Active) ? client.Situation = SituationConstant.Inactive : client.Situation = SituationConstant.Active ;

            await _repository.UpdateAsync(client);

            return View();
        }
    }
}