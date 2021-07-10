using System.Collections.Generic;
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

        public async Task<OperationResult> Edit(EditStoreRequestVM command)
        {
            OperationResult result = new();

            if (_storeRepository.Exists(s => s.Id == command.Id && s.UserId != command.UserId))
                return result.Failed("شما حق دسترسی به حساب دیگران را ندارید");

            var store = await _storeRepository.GetEntityByIdAsync(command.Id);
            if (store is null) return result.Failed(ApplicationMessage.NotExist);

            if (_storeRepository.Exists(s => s.Name == command.Name && s.UserId == command.UserId && s.Id != command.Id))
                return result.Failed(ApplicationMessage.DuplicatedModel);

            store.Edit(command.Name, "", command.MobileNumber, "", "", command.Address, "");
            store.ChangeStatus(StoreStatus.UnderProgressed,"در حال بررسی");

            await _storeRepository.SaveChangesAsync();

            return result.Succeeded();
        }

        public async Task<EditStoreRequestVM> GetDetailForEditBy(long id, long userId)
        {
            if (_storeRepository.Exists(s => s.Id == id && s.UserId != userId))
                return null;
            return await _storeRepository.GetDetailForEditBy(id);
        }

        public async Task<IEnumerable<AdminStoreRequestVM>> GetAllForAdmin() => await _storeRepository.GetAllForAdmin();
        
        public async Task<OperationResult> ConfirmStoreRequestBy(long id)
        {
            OperationResult result = new();

            var store = await _storeRepository.GetEntityByIdAsync(id);
            if (store is null) return result.Failed(ApplicationMessage.NotExist);

            store.ChangeStatus(StoreStatus.Confirmed,"تایید شده");
            await _storeRepository.SaveChangesAsync();

            return result.Succeeded();
        }

        public async Task<OperationResult> DissConfirmStoreRequestBy(DissConfrimStoreRequestVM command)
        {
            OperationResult result = new();

            var store = await _storeRepository.GetEntityByIdAsync(command.Id);
            if (store is null) return result.Failed(ApplicationMessage.NotExist);

            store.ChangeStatus(command.Status, command.StoreGivenStatusReason);
            await _storeRepository.SaveChangesAsync();

            return result.Succeeded();
        }
    }
}