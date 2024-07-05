using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pricing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pricing.Infrastructure.Context.Configurations
{
    public class ShopOfProductConfiguration : IEntityTypeConfiguration<ShopOfProduct>
    {
        public void Configure(EntityTypeBuilder<ShopOfProduct> builder)
        {
            builder.HasKey(x => new { x.ShopId, x.ProductId });

            builder.HasOne(pc => pc.Product)
                .WithMany(pc => pc.Shops)
                .HasForeignKey(pc => pc.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pc => pc.Shop)
                .WithMany(pc => pc.Products)
                .HasForeignKey(pc => pc.ShopId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
