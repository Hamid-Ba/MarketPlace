using System.ComponentModel.DataAnnotations;
using Framework.Application;
using Microsoft.AspNetCore.Http;

namespace MarketPlace.ApplicationContract.ViewModels.ProductAgg
{
    public class CreateProductVM
    {
        public long StoreId { get; set; }

        [Display(Name = "نام محصول")]
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        [MaxLength(300, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Title { get; set; }

        [Display(Name = "دسته بندی ها")]
        public long[] CategoriesId { get; set; }

        [Display(Name = "تصویر محصول")]
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        [MaxLength(300, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public IFormFile ImageFile { get; set; }

        [Display(Name = "قیمت محصول")]
        [Range(1,double.MaxValue,ErrorMessage = ValidationMessage.IsRequired)]
        public double Price { get; set; }

        [Display(Name = "توضیحات کوتاه")]
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string ShortDescription { get; set; }

        [Display(Name = "توضیحات اصلی")]
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Description { get; set; }

        [Display(Name = "فعال / غیرفعال")]
        public bool IsActive { get; set; }
    }
}
