using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualShop.Models;

namespace VirtualShop.Repositories.Contracts
{
    public interface ICollaboratorRepository
    {
        Task<Collaborator> Login(string Email, string Senha);

        // CRUD
        Task CreateAsync(Collaborator colaborator);
        Task<Collaborator> FindAsync(int id);
        Task UpdateAsync(Collaborator colaborator);
        Task DeleteAsync(int id);

        // Outras operações
        Task<IEnumerable<Collaborator>> FindAllAsync();
    }
}
