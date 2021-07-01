using System.Threading.Tasks;
using Framework.Application;
using MarketPlace.ApplicationContract.ViewModels.StoreAgg;

namespace MarketPlace.ApplicationContract.AI.StoreAgg
{
   public interface IStoreApplication
   {
       Task<OperationResult> SendRequest(SendStoreRequestVM command);
   }
}