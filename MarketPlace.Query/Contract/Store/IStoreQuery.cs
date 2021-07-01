using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketPlace.Query.Contract.Store
{
    public interface IStoreQuery
    {
        Task<IEnumerable<StoreQueryVM>> GetUserStoresRequestsBy(long userId);
    }
}