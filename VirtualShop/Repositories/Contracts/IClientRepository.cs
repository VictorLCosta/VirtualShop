using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualShop.Models;
using X.PagedList;

namespace VirtualShop.Repositories.Contracts
{
    public interface IClientRepository
    {
        Task<Client> Login(string email, string password);

        //CRUD
        Task IncludeAsync(Client client);
        Task UpdateAsync(Client client);
        Task DeleteAsync(int id);
        Task<Client> FindClientAsync(int id);
        Task<IEnumerable<Client>> FindAllClientsAsync();

        Task<IPagedList<Client>> FindAllClientsAsync(int? page);
        Task<IPagedList<Client>> FindAllClientsAsync(int? page, string search);
    }
}
