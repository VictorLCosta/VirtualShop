using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VirtualShop.Models;
using VirtualShop.Database;
using VirtualShop.Repositories.Contracts;

namespace VirtualShop.Repositories
{
    public class CollaboratorRepository : ICollaboratorRepository
    {
        private readonly VirtualShopContext _context;

        public CollaboratorRepository(VirtualShopContext context)
        {
            _context = context;
        }


        public async Task CreateAsync(Collaborator colaborator)
        {
            await _context.Colaborators.AddAsync(colaborator);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var obj = await _context.Colaborators.FindAsync(id);
            _context.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Collaborator>> FindAllAsync()
        {
            return await _context.Colaborators.ToListAsync();
        }

        public async Task<Collaborator> FindAsync(int id)
        {
            return await _context.Colaborators.FindAsync(id);
        }

        public async Task<Collaborator> Login(string Email, string Senha)
        {
            Collaborator collaborator = await _context.Colaborators.Where(c => c.Email == Email && c.Password == Senha).FirstOrDefaultAsync();
            return collaborator;
        }

        public async Task UpdateAsync(Collaborator colaborator)
        {
            _context.Colaborators.Update(colaborator);
            await _context.SaveChangesAsync();
        }
    }
}
