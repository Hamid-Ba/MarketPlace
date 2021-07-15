using MarketPlace.Domain.Entities.StoreAgg.ProductAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketPlace.Infrastructure.EfCore.Mapping.Product
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Name).HasMaxLength(85).IsRequired();

            builder.HasMany(c => c.SubCategories).WithOne(c => c.Parent).HasForeignKey(f => f.ParentId);

            builder.HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(f => f.CategoryId);
        }
    }
}
