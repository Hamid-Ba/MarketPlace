using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.Domain;
using MarketPlace.Domain.Entities.StoreAgg.ProductAgg;

namespace MarketPlace.Domain.RI.StoreAgg.ProductAgg
{
    public  interface ICategoryRepository : IRepository<Category>
    {
    }
}
