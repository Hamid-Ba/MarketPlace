using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Framework.Application;

namespace MarketPlace.Query.Contract.Product
{
    public class ProductQueryVM
    {
        public long Id { get; set; }
        public long StoreId { get;  set; }
        public string Title { get;  set; }
        public string ImageName { get;  set; }
        public double Price { get;  set; }
        public string ShortDescription { get;  set; }
        public string Description { get;  set; }
        public string ProductAcceptOrRejectDescription { get;  set; }
        public bool IsActive { get;  set; }
        public ProductAcceptanceState ProductAcceptanceState { get;  set; }
        public string CreationDate { get; set; }

        public List<ProductCategoryQueryVM> Categories { get; set; }
        public List<ProductPictureQueryVM> Pictures { get; set; }
    }

    public class ProductPictureQueryVM
    {
        public long Id { get; set; }
        public string ImageName { get; set; }
        public int Priority { get; set; }
    }

    public class ProductCategoryQueryVM
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
    }

    public class ProductMoneyRangeFilter
    {
        public int SelectedMaxValue { get; set; }
        public int SelectedMinValue { get; set; }
    }

    public enum ProductOrderFilter
    {
        [Display(Name = "نام محصول")]
        Title,

        [Display(Name = "قیمت نزولی")]
        Price_Dec,

        [Display(Name = "قیمت صعودی")]
        Price_Ace
    }
}
