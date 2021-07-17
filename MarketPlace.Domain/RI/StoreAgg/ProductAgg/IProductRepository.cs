﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Framework.Domain;
using MarketPlace.ApplicationContract.ViewModels.ProductAgg;
using MarketPlace.Domain.Entities.StoreAgg.ProductAgg;

namespace MarketPlace.Domain.RI.StoreAgg.ProductAgg
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<EditProductVM> GetDetailForEditBy(long id);
        Task<IEnumerable<AdminProductVM>> GetAllForAdmin();
    }
}
