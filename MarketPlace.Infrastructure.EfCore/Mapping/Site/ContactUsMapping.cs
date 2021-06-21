using MarketPlace.Domain.Entities.Site;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketPlace.Infrastructure.EfCore.Mapping.Site
{
    public class ContactUsMapping : IEntityTypeConfiguration<ContactUs>
    {
        public void Configure(EntityTypeBuilder<ContactUs> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.FullName).IsRequired().HasMaxLength(150);
            builder.Property(p => p.Subject).IsRequired().HasMaxLength(250);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(250);
            builder.Property(p => p.Ip).HasMaxLength(250);
            builder.Property(p => p.Message).IsRequired();
        }
    }
}
