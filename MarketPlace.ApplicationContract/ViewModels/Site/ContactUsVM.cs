using System.ComponentModel.DataAnnotations;
using Framework.Application;

namespace MarketPlace.ApplicationContract.ViewModels.Site
{
    public class CreateContactUsVM : CaptchaViewModel
    {
        [Display(Name = "نام کامل")]
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        [MaxLength(150,ErrorMessage = "حداکثر کاراکتر {1} می باشد")]
        public string FullName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        [DataType(DataType.Html)]
        [MaxLength(250, ErrorMessage = "حداکثر کاراکتر {1} می باشد")]
        public string Email { get; set; }

        [Display(Name = "موضوع")]
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        [MaxLength(250, ErrorMessage = "حداکثر کاراکتر {1} می باشد")]
        public string Subject { get; set; }

        [Display(Name = "پیام شما")]
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string Message { get; set; }
    }
}
