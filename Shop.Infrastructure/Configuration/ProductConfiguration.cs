using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities;
using System.Reflection.Emit;


namespace Shop.Infrastructure.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(p => p.Category)
                   .WithMany(p => p.Products)
                   .HasForeignKey(p => p.CategoryId);

            builder.HasOne(c => c.SubCategory)
                   .WithMany(c => c.Products)
                   .HasForeignKey(c => c.SubCategoryId);

            builder.HasOne(c => c.Brand)
                   .WithMany(c => c.Products)
                   .HasForeignKey(c => c.BrandId)
                   .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
