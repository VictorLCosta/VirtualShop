using Microsoft.EntityFrameworkCore;
using VirtualShop.Models;

namespace VirtualShop.Database
{
    public class VirtualShopContext : DbContext
    {
        public VirtualShopContext(DbContextOptions<VirtualShopContext> options) 
            : base (options)
        {
            
        }

        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            // PROPRIEDADES DE CLIENTE ------------------------
            mb.Entity<Client>()
                .HasKey(c => c.Id);

            mb.Entity<Client>()
                .Property(c => c.CPF)
                .IsRequired();
                
        }
    }
}