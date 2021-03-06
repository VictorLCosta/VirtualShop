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
        public DbSet<NewsletterEmail> NewsletterEmails { get; set; }
        public DbSet<Collaborator> Colaborators { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            // PROPRIEDADES DE CLIENTE ------------------------
            mb.Entity<Client>()
                .HasKey(c => c.Id);

            mb.Entity<Client>()
                .Property(c => c.CPF)
                .IsRequired();

            mb.Entity<Client>()
                .Property(c => c.Email)
                .IsRequired();

            mb.Entity<Client>()
                .Property(c => c.Name)
                .IsRequired();

            mb.Entity<Client>()
                .Property(c => c.Gender)
                .HasMaxLength(1);

            mb.Entity<Client>()
                .Property(c => c.Telephone)
                .IsRequired();

            mb.Entity<Client>()
                .Property(c => c.BirthDate)
                .IsRequired();

            mb.Entity<Client>()
                .Property(c => c.Password)
                .IsRequired();

            mb.Entity<Client>()
                .HasIndex(c => c.Name);

            // PROPRIEDADES DA NEWSLETTER ---------------------
            mb.Entity<NewsletterEmail>()
                .ToTable("Newsletter");

            mb.Entity<NewsletterEmail>()
                .HasIndex(nw => nw.Email)
                .IsUnique();

            // PROPRIEDADES DO COLABORADOR --------------------
            mb.Entity<Collaborator>()
                .HasKey(c => c.Id);

            /*mb.Entity<Category>()
                .HasOne(c => c.CategoryFather)
                .WithOne(c => c.C);*/

            mb.Entity<Product>(entity => 
            {
                entity.HasOne(x => x.Category)
                    .WithMany(x => x.Products)
                    .HasForeignKey(x => x.CategoryId);

                entity.HasMany(x => x.Images)
                    .WithOne(x => x.Product)
                    .HasForeignKey(x => x.ProductId);
            });
        }
    }
}