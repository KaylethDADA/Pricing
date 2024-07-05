using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pricing.Domain.Entities;

namespace Pricing.Infrastructure.Context.Configurations
{
    public class CityOfUserConfiguration : IEntityTypeConfiguration<CityOfUser>
    {
        public void Configure(EntityTypeBuilder<CityOfUser> builder)
        {
            builder.HasKey(x => new {x.UserId, x.CityId});

            builder.HasOne(pc => pc.User)
                .WithMany(pc => pc.Citys)
                .HasForeignKey(pc => pc.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pc => pc.City)
                .WithMany(pc => pc.Users)
                .HasForeignKey(pc => pc.CityId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
