using MarketPlace.Domain.Entities.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketPlace.Infrastructure.EfCore.Mapping.Account
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Password).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(200);
            builder.Property(p => p.EmailActivateCode).HasMaxLength(200);
            builder.Property(p => p.FirstName).HasMaxLength(85).IsRequired();
            builder.Property(p => p.LastName).HasMaxLength(125).IsRequired();
            builder.Property(p => p.Mobile).HasMaxLength(11).IsRequired();
            builder.Property(p => p.MobileActivateCode).HasMaxLength(200);
            
        }
    }
}
