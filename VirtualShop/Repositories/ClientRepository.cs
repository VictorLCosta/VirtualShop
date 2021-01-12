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
    public class ClientRepository : IClientRepository
    {
        private readonly VirtualShopContext _context;
        private IConfiguration Config;

        public ClientRepository(VirtualShopContext context, IConfiguration config)
        {
            _context = context;
            Config = config;
        }

        //CRUD
        public async Task DeleteAsync(int id)
        {
            var obj = await _context.Clients.FindAsync(id);
            _context.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Client>> FindAllClientsAsync()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<IPagedList<Client>> FindAllClientsAsync(int? page)
        {
            int numPage = page ?? 1;

            return await _context.Clients.ToPagedListAsync<Client>(numPage, Config.GetValue<int>("registerPerPage"));
        }

        public async Task<Client> FindClientAsync(int id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task IncludeAsync(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
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
