using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualShop.Models;

namespace VirtualShop.Repositories.Contracts
{
    public interface INewsletterRepository
    {
        Task InsertAsync(NewsletterEmail newsletter);
        Task<IEnumerable<NewsletterEmail>> FindAllNewsletterAsync(); 
    }
}
