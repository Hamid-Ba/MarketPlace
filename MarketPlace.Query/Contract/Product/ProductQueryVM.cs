using Framework.Application;

namespace MarketPlace.Query.Contract.Product
{
    public class ProductQueryVM
    {
        public long Id { get; set; }
        public long StoreId { get;  set; }
        public string Title { get;  set; }
        public string ImageName { get;  set; }
        public double Price { get;  set; }
        public string ShortDescription { get;  set; }
        public string Description { get;  set; }
        public string ProductAcceptOrRejectDescription { get;  set; }
        public bool IsActive { get;  set; }
        public ProductAcceptanceState ProductAcceptanceState { get;  set; }
        public string CreationDate { get; set; }
    }
}
