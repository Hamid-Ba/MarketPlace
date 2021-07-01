using Framework.Application;

namespace MarketPlace.Query.Contract.Store
{
   public class StoreQueryVM
    {
        public long UserId { get;  set; }
        public string Name { get;  set; }
        public string PhoneNumber { get;  set; }
        public string MobileNumber { get;  set; }
        public StoreStatus Status { get;  set; }
        public string AdminDescription { get;  set; }
        public string Description { get;  set; }
        public string Address { get;  set; }
        public string StoreGivenStatusReason { get; set; }
        public string SentRequestTime { get; set; }
    }
}
