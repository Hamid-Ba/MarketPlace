using Framework.Domain;

namespace MarketPlace.Domain.Entities.StoreAgg.ProductAgg
{
    public class Picture : EntityBase
    {
        public long ProductId{ get; private set; }
        public string ImageName { get; private set; }
        public int Priority { get; private set; }

        public Product Product { get; private set; }

        public Picture(long productId,string imageName, int priority)
        {
            ProductId = productId;
            ImageName = imageName;
            Priority = priority;
        }

        public void Edit(string imageName, int priority)
        {
            if (!string.IsNullOrWhiteSpace(imageName))
                ImageName = imageName;

            Priority = priority;
        }
    }
}
