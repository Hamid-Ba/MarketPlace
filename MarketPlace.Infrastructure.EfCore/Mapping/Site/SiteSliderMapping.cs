using MarketPlace.Domain.Entities.Site;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketPlace.Infrastructure.EfCore.Mapping.Site
{
    public class SiteSliderMapping : IEntityTypeConfiguration<SiteSlider>
    {
        public void Configure(EntityTypeBuilder<SiteSlider> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.FirstHeader).HasMaxLength(150);
            builder.Property(p => p.SecondHeader).HasMaxLength(250);
            builder.Property(p => p.Description).HasMaxLength(500);
            builder.Property(p => p.TextButton).HasMaxLength(25);
            builder.Property(p => p.ImageName).IsRequired();
        }
    }
}
