using System.ComponentModel.DataAnnotations;
using Framework.Application;
using Microsoft.AspNetCore.Http;

namespace MarketPlace.ApplicationContract.ViewModels.Site
{
    public class CreateSiteBannerVM
    {
        [Display(Name = "تصویر")]
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public IFormFile ImageFile { get; set; }

        [Display(Name = "سایز")]
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string ColSize { get; set; }

        [Display(Name = "لینک")]
        public string Url { get; set; }

        [Display(Name = "موقعیت")]
        [Range(0,2,ErrorMessage = ValidationMessage.IsRequired)]
        public BannerPosition Position { get; set; }
    }
}