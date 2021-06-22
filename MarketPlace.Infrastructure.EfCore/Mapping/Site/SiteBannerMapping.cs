using MarketPlace.Domain.Entities.Site;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketPlace.Infrastructure.EfCore.Mapping.Site
{
    public class SiteBannerMapping : IEntityTypeConfiguration<SiteBanner>
    {
        public void Configure(EntityTypeBuilder<SiteBanner> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.ImageName).IsRequired();
            builder.Property(p => p.ColSize).HasMaxLength(250).IsRequired();
        }
    }
}