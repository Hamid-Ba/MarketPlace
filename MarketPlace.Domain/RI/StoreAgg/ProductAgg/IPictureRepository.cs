using System.Threading.Tasks;
using Framework.Domain;
using MarketPlace.ApplicationContract.ViewModels.PictureAgg;
using MarketPlace.Domain.Entities.StoreAgg.ProductAgg;

namespace MarketPlace.Domain.RI.StoreAgg.ProductAgg
{
    public interface IPictureRepository : IRepository<Picture>
    {
        Task<EditPictureVM> GetDetailForEditBy(long id, long productId);
    }
}
