using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VirtualShop.Models;
using VirtualShop.Database;

namespace VirtualShop.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly VirtualShopContext _context;

        public ClientRepository(VirtualShopContext context)
        {
            _context = context;
        }

        //CRUD
        public async Task DeleteAsync(int id)
        {
            var obj = await _context.Clients.FindAsync(id);
            _context.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Client>> FindAllClientsAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> FindClientAsync(int id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public Task IncludeAsync(Client client)
        {
            throw new NotImplementedException();
        }

        public async Task<Client> Login(string email, string password)
        {
            Client client = await _context.Clients.Where(c => c.Email == email && c.Password == password).FirstAsync();
            return client;
        }

        public async Task UpdateAsync(Client client)
        {
            _context.Update(client);
            await _context.SaveChangesAsync();
        }
    }
}
