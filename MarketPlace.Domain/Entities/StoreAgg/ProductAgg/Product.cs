using System;
using System.Collections.Generic;
using Framework.Application;
using Framework.Domain;

namespace MarketPlace.Domain.Entities.StoreAgg.ProductAgg
{
    public class Product : EntityBase
    {
        public long StoreId { get; private set; }
        public string Title { get; private set; }
        public string ImageName { get; private set; }
        public double Price { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string ProductAcceptOrRejectDescription { get; private set; }
        public bool IsActive { get; private set; }
        public ProductAcceptanceState ProductAcceptanceState { get; private set; }

        public Store Store { get; private set; }
        public List<Product_Category> Categories { get; private set; }
        public List<Picture> Pictures { get; private set; }

        public Product(long storeId, string title, string imageName, double price, string shortDescription, string description,
            string productAcceptOrRejectDescription, bool isActive, ProductAcceptanceState productAcceptanceState)
        {
            StoreId = storeId;
            Title = title;
            ImageName = imageName;
            Price = price;
            ShortDescription = shortDescription;
            Description = description;
            ProductAcceptOrRejectDescription = productAcceptOrRejectDescription;
            IsActive = isActive;
            ProductAcceptanceState = productAcceptanceState;
        }

        public void Edit(string title, string imageName, double price, string shortDescription, string description, bool isActive)
        {
            Title = title;

            if (!string.IsNullOrWhiteSpace(imageName))
                ImageName = imageName;

            Price = price;
            ShortDescription = shortDescription;
            Description = description;
            IsActive = isActive;

            LastUpdateDate = DateTime.Now;
        }

        public void SetProductState(ProductAcceptanceState state, string reason)
        {
            ProductAcceptanceState = state;
            ProductAcceptOrRejectDescription = reason;

            LastUpdateDate = DateTime.Now;
        }

        public void Delete()
        {
            IsDelete = true;
            DeletionDate = DateTime.Now;
        }


    }
}
