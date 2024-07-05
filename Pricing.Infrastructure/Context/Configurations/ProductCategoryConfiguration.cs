using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pricing.Domain.Entities;

namespace Pricing.Infrastructure.Context.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(pc => pc.ChildCategories)
                .WithOne(pc => pc.ParentCategory)
                .HasForeignKey(pc => pc.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(pc => pc.Products)
                .WithOne(pc => pc.Category)
                .HasForeignKey(pc => pc.CategorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
