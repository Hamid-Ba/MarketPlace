﻿using System.Threading.Tasks;
using Framework.Application;
using MarketPlace.ApplicationContract.ViewModels.StoreAgg;

namespace MarketPlace.ApplicationContract.AI.StoreAgg
{
   public interface IStoreApplication
   {
       Task<OperationResult> SendRequest(SendStoreRequestVM command);
       Task<OperationResult> Edit(EditStoreRequestVM command);
       Task<EditStoreRequestVM> GetDetailForEditBy(long id, long userId);
   }
}