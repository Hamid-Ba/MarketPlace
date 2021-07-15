using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketPlace.Query.Contract.Product
{
    public interface IProductQuery
    {
        Task<IEnumerable<ProductQueryVM>> GetStoreProducts(long storeId);
    }
}
