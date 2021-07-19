using MarketPlace.Domain.Entities.StoreAgg.ProductAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketPlace.Infrastructure.EfCore.Mapping.Product
{
    public class PictureMapping : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.ImageName).HasMaxLength(100).IsRequired();

            builder.HasOne(p => p.Product)
                .WithMany(p => p.Pictures)
                .HasForeignKey(f => f.ProductId);
        }
    }
}
