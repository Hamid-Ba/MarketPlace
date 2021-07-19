using System.Threading.Tasks;
using Framework.Application;
using MarketPlace.ApplicationContract.ViewModels.PictureAgg;

namespace MarketPlace.ApplicationContract.AI.PictureAgg
{
   public interface IPictureApplication
   {
       Task<OperationResult> Create(CreatePictureVM command);
       Task<OperationResult> Edit(EditPictureVM command);
       Task<EditPictureVM> GetDetailForEditBy(long id,long productId);
   }
}
