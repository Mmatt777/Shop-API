using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Shop.Domain.Entities;
using Shop.Infrastructure.Configuration;

namespace Shop.Infrastructure.Persistens
{
    public class ShopDbContext(DbContextOptions<ShopDbContext> options): IdentityDbContext<User>(options)
    {

        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new SubCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());

            modelBuilder.Entity<Brand>()
                .HasMany(b => b.Products)
                .WithOne(b => b.Brand)
                .HasForeignKey(b => b.BrandId)
                .OnDelete(DeleteBehavior.NoAction);                     
        }
    }
}
