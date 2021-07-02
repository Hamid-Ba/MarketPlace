using System.ComponentModel.DataAnnotations;
using Framework.Application;

namespace MarketPlace.ApplicationContract.ViewModels.StoreAgg
{
    public class SendStoreRequestVM
    {
        public long UserId { get; set; }

        [Display(Name = "نام فروشگاه")]
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        [MaxLength(125, ErrorMessage = "حداکثر تعداد کاراکتر مجاز {1} می باشد")]
        public string Name { get; set; }

        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        [MaxLength(11, ErrorMessage = "حداکثر تعداد کاراکتر مجاز {1} می باشد")]
        [MinLength(11, ErrorMessage = "حداقل تعداد کاراکتر مجاز {1} می باشد")]
        [RegularExpression("(0|\\+98)?([ ]|-|[()]){0,2}9[1|2|3|4]([ ]|-|[()]){0,2}(?:[0-9]([ ]|-|[()]){0,2}){8}", ErrorMessage = "لطفا شماره خود را به فرم صحیح وارد نمایید")]
        public string MobileNumber { get; set; }

        [Display(Name = "آدرس فروشگاه")]
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        [MaxLength(500, ErrorMessage = "حداکثر تعداد کاراکتر مجاز {1} می باشد")]
        public string Address { get; set; }
    }

    public class EditStoreRequestVM
    {
        [Range(1, long.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
        public long Id { get; set; }

        public long UserId { get; set; }

        [Display(Name = "نام فروشگاه")]
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        [MaxLength(125, ErrorMessage = "حداکثر تعداد کاراکتر مجاز {1} می باشد")]
        public string Name { get; set; }

        [Display(Name = "شماره موبایل")]
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        [MaxLength(11, ErrorMessage = "حداکثر تعداد کاراکتر مجاز {1} می باشد")]
        [MinLength(11, ErrorMessage = "حداقل تعداد کاراکتر مجاز {1} می باشد")]
        [RegularExpression("(0|\\+98)?([ ]|-|[()]){0,2}9[1|2|3|4]([ ]|-|[()]){0,2}(?:[0-9]([ ]|-|[()]){0,2}){8}", ErrorMessage = "لطفا شماره خود را به فرم صحیح وارد نمایید")]
        public string MobileNumber { get; set; }

        [Display(Name = "آدرس فروشگاه")]
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        [MaxLength(500, ErrorMessage = "حداکثر تعداد کاراکتر مجاز {1} می باشد")]
        public string Address { get; set; }
    }
}