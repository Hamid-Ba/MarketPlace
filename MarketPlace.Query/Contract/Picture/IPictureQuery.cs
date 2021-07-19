using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketPlace.Query.Contract.Picture
{
    public interface IPictureQuery
    {
        Task<IEnumerable<PictureQueryVM>> GetPicturesBy(long productId);
    }
}
