using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Shop.Domain.Entities;

namespace Shop.Infrastructure.Persistens
{
    public class ShopDbContext(DbContextOptions<ShopDbContext> options) : DbContext(options)
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.SubCategories)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<SubCategory>()
                .HasOne(c => c.Category)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<Product>()
                .HasOne(c => c.SubCategory)
                .WithMany(c => c.Products)
                .HasForeignKey(c => c.SubCategoryId);
        }
    }
}
