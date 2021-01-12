using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VirtualShop.Models;
using VirtualShop.Repositories.Contracts;
using X.PagedList;

namespace VirtualShop.Areas.Collaborator.Controllers
{
    [Area("Collaborator")]
    public class ClientController : Controller
    {
        private readonly IClientRepository _repository;

        public ClientController(IClientRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? page)
        {
            IPagedList<Client> clients = await _repository.FindAllClientsAsync(page);

            return View(clients);
        }

        public IActionResult ActivateDesactivate()
        {
            return View();
        }
    }
}