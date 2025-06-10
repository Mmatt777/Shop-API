using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities;


namespace Shop.Infrastructure.Configuration
{
    public class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.HasMany(c => c.Products)
                .WithOne(c => c.SubCategory)
                .HasForeignKey(c => c.SubCategoryId);

            builder.HasMany(c => c.Brands)
                .WithOne(c => c.SubCategory)
                .HasForeignKey(c => c.SubCategoryId);

        }
    }
}
