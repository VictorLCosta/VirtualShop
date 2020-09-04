using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualShop.Models;

namespace VirtualShop.Repositories
{
    interface IClientRepository
    {
        Task<Client> Login(string email, string password);

        //CRUD
        Task IncludeAsync(Client client);
        Task UpdateAsync(Client client);
        Task DeleteAsync(int id);
        Task<Client> FindClientAsync(int id);
        Task<List<Client>> FindAllClientsAsync();
    }
}
