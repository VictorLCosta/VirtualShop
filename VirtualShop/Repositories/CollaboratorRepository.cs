using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VirtualShop.Models;
using VirtualShop.Database;
using VirtualShop.Repositories.Contracts;
using X.PagedList;
using Microsoft.Extensions.Configuration;

namespace VirtualShop.Repositories
{
    public class CollaboratorRepository : ICollaboratorRepository
    {
        private readonly VirtualShopContext _context;
        private IConfiguration _conf;

        public CollaboratorRepository(VirtualShopContext context, IConfiguration configuration)
        {
            _context = context;
            _conf = configuration;
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

        public async Task<IPagedList<Collaborator>> FindAllCollaboratorsAsync(int? page)
        {
            int numPage = page ?? 1;
            return await _context.Colaborators.ToPagedListAsync<Collaborator>(numPage, _conf.GetValue<int>("registerPerPage"));
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
            _context.Entry(colaborator).Property(a => a.Password).IsModified = false;

            await _context.SaveChangesAsync();
        }

        public async Task UpdatePasswordAsync(Collaborator collaborator)
        {
            _context.Update(collaborator);
            _context.Entry(collaborator).Property(c => c.Name).IsModified = false;
            _context.Entry(collaborator).Property(c => c.Email).IsModified = false;
            _context.Entry(collaborator).Property(c => c.Type).IsModified = false;

            await _context.SaveChangesAsync();
        }
    }
}
