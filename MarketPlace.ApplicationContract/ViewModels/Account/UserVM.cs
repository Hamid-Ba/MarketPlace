using System.ComponentModel.DataAnnotations;
using Framework.Application;

namespace MarketPlace.ApplicationContract.ViewModels.Account
{
    public class RegisterUserVM : CaptchaViewModel
    {
        [Display(Name = "نام")]
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        [MaxLength(85,ErrorMessage = "حداکثر تعداد کاراکتر مجاز {1} می باشد")]
        public string FirstName { get;  set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        [MaxLength(125, ErrorMessage = "حداکثر تعداد کاراکتر مجاز {1} می باشد")]
        public string LastName { get;  set; }

        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        [MaxLength(11, ErrorMessage = "حداکثر تعداد کاراکتر مجاز {1} می باشد")]
        [MinLength(11, ErrorMessage = "حداقل تعداد کاراکتر مجاز {1} می باشد")]
        [RegularExpression("(0|\\+98)?([ ]|-|[()]){0,2}9[1|2|3|4]([ ]|-|[()]){0,2}(?:[0-9]([ ]|-|[()]){0,2}){8}",ErrorMessage = "لطفا شماره خود را به فرم صحیح وارد نمایید")]
        public string Mobile { get;  set; }

        [Display(Name = "کد فعال سازی")]
        [MaxLength(6)]
        public string MobileActivateCode { get;  set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        [MaxLength(200, ErrorMessage = "حداکثر تعداد کاراکتر مجاز {1} می باشد")]
        public string Password { get;  set; }

        [Display(Name = "تکرار رمز عبور")]
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        [MaxLength(200, ErrorMessage = "حداکثر تعداد کاراکتر مجاز {1} می باشد")]
        [Compare("Password",ErrorMessage = ValidationMessage.ComparePassword)]
        public string ConfirmedPassword { get;  set; }
    }

    public class LoginUserVM : CaptchaViewModel
    {
        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        [MaxLength(11, ErrorMessage = "حداکثر تعداد کاراکتر مجاز {1} می باشد")]
        [MinLength(11, ErrorMessage = "حداقل تعداد کاراکتر مجاز {1} می باشد")]
        [RegularExpression("(0|\\+98)?([ ]|-|[()]){0,2}9[1|2|3|4]([ ]|-|[()]){0,2}(?:[0-9]([ ]|-|[()]){0,2}){8}", ErrorMessage = "لطفا شماره خود را به فرم صحیح وارد نمایید")]
        public string Mobile { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        [MaxLength(200, ErrorMessage = "حداکثر تعداد کاراکتر مجاز {1} می باشد")]
        public string Password { get; set; }

        [Display(Name = "من را به یاد بسپار")]
        public bool IsKeep { get; set; }
    }
}
