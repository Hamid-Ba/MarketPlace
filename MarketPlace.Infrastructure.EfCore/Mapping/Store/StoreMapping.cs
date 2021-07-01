using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketPlace.Infrastructure.EfCore.Mapping.Store
{
    public class StoreMapping : IEntityTypeConfiguration<Domain.Entities.StoreAgg.Store>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.StoreAgg.Store> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Name).HasMaxLength(125).IsRequired();
            builder.Property(p => p.MobileNumber).HasMaxLength(11).IsRequired();
            builder.Property(p => p.Address).HasMaxLength(500).IsRequired();

            builder.HasOne(u => u.User).WithMany(s => s.Stores).HasForeignKey(f => f.UserId);
        }
    }
}
