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
    public class NewsletterRepository : INewsletterRepository
    {
        private readonly VirtualShopContext _context;

        public NewsletterRepository(VirtualShopContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<NewsletterEmail>> FindAllNewsletterAsync()
        {
            return await _context.NewsletterEmails.ToListAsync();
        }

        public async Task InsertAsync(NewsletterEmail newsletter)
        {
            await _context.NewsletterEmails.AddAsync(newsletter);
            await _context.SaveChangesAsync();
        }
    }
}
