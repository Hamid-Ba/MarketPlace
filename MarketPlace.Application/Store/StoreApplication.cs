using System.Threading.Tasks;
using Framework.Application;
using MarketPlace.ApplicationContract.AI.StoreAgg;
using MarketPlace.ApplicationContract.ViewModels.StoreAgg;
using MarketPlace.Domain.RI.StoreAgg;

namespace MarketPlace.Application.Store
{
    public class StoreApplication : IStoreApplication
    {
        private readonly IStoreRepository _storeRepository;

        public StoreApplication(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public async Task<OperationResult> SendRequest(SendStoreRequestVM command)
        {
            OperationResult result = new();

            if (_storeRepository.Exists(s => s.Name == command.Name && s.UserId == command.UserId))
                return result.Failed(ApplicationMessage.DuplicatedModel);

            var store = new Domain.Entities.StoreAgg.Store(command.UserId, command.Name, command.MobileNumber, StoreStatus.UnderProgressed, command.Address);

            await _storeRepository.AddEntityAsync(store);
            await _storeRepository.SaveChangesAsync();

            return result.Succeeded("درخواست شما با موفقیت ارسال شد");
        }
    }
}