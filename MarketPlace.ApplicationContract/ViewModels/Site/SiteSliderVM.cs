using System.ComponentModel.DataAnnotations;
using Framework.Application;
using Microsoft.AspNetCore.Http;

namespace MarketPlace.ApplicationContract.ViewModels.Site
{
    public class CreateSiteSliderVM
    {
        [Display(Name = "عنوان اصلی")]
        [MaxLength(150, ErrorMessage = "حداکثر کاراکتر {1} می باشد")]
        public string FirstHeader { get; set; }

        [Display(Name = "عنوان دوم")]
        [MaxLength(250, ErrorMessage = "حداکثر کاراکتر {1} می باشد")]
        public string SecondHeader { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(500, ErrorMessage = "حداکثر کاراکتر {1} می باشد")]
        public string Description { get; set; }

        [Display(Name = "متن کلیک")]
        [MaxLength(25, ErrorMessage = "حداکثر کاراکتر {1} می باشد")]
        public string TextButton { get; set; }

        [Display(Name = "لینک")] public string Link { get; set; }

        [Display(Name = "تصویر")]
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public IFormFile ImageFile { get; set; }

        [Display(Name = "نشان داده شود ؟")] public bool IsDisplay { get; set; }
    }
}