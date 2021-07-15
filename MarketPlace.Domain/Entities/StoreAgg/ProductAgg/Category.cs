using System;
using System.Collections.Generic;
using Framework.Domain;

namespace MarketPlace.Domain.Entities.StoreAgg.ProductAgg
{
    public class Category : EntityBase
    {
        public long? ParentId { get; private set; }
        public string Name { get; private set; }
        public string UrlName { get; private set; }

        public Category Parent { get; set; }
        public List<Product_Category> Products { get; private set; }
        public List<Category> SubCategories { get; private set; }

        public Category(long? parentId, string name,string urlName)
        {
            ParentId = parentId;
            Name = name;
            UrlName = urlName;
        }

        public void Edit(long? parentId, string name, string urlName)
        {
            ParentId = parentId;
            Name = name;
            UrlName = urlName;

            LastUpdateDate = DateTime.Now;
        }

        public void Delete()
        {
            IsDelete = true;
            DeletionDate = DateTime.Now;
        }
    }
}