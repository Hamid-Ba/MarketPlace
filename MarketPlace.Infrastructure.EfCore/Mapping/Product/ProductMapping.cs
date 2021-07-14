using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketPlace.Infrastructure.EfCore.Mapping.Product
{
    public class ProductMapping : IEntityTypeConfiguration<Domain.Entities.StoreAgg.ProductAgg.Product>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.StoreAgg.ProductAgg.Product> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Title).HasMaxLength(150).IsRequired();
            builder.Property(p => p.ImageName).HasMaxLength(150).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.ProductAcceptOrRejectDescription).HasMaxLength(500);
            builder.Property(p => p.ShortDescription).HasMaxLength(500).IsRequired();

            builder.HasOne(s => s.Store)
                .WithMany(p => p.Products)
                .HasForeignKey(f => f.StoreId);

            builder.HasMany(c => c.Categories)
                .WithOne(p => p.Product)
                .HasForeignKey(f => f.ProductId);
        }
    }
}
