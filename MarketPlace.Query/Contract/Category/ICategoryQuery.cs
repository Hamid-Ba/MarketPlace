using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketPlace.Query.Contract.Category
{
    public interface ICategoryQuery
    {
        Task<IEnumerable<CategoryQueryVM>> GetForAddProduct();
    }
}
