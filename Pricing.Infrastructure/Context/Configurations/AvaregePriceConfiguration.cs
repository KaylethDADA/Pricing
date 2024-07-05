using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pricing.Domain.Entities;

namespace Pricing.Infrastructure.Context.Configurations
{
    public class AvaregePriceConfiguration : IEntityTypeConfiguration<AveragePrice>
    {
        public void Configure(EntityTypeBuilder<AveragePrice> builder)
        {
            builder.HasKey(x => new { x.DataCreate, x.CityId });

            builder.HasOne(x => x.City)
                .WithMany(x => x.AveragePrices)
                .HasForeignKey(x => x.CityId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
