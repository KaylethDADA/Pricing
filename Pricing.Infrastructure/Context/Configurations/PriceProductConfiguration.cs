using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pricing.Domain.Entities;

namespace Pricing.Infrastructure.Context.Configurations
{
    public class PriceProductConfiguration : IEntityTypeConfiguration<PriceProduct>
    {
        public void Configure(EntityTypeBuilder<PriceProduct> builder)
        {
            builder.HasKey(x => new { x.ProductId, x.DateCreated }); 

            builder.Property(x => x.Price)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();
        }
    }
}
