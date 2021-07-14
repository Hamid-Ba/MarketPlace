using Framework.Domain;

namespace MarketPlace.Domain.Entities.StoreAgg.ProductAgg
{
    public class Product_Category : EntityBase
    {
        public long ProductId { get; private set; }
        public long CategoryId { get; private set; }

        public Product Product { get; private set; }
        public Category Category { get; private set; }

        public Product_Category(long productId, long categoryId)
        {
            ProductId = productId;
            CategoryId = categoryId;
        }
    }
}
