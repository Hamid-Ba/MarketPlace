using System.Threading.Tasks;
using Framework.Domain;
using MarketPlace.ApplicationContract.ViewModels.StoreAgg;
using MarketPlace.Domain.Entities.StoreAgg;

namespace MarketPlace.Domain.RI.StoreAgg
{
    public interface IStoreRepository : IRepository<Store>
    {
        Task<EditStoreRequestVM> GetDetailForEditBy(long id);
    }
}