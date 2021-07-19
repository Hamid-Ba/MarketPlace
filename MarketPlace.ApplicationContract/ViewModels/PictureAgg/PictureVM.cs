using System.ComponentModel.DataAnnotations;
using Framework.Application;
using Microsoft.AspNetCore.Http;

namespace MarketPlace.ApplicationContract.ViewModels.PictureAgg
{
    public class CreatePictureVM
    {
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        [Range(1,long.MaxValue,ErrorMessage = ValidationMessage.IsRequired)]
        public long ProductId { get; set; }

        public long UserId { get; set; }

        public IFormFile ImageFile { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        [Range(1, long.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
        public int Priority { get; set; }
    }

    public class EditPictureVM : CreatePictureVM
    {
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        [Range(1, long.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
        public long Id { get; set; }
    }
}
