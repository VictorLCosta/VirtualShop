using System.Collections.Generic;
using System.Threading.Tasks;
using VirtualShop.Models;
using X.PagedList;

namespace VirtualShop.Repositories.Contracts
{
    public interface ICollaboratorRepository
    {
        Task<Collaborator> Login(string Email, string Senha);

        // CRUD
        Task CreateAsync(Collaborator colaborator);
        Task<Collaborator> FindAsync(int id);
        Task<Collaborator> FindAsync(string email);
        Task UpdateAsync(Collaborator colaborator);
        Task DeleteAsync(int id);

        // Outras operações
        Task UpdatePasswordAsync(Collaborator collaborator);
        Task<List<Collaborator>> FindAllCollaboratorPerEmail(string email);
        Task<IPagedList<Collaborator>> FindAllCollaboratorsAsync(int? page);
    }
}
